using Farfetch.Domain.HttpServices;
using Farfetch.Domain.Models.Entities;
using Farfetch.Domain.Services.Contracts.Entities;
using Farfetch.Domain.Services.Contracts.Infra.Data.UoW;
using Farfetch.Domain.Services.Imp.Tasks;
using FluentAssertions;
using NSubstitute;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Farfetch.Tests
{
    public class OrderUnitTests
    {        
        private IUnitOfWork UnitOfWork { get; }
        private IToggleEntityService ToggleEntityService { get; }
        private IOrderEntityService OrderEntityService { get; }
        private IServiceRotaEntityService ServiceRotaEntityService { get; }
        private IServiceRotaToggleEntityService ServiceRotaToggleEntityService { get; }

        OrderServiceTask task;

        public OrderUnitTests()
        {
            UnitOfWork = Substitute.For<IUnitOfWork>();
            ToggleEntityService = Substitute.For<IToggleEntityService>();            
            OrderEntityService = Substitute.For<IOrderEntityService>();
            ServiceRotaEntityService = Substitute.For<IServiceRotaEntityService>();
            ServiceRotaToggleEntityService = Substitute.For<IServiceRotaToggleEntityService>();

            task = new OrderServiceTask(UnitOfWork, ToggleEntityService, OrderEntityService, ServiceRotaEntityService, ServiceRotaToggleEntityService);
        }

        #region [ Tasks ]

        private Task<HttpResult<List<Order>>> GetAll()
        {
            return task.GetAll();
        }

        private Task<HttpResult<Order>> Get(int id)
        {
            return task.Get(id);
        }

        #endregion

        #region [ Cenarios ]

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

        #endregion
    }
}
