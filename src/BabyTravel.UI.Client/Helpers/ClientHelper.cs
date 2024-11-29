using BabyTravel.Api.Client;
using Radzen;

namespace BabyTravel.UI.Client.Helpers
{
    public class ClientHelper
    {
        private readonly NotificationService _notificationService;

        public ClientHelper(NotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public async Task ExecuteAndNotifyErrorsOnlyAsync(Func<Task> func)
        {
            try
            {
                await func();
            }
            catch (ApiException<ErrorResponse> ex)
            {
                _notificationService.Notify(NotificationSeverity.Error, summary: "Error", detail: ex.Result.Message);
            }
            catch (ApiException ex)
            {
                _notificationService.Notify(new NotificationMessage()
                {
                    Severity = NotificationSeverity.Error,
                    Summary = "Error",
                    Detail = ex.Message
                });
            }
            catch (Exception ex)
            {
                _notificationService.Notify(NotificationSeverity.Error, summary: "Error", detail: $"Unexpected error: {ex.Message}");
            }
        }

        public async Task ExecuteAndNotifySuccessAndErrorsAsync(Func<Task> func)
        {
            try
            {
                await func();

                _notificationService.Notify(NotificationSeverity.Success, "Success");
            }
            catch (ApiException<ErrorResponse> ex)
            {
                _notificationService.Notify(NotificationSeverity.Error, summary: "Error", detail: ex.Result.Message);
            }
            catch (ApiException ex)
            {
                _notificationService.Notify(new NotificationMessage()
                {
                    Severity = NotificationSeverity.Error,
                    Summary = "Error",
                    Detail = ex.Message
                });
            }
            catch (Exception ex)
            {
                _notificationService.Notify(NotificationSeverity.Error, summary: "Error", detail: $"Unexpected error: {ex.Message}");
            }
        }
    }
}
