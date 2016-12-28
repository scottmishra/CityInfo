namespace CityInfo.Services.Interfaces
{
    /// <summary>
    /// Interface for defining the methods of interaction for different mail services
    /// </summary>
    public interface IMailService
    {
        void Send(string subject, string message);
    }
}