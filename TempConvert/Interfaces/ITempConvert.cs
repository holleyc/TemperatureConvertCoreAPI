using System.ServiceModel;
using System.Threading.Tasks;

namespace TempConvert.Interfaces
{
    [ServiceContract(
        Namespace = "https://www.w3schools.com/xml/",
        ConfigurationName = "TempConvert.Interfaces.ITempConvert")]
    public interface ITempConvert
    {
        [OperationContract(
            Action = "https://www.w3schools.com/xml/FahrenheitToCelsius", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        Task<string> FahrenheitToCelsiusAsync(string Fahrenheit);

        [OperationContract(
            Action = "https://www.w3schools.com/xml/CelsiusToFahrenheit", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        Task<string> CelsiusToFahrenheitAsync(string Celsius);
    }
}