using Farfetch.Domain.HttpServices;
using Farfetch.Domain.Models.Entities;
using Farfetch.Domain.Services.Contracts.Entities;
using Farfetch.Domain.Services.Contracts.Infra.Data.UoW;
using Farfetch.Domain.Services.Imp.Tasks;
using Farfetch.Tests.ModelTests;
using NSubstitute;
using System.Collections.Generic;
using System.Net;
using Xunit;

namespace Farfetch.Tests
{
    public class FarfetchIntegrationTests
    {
        private IUnitOfWork UnitOfWork { get; }
        private IToggleEntityService ToggleEntityService { get; }
        private IServiceRotaEntityService ServiceRotaEntityService { get; }
        private IServiceRotaToggleEntityService ServiceRotaToggleEntityService { get; }

        ToggleServiceTask taskToggle;
        ServiceRotaToggleServiceTask taskServiceRota;

        public FarfetchIntegrationTests()
        {
            UnitOfWork = Substitute.For<IUnitOfWork>();
            ToggleEntityService = Substitute.For<IToggleEntityService>();
            ServiceRotaEntityService = Substitute.For<IServiceRotaEntityService>();
            ServiceRotaToggleEntityService = Substitute.For<IServiceRotaToggleEntityService>();

            taskToggle = new ToggleServiceTask(UnitOfWork, ToggleEntityService, ServiceRotaEntityService);
            taskServiceRota = new ServiceRotaToggleServiceTask(UnitOfWork, ToggleEntityService, ServiceRotaToggleEntityService);
        }
               
        #region [ Tasks ]

        private HttpResult<Toggle> CreateToggle(Toggle toggle, List<int> idsServiceRota)
        {
            return taskToggle.Create(toggle, idsServiceRota);
        }

        private HttpResult<ServiceRotaToggle> CreateServiceRotaToggle(ServiceRotaToggle serviceRotaToggle, int toggleId)
        {
            return taskServiceRota.Create(serviceRotaToggle, toggleId);
        }

        #endregion

        [Fact]
        public void Configurar_novo_toggle_na_service_rota_toggle_valido()
        {   
            var retornoCreateToggle = CreateToggle(ToggleMock.ToggleValido(), new List<int>() {2});
            var retornoCreateServiceRotaToggle = CreateServiceRotaToggle(ServiceRotaToggleMock.ServiceRotaToggleValido(), retornoCreateToggle.Response.Id);

            Assert.Equal(HttpStatusCode.Created, retornoCreateServiceRotaToggle.HttpStatusCode);
        }
    }
}
