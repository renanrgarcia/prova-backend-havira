
using System.ComponentModel.DataAnnotations;
using Havira.Business.Models.ContextFeature.Enums;
using Newtonsoft.Json;

namespace Havira.Application.ViewModel.ContextFeature;

public class CreateOrUpdateFeatureViewModel
{
    public Guid? Id { get; set; }
    [Required(ErrorMessage = "The {0} field is required.")]
    [StringLength(100, ErrorMessage = "The {0} field must be between {2} and {1} characters.", MinimumLength = 2)]
    public string Name { get; set; }
    [Required(ErrorMessage = "The {0} field is required.")]
    public Category Category { get; set; }
    [Required(ErrorMessage = "The {0} field is required")]
    [Range(-180, 180, ErrorMessage = "The {0} field must be between {1} and {2}.")]
    public double Longitude { get; set; }
    [Required(ErrorMessage = "The {0} field is required.")]
    [Range(-90, 90, ErrorMessage = "The {0} field must be between {1} and {2}.")]
    public double Latitude { get; set; }
}
