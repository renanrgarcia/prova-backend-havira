using Havira.Business.Models.ContextFeature.Enums;
using static Havira.Business.Models.ContextFeature.Feature;

namespace Havira.Application.ViewModel.ContextFeature;

public class GetFeatureViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Category Category { get; set; }
    public GeoJsonPoint Point { get; set; }
}
