//using Farfetch.Domain.HttpServices;
//using Farfetch.Domain.Models.Entities;
//using Farfetch.Domain.Services.Contracts.Entities;
//using Farfetch.Domain.Services.Contracts.Infra.Data.UoW;
//using Farfetch.Domain.Services.Imp.Tasks;
//using Farfetch.Tests.ModelTests;
//using FluentAssertions;
//using NSubstitute;
//using System.Collections.Generic;
//using System.Net;
//using System.Threading.Tasks;
//using Xunit;

//namespace Farfetch.Tests
//{
//    public class FarfetchIntegrationTests
//    {
//        private IUnitOfWork UnitOfWork { get; }
//        private IToggleEntityService ToggleEntityService { get;  }
//        private IServiceRotaEntityService ServiceRotaEntityService { get; }

//        ToggleServiceTask task;

//        public FarfetchIntegrationTests()
//        {
//            UnitOfWork = Substitute.For<IUnitOfWork>();
//            ToggleEntityService = Substitute.For<IToggleEntityService>();
//            ServiceRotaEntityService = Substitute.For<IServiceRotaEntityService>();

//            task = new ToggleServiceTask(UnitOfWork, ToggleEntityService, ServiceRotaEntityService);
//        }

//        #region [ Tasks ]


//        private HttpResult<Toggle> Create(Toggle toggle, List<int> idsServiceRota)
//        {
//            return task.Create(toggle, idsServiceRota);
//        }

//        private Task<HttpResult<List<Toggle>>> GetAll()
//        {
//            return task.GetAll();
//        }

//        private Task<HttpResult<Toggle>> Get(int id)
//        {
//            return task.Get(id);
//        }

//        private Task<HttpResult<Toggle>> Update(int id, string description, bool flag, List<int> idsServiceRota)
//        {
//            return task.Update(id, description, flag, idsServiceRota);
//        }

//        private Task<HttpResult<Toggle>> Delete(int id)
//        {
//            return task.Delete(id);
//        }

//        #endregion

//        [Fact]
//        public void Register_order_valido()
//        {
//            var toggleMock = ModelTests.ToggleMock.ToggleValido();

//            var listaIdsServiceRotaMock = new List<int>();
//            listaIdsServiceRotaMock.Add(ToggleServiceRotaMock.ToggleServiceRotaValido().Id);

//            var retornoCreate = Create(toggleMock, listaIdsServiceRotaMock);
//            var id = retornoCreate.Response.Id;
//            var retornoGet = Get(id);
//            var retornoPay = Update(id, retornoCreate.Response.Description, retornoCreate.Response.Flag, listaIdsServiceRotaMock);

//            retornoPay.Result.HttpStatusCode.Should().Equals(HttpStatusCode.OK);
//        }
//    }
//}
