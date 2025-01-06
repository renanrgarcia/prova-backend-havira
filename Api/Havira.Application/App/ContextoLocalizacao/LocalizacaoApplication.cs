using AutoMapper;
using Havira.Business.Interfaces;
using Havira.Business.Interfaces.ContextoLocalizacao;
using Havira.Application.Interfaces.ContextoLocalizacao;
using Havira.Application.ViewModel.ContextoLocalizacao;
using Havira.Business.Models.ContextoLocalizacao;
using Microsoft.EntityFrameworkCore;
using Havira.Business.Models.ContextoLocalizacao.Validations;
using Havira.Business.Models.ContextoLocalizacao.Enums;
using System.Text.Json;
using NetTopologySuite.Geometries;
using static Havira.Business.Models.ContextoLocalizacao.Localizacao;

namespace Havira.Application.App.ContextoLocalizacao
{
    public class LocalizacaoApplication : BaseApplication, ILocalizacaoApplication
    {

        private readonly ILocalizacaoRepository _localizacaoRepository;
        private readonly IMapper _mapper;

        public LocalizacaoApplication(ILocalizacaoRepository localizacaoRepository,
                                    IMapper mapper,
                                    INotificador notificador) : base(notificador)
        {
            _localizacaoRepository = localizacaoRepository;
            _mapper = mapper;
        }

        public async Task<LocalizacaoViewModel> ObterPorId(Guid id)
        {
            var localizacao = await _localizacaoRepository.ObterPorId(id);

            if (localizacao == null)
            {
                Notificar("Localização não encontrada.");
                return null;
            }

            return _mapper.Map<LocalizacaoViewModel>(localizacao);
        }

        public async Task<LocalizacaoViewModel> ObterLocalizacaoPorNome(string nome)
        {
            var localizacao = await _localizacaoRepository.ObterLocalizacaoPorNome(nome);

            if (localizacao == null)
            {
                Notificar("Localização não encontrada.");
                return null;
            }

            return _mapper.Map<LocalizacaoViewModel>(localizacao);
        }

        public async Task<LocalizacaoViewModel> AdicionarLocalizacao(LocalizacaoViewModel localizacaoViewModel)
        {
            if (!ExecutarValidacao(new LocalizacaoValidation(), _mapper.Map<Localizacao>(localizacaoViewModel))) return null;

            var nomeLocalizacaoExiste = await _localizacaoRepository.ObterLocalizacaoPorNome(localizacaoViewModel.Nome);

            if (nomeLocalizacaoExiste != null)
            {
                Notificar("Já existe um localização com este nome.");
                return null;
            }

            var localizacao = new Localizacao(localizacaoViewModel.Nome,
                                        localizacaoViewModel.Categoria,
                                        localizacaoViewModel.Coordenadas);

            await _localizacaoRepository.Adicionar(localizacao);

            var localizacaoPersistido = await _localizacaoRepository.ObterPorId(localizacao.Id);

            return _mapper.Map<LocalizacaoViewModel>(localizacaoPersistido);
        }

        public async Task<bool> RemoverLocalizacao(Guid Id)
        {
            var localizacao = await _localizacaoRepository.ObterPorId(Id);

            if (localizacao == null)
            {
                Notificar("Localizacão não encontrada.");
                return false;
            }

            await _localizacaoRepository.Remover(Id);

            return true;
        }

        public async Task<List<Categoria>> ObterCategorias()
        {
            var categorias = await _localizacaoRepository.ObterCategorias();

            if (categorias == null || !categorias.Any())
            {
                Notificar("Nenhuma categoria encontrada.");

                return null;
            }

            return categorias;
        }

        public async Task<List<LocalizacaoViewModel>> ObterPorCategoria(Categoria categoria)
        {
            if (!Enum.IsDefined(typeof(Categoria), categoria))
            {
                Notificar("Categoria inválida.");
                return null;
            }

            var localizacoes = await _localizacaoRepository.ObterPorCategoria(categoria);

            if (localizacoes == null || !localizacoes.Any())
            {
                Notificar("Nenhuma localização encontrada.");
                return null;
            }

            return _mapper.Map<List<LocalizacaoViewModel>>(localizacoes);
        }

        public async Task<IEnumerable<LocalizacaoViewModel>> ObterTodos()
            => _mapper.Map<IEnumerable<LocalizacaoViewModel>>(await _localizacaoRepository.ObterTodos());

        public async Task Adicionar(LocalizacaoViewModel viewModel)
            => await _localizacaoRepository.Adicionar(_mapper.Map<Localizacao>(viewModel));

        public async Task<bool> Atualizar(LocalizacaoViewModel viewModel)
        {
            var localizacao = _mapper.Map<Localizacao>(viewModel);

            if (!ExecutarValidacao(new LocalizacaoValidation(), localizacao)) return false;

            var localizacaoExistente = await _localizacaoRepository.ObterPorId(localizacao.Id);

            if (localizacaoExistente == null)
            {
                Notificar("Localização não encontrada.");
                return false;
            }

            localizacaoExistente.Editar(localizacao.Nome, localizacao.Categoria, localizacaoExistente.Coordenadas);

            await _localizacaoRepository.Atualizar(localizacaoExistente);

            return true;
        }

        public async Task<bool> Remover(Guid id)
        {
            var localizacao = await _localizacaoRepository.ObterPorId(id);

            if (localizacao == null)
            {
                Notificar("Localização não encontrada.");
                return false;
            }

            await _localizacaoRepository.Remover(id);

            return true;
        }

        public async void Dispose()
            => _localizacaoRepository?.Dispose();

    }
}