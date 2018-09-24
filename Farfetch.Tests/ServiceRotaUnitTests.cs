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
    public class ServiceRotaUnitTests
    {        
        private IUnitOfWork UnitOfWork { get; }
        private IServiceRotaEntityService ServiceRotaEntityService { get; }

        ServiceRotaServiceTask task;

        public ServiceRotaUnitTests()
        {
            UnitOfWork = Substitute.For<IUnitOfWork>();
            ServiceRotaEntityService = Substitute.For<IServiceRotaEntityService>();

            task = new ServiceRotaServiceTask(UnitOfWork, ServiceRotaEntityService);
        }

        #region [ Tasks ]

        private HttpResult<ServiceRota> Create(ServiceRota serviceRota, List<int> idsServiceRota)
        {   
            return task.Create(serviceRota);
        }

        private Task<HttpResult<List<ServiceRota>>> GetAll()
        {
            return task.GetAll();
        }

        private Task<HttpResult<ServiceRota>> Get(int id)
        {
            return task.Get(id);
        }

        private Task<HttpResult<ServiceRota>> Update(int id, string rota)
        {
            return task.Update(id, rota);
        }

        private Task<HttpResult<ServiceRota>> Delete(int id)
        {
            return task.Delete(id);
        }

        #endregion

        #region [ Cenarios ]

        [Fact]
        public ServiceRota Create_valido()
        {
            var serviceRotaMock = ServiceRotaMock.ServiceRotaValido();
            serviceRotaMock.Id = 0;

            var listaIdsServiceRotaMock = new List<int>();
            listaIdsServiceRotaMock.Add(ServiceRotaMock.ServiceRotaValido().Id);

            var retorno = Create(serviceRotaMock, listaIdsServiceRotaMock);

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
            var serviceRota = Create_valido();
            
            var retorno = Update(0, serviceRota.Rota);

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
