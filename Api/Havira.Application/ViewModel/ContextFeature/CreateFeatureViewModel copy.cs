
using System.ComponentModel.DataAnnotations;
using Havira.Business.Models.ContextFeature.Enums;
using Newtonsoft.Json;
using static Havira.Business.Models.ContextFeature.Feature;

namespace Havira.Application.ViewModel.ContextFeature;

public class CreateFeatureViewModel
{
    public Guid? Id { get; set; }
    [Required(ErrorMessage = "The {0} field is required")]
    [StringLength(100, ErrorMessage = "The {0} field must be between {2} and {1} characters", MinimumLength = 2)]
    public string Name { get; set; }
    [Required(ErrorMessage = "The {0} field is required")]
    public Category Category { get; set; }
    [Required(ErrorMessage = "The {0} field is required")]
    public GeoJsonPoint Point { get; set; }
}
