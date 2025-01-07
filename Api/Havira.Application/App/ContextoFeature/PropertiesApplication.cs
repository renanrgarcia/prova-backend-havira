using AutoMapper;
using Havira.Business.Interfaces;
using Havira.Business.Interfaces.ContextoFeature;
using Havira.Application.Interfaces.ContextoFeature;
using Havira.Application.ViewModel.ContextoFeature;
using Havira.Business.Models.ContextoFeature;
using Havira.Business.Models.ContextoFeature.Validations;
using Havira.Business.Models.ContextoFeature.Enums;


namespace Havira.Application.App.ContextoFeature
{
    public class PropertiesApplication : BaseApplication, IPropertiesApplication
    {

        private readonly IPropertiesRepository _propertiesRepository;
        private readonly IMapper _mapper;

        public PropertiesApplication(IPropertiesRepository propertiesRepository,
                                    IMapper mapper,
                                    INotificador notificador) : base(notificador)
        {
            _propertiesRepository = propertiesRepository;
            _mapper = mapper;
        }

        public async Task<List<Categoria>> ObterCategorias()
        {
            var categorias = await _propertiesRepository.ObterCategorias();

            if (categorias == null || !categorias.Any())
            {
                Notificar("Nenhuma categoria encontrada.");

                return null;
            }

            return categorias;
        }

        public async Task<PropertiesViewModel> ObterPorId(Guid Id)
        {
            var properties = await _propertiesRepository.ObterPorId(Id);
            return _mapper.Map<PropertiesViewModel>(properties);
        }

        public async Task<IEnumerable<PropertiesViewModel>> ObterTodos()
            => _mapper.Map<IEnumerable<PropertiesViewModel>>(await _propertiesRepository.ObterTodos());

        public async Task Adicionar(PropertiesViewModel viewModel)
            => await _propertiesRepository.Adicionar(_mapper.Map<Properties>(viewModel));

        public async Task<bool> Atualizar(PropertiesViewModel viewModel)
        {
            var properties = _mapper.Map<Properties>(viewModel);

            if (!ExecutarValidacao(new PropertiesValidation(), properties)) return false;

            await _propertiesRepository.Atualizar(properties);

            return true;
        }

        public async Task<bool> Remover(Guid id)
        {
            var properties = await _propertiesRepository.ObterPorId(id);

            if (properties == null)
            {
                Notificar("Localização não encontrada.");
                return false;
            }

            await _propertiesRepository.Remover(id);

            return true;
        }

        public async void Dispose()
            => _propertiesRepository?.Dispose();
    }
}