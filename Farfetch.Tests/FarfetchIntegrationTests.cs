using Farfetch.Domain.HttpServices;
using Farfetch.Domain.Models.Entities;
using Farfetch.Domain.Services.Contracts.Entities;
using Farfetch.Domain.Services.Contracts.Infra.Data.UoW;
using Farfetch.Domain.Services.Imp.Tasks;
using Farfetch.Infra.Cross.Helpers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Farfetch.Tests
{
    public class FarfetchIntegrationTests
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IToggleEntityService _toggleEntityService;

        ToggleServiceTask task;

        public FarfetchIntegrationTests()
        {
            _unitOfWork = Substitute.For<IUnitOfWork>();
            _toggleEntityService = Substitute.For<IToggleEntityService>();

            task = new ToggleServiceTask(_unitOfWork, _toggleEntityService);
        }

        #region [ Tasks ]

        private HttpResult<Toggle> Create(Toggle toggle)
        {
            return task.Create(toggle);
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
            return task.Update(id ,description, flag);
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
