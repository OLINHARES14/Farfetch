using Farfetch.Domain.Models.Entities;

namespace Farfetch.Tests.ModelTests
{
    public class ToggleServiceRotaMock
    {
        public static ToggleServiceRota ToggleServiceRotaValido()
        {
            var serviceRotaMock = ServiceRotaMock.ServiceRotaValido();
            var toggleMock = ToggleMock.ToggleValido();

            return new ToggleServiceRota
            {
                Id = 1,
                ServiceRota = serviceRotaMock,
                ServiceRotaId = serviceRotaMock.Id,                
                Toggle  = toggleMock,
                ToggleId = toggleMock.Id
            };
        }
    }
}
