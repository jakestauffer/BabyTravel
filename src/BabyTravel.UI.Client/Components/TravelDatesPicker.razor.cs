using Microsoft.AspNetCore.Components;
using BabyTravel.UI.Client.Models.Calculate.Forms;

namespace BabyTravel.UI.Client.Components
{
    public partial class TravelDatesPicker<TRequestForm>
            where TRequestForm : class, IWithTravelDates, new()
    {
        [Parameter]
        public TRequestForm RequestForm { get; set; }
    }
}
