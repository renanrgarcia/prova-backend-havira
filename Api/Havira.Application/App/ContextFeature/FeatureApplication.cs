using AutoMapper;
using Havira.Business.Interfaces;
using Havira.Business.Interfaces.ContextFeature;
using Havira.Application.Interfaces.ContextFeature;
using Havira.Application.ViewModel.ContextFeature;
using Havira.Business.Models.ContextFeature;
using Havira.Business.Models.ContextFeature.Validations;
using Havira.Business.Models.ContextFeature.Enums;
using Havira.Data.Repository.ContextFeature;
using NetTopologySuite.Geometries;


namespace Havira.Application.App.ContextFeature
{
    public class FeatureApplication : BaseApplication, IFeatureApplication
    {

        private readonly IFeatureRepository _featureRepository;
        private readonly IMapper _mapper;

        public FeatureApplication(IFeatureRepository featureRepository,
                                    IMapper mapper,
                                    INotificator notificator) : base(notificator)
        {
            _featureRepository = featureRepository;
            _mapper = mapper;
        }

        public async Task<FeatureViewModel> GetById(Guid id)
        {
            var feature = await _featureRepository.GetById(id);

            if (feature == null)
            {
                Notificate("Localização não encontrada.");
                return null;
            }

            return _mapper.Map<FeatureViewModel>(feature);
        }

        public async Task<FeatureViewModel> GetFeatureByName(string name)
        {
            var feature = await _featureRepository.GetFeatureByName(name);

            if (feature == null)
            {
                Notificate("Localização não encontrada.");
                return null;
            }

            return _mapper.Map<FeatureViewModel>(feature);
        }

        public async Task<FeatureViewModel> CreateFeature(FeatureViewModel featureViewModel)
        {
            if (!ExecuteValidation(new FeatureValidation(), _mapper.Map<Feature>(featureViewModel))) return null;

            var nameFeatureExiste = await _featureRepository.GetFeatureByName(featureViewModel.Name);

            if (nameFeatureExiste != null)
            {
                Notificate("Já existe um localização com este name.");
                return null;
            }

            var geometryFactory = NetTopologySuite.NtsGeometryServices.Instance.CreateGeometryFactory(4326);

            var geometry = geometryFactory.CreatePoint(new Coordinate(featureViewModel.Geometry.Coordinate.X, featureViewModel.Geometry.Coordinate.Y));

            var feature = new Feature(featureViewModel.Type, geometry);

            var properties = await _propertiesRepository.GetPropertiesPorName(featureViewModel.Properties.Name);

            if (properties == null)
            {
                await _propertiesRepository.Create(new Properties(
                                                        featureViewModel.Properties.Name,
                                                        featureViewModel.Properties.Categoria
                                                    ));
                properties = await _propertiesRepository.GetPropertiesPorName(featureViewModel.Properties.Name);
            }

            feature.Properties = properties;

            await _featureRepository.Create(feature);

            var featurePersistido = await _featureRepository.GetById(feature.Id);

            return _mapper.Map<FeatureViewModel>(featurePersistido);
        }

        public async Task<bool> RemoveFeature(Guid Id)
        {
            var feature = await _featureRepository.GetById(Id);

            if (feature == null)
            {
                Notificate("Localizacão não encontrada.");
                return false;
            }

            await _featureRepository.Remove(Id);

            return true;
        }

        public async Task<IEnumerable<FeatureViewModel>> GetAll()
            => _mapper.Map<IEnumerable<FeatureViewModel>>(await _featureRepository.GetAll());

        public async Task Create(FeatureViewModel viewModel)
            => await _featureRepository.Create(_mapper.Map<Feature>(viewModel));

        public async Task<bool> Update(FeatureViewModel viewModel)
        {
            var feature = _mapper.Map<Feature>(viewModel);

            if (!ExecuteValidation(new FeatureValidation(), feature)) return false;

            var featureExistente = await _featureRepository.GetById(feature.Id);

            if (featureExistente == null)
            {
                Notificate("Localização não encontrada.");
                return false;
            }

            var properties = await _propertiesRepository.GetPropertiesPorName(viewModel.Properties.Name);

            if (properties == null)
            {
                await _propertiesRepository.Create(new Properties(
                                                        viewModel.Properties.Name,
                                                        viewModel.Properties.Categoria
                                                    ));
                properties = await _propertiesRepository.GetPropertiesPorName(viewModel.Properties.Name);
            }

            var featureAtualizada = new Feature(feature.Type, feature.Geometry)
            {
                Id = feature.Id,
                Properties = properties
            };

            featureExistente.Editar(featureAtualizada.Type, feature.Geometry, featureAtualizada.Properties);

            await _featureRepository.Atualizar(featureExistente);

            return true;
        }

        public async Task<bool> Remove(Guid id)
        {
            var feature = await _featureRepository.GetById(id);

            if (feature == null)
            {
                Notificate("Localização não encontrada.");
                return false;
            }

            await _featureRepository.Remove(id);

            return true;
        }

        public void Dispose()
            => _featureRepository?.Dispose();
    }
}