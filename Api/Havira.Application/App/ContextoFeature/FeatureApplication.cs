using AutoMapper;
using Havira.Business.Interfaces;
using Havira.Business.Interfaces.ContextoFeature;
using Havira.Application.Interfaces.ContextoFeature;
using Havira.Application.ViewModel.ContextoFeature;
using Havira.Business.Models.ContextoFeature;
using Havira.Business.Models.ContextoFeature.Validations;
using Havira.Business.Models.ContextoFeature.Enums;
using Havira.Data.Repository.ContextoFeature;
using NetTopologySuite.Geometries;


namespace Havira.Application.App.ContextoFeature
{
    public class FeatureApplication : BaseApplication, IFeatureApplication
    {

        private readonly IFeatureRepository _featureRepository;
        private readonly IPropertiesRepository _propertiesRepository;
        private readonly IMapper _mapper;

        public FeatureApplication(IFeatureRepository featureRepository,
                                    IPropertiesRepository propertiesRepository,
                                    IMapper mapper,
                                    INotificador notificador) : base(notificador)
        {
            _featureRepository = featureRepository;
            _propertiesRepository = propertiesRepository;
            _mapper = mapper;
        }

        public async Task<FeatureViewModel> ObterPorId(Guid id)
        {
            var feature = await _featureRepository.ObterPorId(id);

            if (feature == null)
            {
                Notificar("Localização não encontrada.");
                return null;
            }

            return _mapper.Map<FeatureViewModel>(feature);
        }

        public async Task<FeatureViewModel> ObterFeaturePorNome(string nome)
        {
            var feature = await _featureRepository.ObterFeaturePorNome(nome);

            if (feature == null)
            {
                Notificar("Localização não encontrada.");
                return null;
            }

            return _mapper.Map<FeatureViewModel>(feature);
        }

        public async Task<FeatureViewModel> AdicionarFeature(FeatureViewModel featureViewModel)
        {
            if (!ExecutarValidacao(new FeatureValidation(), _mapper.Map<Feature>(featureViewModel))) return null;

            var nomeFeatureExiste = await _featureRepository.ObterFeaturePorNome(featureViewModel.Properties.Nome);

            if (nomeFeatureExiste != null)
            {
                Notificar("Já existe um localização com este nome.");
                return null;
            }

            var geometryFactory = NetTopologySuite.NtsGeometryServices.Instance.CreateGeometryFactory(4326);

            var geometry = geometryFactory.CreatePoint(new Coordinate(featureViewModel.Geometry.Coordinate.X, featureViewModel.Geometry.Coordinate.Y));

            var feature = new Feature(featureViewModel.Type, geometry);

            var properties = await _propertiesRepository.ObterPropertiesPorNome(featureViewModel.Properties.Nome);

            if (properties == null)
            {
                await _propertiesRepository.Adicionar(new Properties(
                                                        featureViewModel.Properties.Nome,
                                                        featureViewModel.Properties.Categoria
                                                    ));
                properties = await _propertiesRepository.ObterPropertiesPorNome(featureViewModel.Properties.Nome);
            }

            feature.Properties = properties;

            await _featureRepository.Adicionar(feature);

            var featurePersistido = await _featureRepository.ObterPorId(feature.Id);

            return _mapper.Map<FeatureViewModel>(featurePersistido);
        }

        public async Task<bool> RemoverFeature(Guid Id)
        {
            var feature = await _featureRepository.ObterPorId(Id);

            if (feature == null)
            {
                Notificar("Localizacão não encontrada.");
                return false;
            }

            await _featureRepository.Remover(Id);

            return true;
        }

        public async Task<IEnumerable<FeatureViewModel>> ObterTodos()
            => _mapper.Map<IEnumerable<FeatureViewModel>>(await _featureRepository.ObterTodos());

        public async Task Adicionar(FeatureViewModel viewModel)
            => await _featureRepository.Adicionar(_mapper.Map<Feature>(viewModel));

        public async Task<bool> Atualizar(FeatureViewModel viewModel)
        {
            var feature = _mapper.Map<Feature>(viewModel);

            if (!ExecutarValidacao(new FeatureValidation(), feature)) return false;

            var featureExistente = await _featureRepository.ObterPorId(feature.Id);

            if (featureExistente == null)
            {
                Notificar("Localização não encontrada.");
                return false;
            }

            var properties = await _propertiesRepository.ObterPropertiesPorNome(viewModel.Properties.Nome);

            if (properties == null)
            {
                await _propertiesRepository.Adicionar(new Properties(
                                                        viewModel.Properties.Nome,
                                                        viewModel.Properties.Categoria
                                                    ));
                properties = await _propertiesRepository.ObterPropertiesPorNome(viewModel.Properties.Nome);
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

        public async Task<bool> Remover(Guid id)
        {
            var feature = await _featureRepository.ObterPorId(id);

            if (feature == null)
            {
                Notificar("Localização não encontrada.");
                return false;
            }

            await _featureRepository.Remover(id);

            return true;
        }

        public void Dispose()
            => _featureRepository?.Dispose();
    }
}