using Havira.Business.Models.ContextoLocalizacao.Enums;
using NetTopologySuite.Geometries;

namespace Havira.Application.ViewModel.ContextoLocalizacao;

public class LocalizacaoViewModel
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public Categoria Categoria { get; set; }
    public Point Coordenadas { get; set; }
    public bool Status { get; set; }
}