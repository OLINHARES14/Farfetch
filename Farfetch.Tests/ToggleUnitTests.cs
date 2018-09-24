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
using Xunit;

namespace Farfetch.Tests
{
    public class ToggleUnitTests
    {        
        private IUnitOfWork UnitOfWork { get; }
        private IToggleEntityService ToggleEntityService { get; }
        private IServiceRotaEntityService ServiceRotaEntityService { get; }

        ToggleServiceTask task;

        public ToggleUnitTests()
        {
            UnitOfWork = Substitute.For<IUnitOfWork>();
            ToggleEntityService = Substitute.For<IToggleEntityService>();
            ServiceRotaEntityService = Substitute.For<IServiceRotaEntityService>();

            task = new ToggleServiceTask(UnitOfWork, ToggleEntityService, ServiceRotaEntityService);
        }

        #region [ Tasks ]

        private HttpResult<Toggle> Create(Toggle toggle, List<int> idsServiceRota)
        {   
            return task.Create(toggle, idsServiceRota);
        }

        //private Task<HttpResult<List<Toggle>>> GetAll()
        //{
        //    return task.GetAll();
        //}

        //private Task<HttpResult<Toggle>> Get(int id)
        //{
        //    return task.Get(id);
        //}

        //private Task<HttpResult<Toggle>> Update(int id, string description, bool flag, List<int> idsServiceRota)
        //{
        //    return task.Update(id, description, flag, idsServiceRota);
        //}

        //private Task<HttpResult<Toggle>> Delete(int id)
        //{
        //    return task.Delete(id);
        //}

        #endregion

        #region [ Cenarios ]

        [Fact]
        public Toggle Create_valido()
        {
            var toggleMock = ToggleMock.ToggleValido();
            toggleMock.Id = 0;

            var listaIdsServiceRotaMock = new List<int>();
            listaIdsServiceRotaMock.Add(ToggleServiceRotaMock.ToggleServiceRotaValido().Id);

            var retorno = Create(toggleMock, listaIdsServiceRotaMock);

            retorno.HttpStatusCode.Should().Equals(HttpStatusCode.Created);

            return retorno.Response;
        }

        //[Fact]
        //public void GetAll_valido()
        //{
        //    var retorno = GetAll();

        //    retorno.Result.HttpStatusCode.Should().Equals(HttpStatusCode.OK);
        //}

        //[Fact]
        //public void Get_valido()
        //{
        //    var toggle = Create_valido();

        //    var retorno = Get(toggle.Id);

        //    retorno.Result.HttpStatusCode.Should().Equals(HttpStatusCode.OK);
        //}

        //[Fact]
        //public void Get_invalido_id_zero()
        //{
        //    var retorno = Get(0);

        //    retorno.Result.HttpStatusCode.Should().Equals((HttpStatusCode)422);
        //}

        //[Fact]
        //public void Update_valido()
        //{
        //    var toggle = Create_valido();

        //    var listaIdsServiceRotaMock = new List<int>();
        //    listaIdsServiceRotaMock.Add(toggle.ToggleServiceRotas.FirstOrDefault().Id);

        //    var retorno = Update(toggle.Id, toggle.Description, toggle.Flag, listaIdsServiceRotaMock);

        //    retorno.Result.HttpStatusCode.Should().Equals(HttpStatusCode.OK);
        //}

        //[Fact]
        //public void Update_invalido_id_zero()
        //{
        //    var toggle = Create_valido();

        //    var listaIdsServiceRotaMock = new List<int>();
        //    listaIdsServiceRotaMock.Add(toggle.ToggleServiceRotas.FirstOrDefault().Id);

        //    var retorno = Update(0, toggle.Description, toggle.Flag, listaIdsServiceRotaMock);

        //    retorno.Result.HttpStatusCode.Should().Equals((HttpStatusCode)422);
        //}

        //[Fact]
        //public void Delete_valido() 
        //{
        //    var toggle = Create_valido();

        //    var retorno = Delete(toggle.Id);

        //    retorno.Result.HttpStatusCode.Should().Equals(HttpStatusCode.OK);
        //}

        //[Fact]
        //public void Delete_invalido_id_zero()
        //{
        //    var retorno = Delete(0);

        //    retorno.Result.HttpStatusCode.Should().Equals((HttpStatusCode)422);
        //}

        #endregion
    }
}
