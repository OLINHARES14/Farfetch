using Farfetch.Domain.HttpServices;
using Farfetch.Domain.Models.Entities;
using Farfetch.Domain.Services.Contracts.Entities;
using Farfetch.Domain.Services.Contracts.Infra.Data.UoW;
using Farfetch.Domain.Services.Imp.Tasks;
using Farfetch.Tests.ModelTests;
using FluentAssertions;
using NSubstitute;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Farfetch.Tests
{
    public class ServiceRotaToggleUnitTests
    {        
        private IUnitOfWork UnitOfWork { get; }
        private IServiceRotaToggleEntityService ServiceRotaToggleEntityService { get; }
        private IToggleEntityService ToggleEntityService { get; }

        ServiceRotaToggleServiceTask task;

        public ServiceRotaToggleUnitTests()
        {
            UnitOfWork = Substitute.For<IUnitOfWork>();
            ServiceRotaToggleEntityService = Substitute.For<IServiceRotaToggleEntityService>();
            ToggleEntityService = Substitute.For<IToggleEntityService>();

            task = new ServiceRotaToggleServiceTask(UnitOfWork, ToggleEntityService, ServiceRotaToggleEntityService);
        }

        #region [ Tasks ]

        private HttpResult<ServiceRotaToggle> Create(ServiceRotaToggle serviceRotaToggle, int toggleId)
        {   
            return task.Create(serviceRotaToggle, toggleId);
        }

        private Task<HttpResult<List<ServiceRotaToggle>>> GetAll()
        {
            return task.GetAll();
        }

        private Task<HttpResult<ServiceRotaToggle>> Get(int id)
        {
            return task.Get(id);
        }

        private Task<HttpResult<ServiceRotaToggle>> Update(int id, string rota, int toggleId)
        {
            return task.Update(id, rota, toggleId);
        }

        private Task<HttpResult<ServiceRotaToggle>> Delete(int id)
        {
            return task.Delete(id);
        }

        #endregion

        #region [ Cenarios ]

        [Fact]
        public ServiceRotaToggle Create_valido()
        {
            var toggleMock = ToggleMock.ToggleValido();
            var serviceRotaToggleMock = ServiceRotaToggleMock.ServiceRotaToggleValido();
            serviceRotaToggleMock.Id = 0;

            var retorno = Create(serviceRotaToggleMock, toggleMock.Id);
                        
            Assert.Equal(HttpStatusCode.Created, retorno.HttpStatusCode);

            return retorno.Response;
        }

        [Fact]
        public void GetAll_valido()
        {
            var retorno = GetAll();

            Assert.Equal(HttpStatusCode.OK, retorno.Result.HttpStatusCode);
        }
        
        [Fact]
        public void Get_invalido_id_zero()
        {
            var retorno = Get(0);

            Assert.Equal(HttpStatusCode.NotFound, retorno.Result.HttpStatusCode);
        }

        [Fact]
        public void Update_invalido_id_zero()
        {
            var serviceRotaToggle = Create_valido();

            var toggleMock = ToggleMock.ToggleValido();

            var retorno = Update(0, serviceRotaToggle.Rota, toggleMock.Id);

            Assert.Equal(HttpStatusCode.NotFound, retorno.Result.HttpStatusCode);
        }
        
        [Fact]
        public void Delete_invalido_id_zero()
        {
            var retorno = Delete(0);

            Assert.Equal(HttpStatusCode.NotFound, retorno.Result.HttpStatusCode);
        }

        #endregion
    }
}
