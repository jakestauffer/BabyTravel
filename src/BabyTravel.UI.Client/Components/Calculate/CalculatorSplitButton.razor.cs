using Microsoft.AspNetCore.Components;
using Radzen.Blazor;

namespace BabyTravel.UI.Client.Components.Calculate
{
    public partial class CalculatorSplitButton
    {
        private string? _calculation = null;

        private string _title => $"{_calculation} Calculator";

        private bool _openDialog => _calculation != null;

        private RadzenSplitButton _splitButton = new();

        private void OnCalculateSplitButtonClick(RadzenSplitButtonItem? item)
        {
            _calculation = item?.Value ?? "General";
        }
    }
}
