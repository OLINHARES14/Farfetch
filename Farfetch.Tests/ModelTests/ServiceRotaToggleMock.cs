using Farfetch.Domain.Models.Entities;

namespace Farfetch.Tests.ModelTests
{
    public class ServiceRotaToggleMock
    {
        public static ServiceRotaToggle ServiceRotaToggleValido()
        {
            return new ServiceRotaToggle
            {
                Id = 1,
                Toggle = ToggleMock.ToggleValido(),
                Rota = "/api/service/mock",
                Active = true 
            };
        }
    }
}
