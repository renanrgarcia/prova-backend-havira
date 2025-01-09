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

        public async Task<CreateFeatureViewModel> CreateFeature(CreateFeatureViewModel viewModel)
        {
            if (!ExecuteValidation(new FeatureValidation(), _mapper.Map<Feature>(viewModel))) return null;

            var nameFeatureExiste = await _featureRepository.GetFeatureByName(viewModel.Name);

            if (nameFeatureExiste != null)
            {
                Notificate("There is already a location with this name.");
                return null;
            }

            var gf = NetTopologySuite.NtsGeometryServices.Instance.CreateGeometryFactory(4326);
            var point = gf.CreatePoint(new Coordinate(viewModel.Point.Coordinates[0], viewModel.Point.Coordinates[1]));

            var feature = new Feature(viewModel.Name, viewModel.Category, point);

            await _featureRepository.Create(feature);

            var featurePersisted = await _featureRepository.GetById(feature.Id);

            return _mapper.Map<CreateFeatureViewModel>(featurePersisted);
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

        public async Task Create(CreateFeatureViewModel viewModel)
            => await _featureRepository.Create(_mapper.Map<Feature>(viewModel));

        public async Task<bool> Update(CreateFeatureViewModel viewModel)
        {
            var feature = _mapper.Map<Feature>(viewModel);

            if (!ExecuteValidation(new FeatureValidation(), feature)) return false;

            var existantFeature = await _featureRepository.GetById(feature.Id);

            if (existantFeature == null)
            {
                Notificate("Location not found.");
                return false;
            }

            var gf = NetTopologySuite.NtsGeometryServices.Instance.CreateGeometryFactory(4326);
            var point = gf.CreatePoint(new Coordinate(viewModel.Point.Coordinates[0], viewModel.Point.Coordinates[1]));

            var newFeature = new Feature(viewModel.Name, viewModel.Category, point);

            existantFeature.Editar(newFeature.Name, newFeature.Category, newFeature.Geometry);

            await _featureRepository.Update(existantFeature);

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