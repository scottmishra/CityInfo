using System.Diagnostics;
using CityInfo.Services.Interfaces;

namespace CityInfo.Services
{
    /// <summary>
    /// Simple mail service to act as an example service
    /// </summary>
    public class LocalMailService : IMailService
    {
        private readonly string _toMailAddress = Startup.ConfigurationRoot["mailSettings:mailToAddress"];
        private string _fromMailAddress = Startup.ConfigurationRoot["mailSettings:mailFromAddress"];

        public void Send(string subject, string message)
        {
            Debug.WriteLine($"calling mail send service with {subject} and {message}, {_toMailAddress}");
        }
    }
}