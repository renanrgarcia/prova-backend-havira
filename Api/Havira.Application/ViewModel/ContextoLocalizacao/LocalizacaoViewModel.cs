using System.Text.Json.Serialization;
using Havira.Business.Models.ContextoLocalizacao.Enums;
using NetTopologySuite.Geometries;
using static Havira.Business.Models.ContextoLocalizacao.Localizacao;

namespace Havira.Application.ViewModel.ContextoLocalizacao;

public class LocalizacaoViewModel
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public Categoria Categoria { get; set; }
    // [JsonConverter(typeof(PointJsonConverter))]
    public Point Coordenadas { get; set; }
    public bool Status { get; set; }
}