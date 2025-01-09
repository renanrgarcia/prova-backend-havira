using AutoMapper;
using Havira.Business.Interfaces;
using Havira.Business.Interfaces.ContextFeature;
using Havira.Application.Interfaces.ContextFeature;
using Havira.Application.ViewModel.ContextFeature;
using Havira.Business.Models.ContextFeature;
using Havira.Business.Models.ContextFeature.Validations;
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

        public async Task<GetFeatureViewModel> GetById(Guid id)
        {
            var feature = await _featureRepository.GetById(id);

            if (feature == null)
            {
                Notificate("Location not found.");
                return null;
            }

            return _mapper.Map<GetFeatureViewModel>(feature);
        }

        public async Task<GetFeatureViewModel> GetFeatureByName(string name)
        {
            var feature = await _featureRepository.GetFeatureByName(name);

            if (feature == null)
            {
                Notificate("Location not found.");
                return null;
            }

            return _mapper.Map<GetFeatureViewModel>(feature);
        }

        public async Task<CreateOrUpdateFeatureViewModel> CreateFeature(CreateOrUpdateFeatureViewModel viewModel)
        {
            if (!ExecuteValidation(new FeatureValidation(), _mapper.Map<Feature>(viewModel))) return null;

            var nameFeatureExists = await _featureRepository.GetFeatureByName(viewModel.Name);

            if (nameFeatureExists != null)
            {
                Notificate("There is already a location with this name.");
                return null;
            }

            var gf = NetTopologySuite.NtsGeometryServices.Instance.CreateGeometryFactory(4326);
            var point = gf.CreatePoint(new Coordinate(viewModel.Longitude, viewModel.Latitude));

            var feature = new Feature(viewModel.Name, viewModel.Category, point);

            await _featureRepository.Create(feature);

            var featurePersisted = await _featureRepository.GetById(feature.Id);

            return _mapper.Map<CreateOrUpdateFeatureViewModel>(featurePersisted);
        }

        public async Task<bool> RemoveFeature(Guid Id)
        {
            var feature = await _featureRepository.GetById(Id);

            if (feature == null)
            {
                Notificate("Location not found.");
                return false;
            }

            await _featureRepository.Remove(Id);

            return true;
        }

        public async Task<IEnumerable<GetFeatureViewModel>> GetAll()
            => _mapper.Map<IEnumerable<GetFeatureViewModel>>(await _featureRepository.GetAll());

        public async Task Create(CreateOrUpdateFeatureViewModel viewModel)
            => await _featureRepository.Create(_mapper.Map<Feature>(viewModel));

        public async Task<bool> Update(CreateOrUpdateFeatureViewModel viewModel)
        {
            if (!ExecuteValidation(new FeatureValidation(), _mapper.Map<Feature>(viewModel))) return false;

            if (viewModel.Id.HasValue)
            {
                var existantFeature = await _featureRepository.GetById(viewModel.Id.Value);

                if (existantFeature == null)
                {
                    Notificate("Location not found.");
                    return false;
                }
                else
                {
                    var gf = NetTopologySuite.NtsGeometryServices.Instance.CreateGeometryFactory(4326);
                    var point = gf.CreatePoint(new Coordinate(viewModel.Longitude, viewModel.Latitude));

                    var feature = new Feature(viewModel.Name, viewModel.Category, point);

                    existantFeature.Editar(feature.Name, feature.Category, feature.Geometry);

                    await _featureRepository.Update(existantFeature);
                }
            }

            return true;
        }

        public async Task<bool> Remove(Guid id)
        {
            var feature = await _featureRepository.GetById(id);

            if (feature == null)
            {
                Notificate("Location not found.");
                return false;
            }

            await _featureRepository.Remove(id);

            return true;
        }

        public void Dispose()
            => _featureRepository?.Dispose();
    }
}