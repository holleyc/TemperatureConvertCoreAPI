using System;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.Extensions.Options;
using TempConvert.Interfaces;
using TempConvert.Models;

namespace TempConvert.Repositories
{
    public class TempConvertRepository : ITempConvertRepository
    {
        private readonly ITempConvertChannel _proxy;

        public TempConvertRepository(IOptions<ClientConfig> config)
        {
            var cfg = config.Value;

            /*
             * Create & Configure Client
             */
            var binding = new BasicHttpBinding
            {
                SendTimeout = TimeSpan.FromSeconds(cfg.Timeout),
                MaxBufferSize = int.MaxValue,
                MaxReceivedMessageSize = int.MaxValue,
                AllowCookies = true,
                ReaderQuotas = XmlDictionaryReaderQuotas.Max
            };
            binding.Security.Mode = BasicHttpSecurityMode.Transport;
            var address = new EndpointAddress(cfg.Url);
            var factory = new ChannelFactory<ITempConvertChannel>(binding, address);
            _proxy = factory.CreateChannel();
        }

        public async Task<string> FahrenheitToCelsiusAsync(string fahrenheit)
        {
            return await _proxy.FahrenheitToCelsiusAsync(fahrenheit);
        }

        public async Task<string> CelsiusToFahrenheitAsync(string celsius)
        {
            return await _proxy.CelsiusToFahrenheitAsync(celsius);
        }
    }
}