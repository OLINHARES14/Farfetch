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
    public class FarfetchIntegrationTests
    {
        private IUnitOfWork UnitOfWork { get; }
        private IToggleEntityService ToggleEntityService { get;  }
        private IServiceRotaEntityService ServiceRotaEntityService { get; }

        ToggleServiceTask task;

        public FarfetchIntegrationTests()
        {
            UnitOfWork = Substitute.For<IUnitOfWork>();
            ToggleEntityService = Substitute.For<IToggleEntityService>();
            ServiceRotaEntityService = Substitute.For<IServiceRotaEntityService>();

            task = new ToggleServiceTask(UnitOfWork, ToggleEntityService, ServiceRotaEntityService);
        }

        #region [ Tasks ]

        private HttpResult<Toggle> Create(Toggle toggle)
        {
            return task.Create(toggle, null); //TODO: Verificar os ids
        }

        private Task<HttpResult<List<Toggle>>> GetAll()
        {
            return task.GetAll();
        }

        private Task<HttpResult<Toggle>> Get(int id)
        {
            return task.Get(id);
        }

        private Task<HttpResult<Toggle>> Update(int id, string description, bool flag)
        {
            return task.Update(id ,description, flag, null); //TODO: Verificar os ids
        }

        private Task<HttpResult<Toggle>> Delete(int id)
        {
            return task.Delete(id);
        }

        #endregion

        [Fact]
        public void Update_toggle_valido()
        {
            var toggleMock = ModelTests.Models.MockToggleValido();

            var retornoCreate = Create(toggleMock);
            var id = retornoCreate.Response.Id;
            var retornoGet = Get(id);
            var retornoPay = Update(id, retornoCreate.Response.Description, retornoCreate.Response.Flag );

            retornoPay.Result.HttpStatusCode.Should().Equals(HttpStatusCode.OK);
        }

        [Fact]
        public void Delete_toggle_valido()
        {
            var toggleMock = ModelTests.Models.MockToggleValido();

            var retornoCreate = Create(toggleMock);
            var id = retornoCreate.Response.Id;
            var retornoGetAll = GetAll();
            var retornoCancel = Delete(id);
                        
            retornoCancel.Result.HttpStatusCode.Should().Equals((HttpStatusCode)204);
        }
    }
}
