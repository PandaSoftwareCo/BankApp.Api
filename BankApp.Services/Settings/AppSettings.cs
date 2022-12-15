using BankApp.Application.Interfaces;

namespace BankApp.Services.Settings
{
    public class AppSettings : IAppSettings
    {
        public string Secret { get; set; }
    }
}
