using BabyTravel.Api.Client;
using BabyTravel.UI.Client.Extensions;
using BabyTravel.UI.Client.Models.Calculate.Responses;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace BabyTravel.UI.Client.Components.Calculate.Response
{
    public partial class FullSummaryCalculationList
    {
        [Parameter]
        public List<CalculateBabyTripResponse> Calculations { get; set; }

        private List<CalculateBabyTripResponse> _calculations = new();
        private List<CalculateBabyTripResponse> _calculationsToView = new();

        protected override void OnInitialized()
        {
            var fullSummary = Calculations.Summarize();

            _calculations.Add(fullSummary);
            _calculations.AddRange(Calculations);

            _calculationsToView = GetCalcuationsToView(0, 1);
        }

        private void PageChanged(PagerEventArgs args)
        {
            _calculationsToView = GetCalcuationsToView(args.Skip, args.Top);
        }

        private List<CalculateBabyTripResponse> GetCalcuationsToView(int skip, int take)
        {
            return _calculations.Skip(skip).Take(take).ToList();
        }
    }
}
