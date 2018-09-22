using Farfetch.Domain.HttpServices;
using Farfetch.Domain.Models.Entities;
using Farfetch.Domain.Services.Contracts.Entities;
using Farfetch.Domain.Services.Contracts.Infra.Data.UoW;
using Farfetch.Domain.Services.Imp.Tasks;
using FluentAssertions;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Farfetch.Tests
{
    public class FarfetchUnitTests
    {        
        private IUnitOfWork UnitOfWork { get; }
        private IToggleEntityService ToggleEntityService { get; }
        private IServiceRotaEntityService ServiceRotaEntityService { get; }

        ToggleServiceTask task;

        public FarfetchUnitTests()
        {
            UnitOfWork = Substitute.For<IUnitOfWork>();
            ToggleEntityService = Substitute.For<IToggleEntityService>();
            ServiceRotaEntityService = Substitute.For<IServiceRotaEntityService>();

            task = new ToggleServiceTask(UnitOfWork, ToggleEntityService, ServiceRotaEntityService);
        }

        #region [ Tasks ]

        private HttpResult<Toggle> Create(Toggle toggle)
        {   
            return task.Create(toggle, null); //TODO: Verificar Ids
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
            return task.Update(id, description, flag, null); ; //TODO: Verificar Ids
        }

        private Task<HttpResult<Toggle>> Delete(int id)
        {
            return task.Delete(id);
        }

        #endregion

        #region [ Cenarios ]

        [Fact]
        public Toggle Create_valido()
        {
            var toggleMock = ModelTests.Models.MockToggleValido();
            var retorno = Create(toggleMock);

            retorno.HttpStatusCode.Should().Equals(HttpStatusCode.Created);

            return retorno.Response;
        }

        [Fact]
        public void GetAll_valido()
        {
            var retorno = GetAll();

            retorno.Result.HttpStatusCode.Should().Equals(HttpStatusCode.OK);
        }

        [Fact]
        public void Get_valido()
        {
            var toggle = Create_valido();

            var retorno = Get(toggle.Id);

            retorno.Result.HttpStatusCode.Should().Equals(HttpStatusCode.OK);
        }

        [Fact]
        public void Get_invalido_id_zero()
        {
            var retorno = Get(0);

            retorno.Result.HttpStatusCode.Should().Equals(HttpStatusCode.NotFound);
        }

        [Fact]
        public void Update_valido()
        {
            var toggle = Create_valido();

            var retorno = Update(toggle.Id, toggle.Description, toggle.Flag);

            retorno.Result.HttpStatusCode.Should().Equals(HttpStatusCode.OK);
        }

        [Fact]
        public void Update_invalido_id_zero()
        {
            var toggle = Create_valido();

            var retorno = Update(0, toggle.Description, toggle.Flag);

            retorno.Result.HttpStatusCode.Should().Equals(HttpStatusCode.NotFound);
        }

        [Fact]
        public void Delete_valido() 
        {
            var toggle = Create_valido();

            var retorno = Delete(toggle.Id);

            retorno.Result.HttpStatusCode.Should().Equals((HttpStatusCode)204);
        }

        [Fact]
        public void Delete_invalido_id_zero()
        {
            var retorno = Delete(0);

            retorno.Result.HttpStatusCode.Should().Equals(HttpStatusCode.NotFound);
        }

        #endregion
    }
}
