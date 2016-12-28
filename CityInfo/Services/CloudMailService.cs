using System.Diagnostics;
using CityInfo.Services.Interfaces;

namespace CityInfo.Services
{
    /// <summary>
    /// Simple mail service implementation to be used with a cloud server
    /// </summary>
    public class CloudMailService : IMailService
    {

        private readonly string _toMailAddress = Startup.ConfigurationRoot["mailSettings:mailToAddress"];
        private string _fromMailAddress = Startup.ConfigurationRoot["mailSettings:mailFromAddress"];
        
        public void Send(string subject, string message)
        {
            Debug.WriteLine("Calling the cloud mail service");
        }
    }
}