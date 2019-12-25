using Microsoft.AspNetCore.Components;
using Web1Apps.Services;

namespace Web1Apps.Pages
{
    public class LocationEditBase : ComponentBase
    {
        [Inject]
        public ILocationDataService LocationDataService { get; set; }

        [Parameter]
        public string LocationId { get; set; }

        public Location Location { get; set; } = new Location();
    }

    
}