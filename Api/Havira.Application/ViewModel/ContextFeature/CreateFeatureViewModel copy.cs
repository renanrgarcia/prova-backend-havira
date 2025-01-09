
using System.ComponentModel.DataAnnotations;
using Havira.Business.Models.ContextFeature.Enums;
using Newtonsoft.Json;
using static Havira.Business.Models.ContextFeature.Feature;

namespace Havira.Application.ViewModel.ContextFeature;

public class CreateFeatureViewModel
{
    public Guid? Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public Category Category { get; set; }
    [Required]
    public GeoJsonPoint Point { get; set; }
}
