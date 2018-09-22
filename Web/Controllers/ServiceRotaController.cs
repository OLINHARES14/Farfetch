using Farfetch.App.Messages;
using Farfetch.App.Services.Contracts;
using Farfetch.Domain.HttpServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceRotaController : ControllerBase
    {
        private IServiceRotaAppService ServiceRotaAppService { get; }

        public ServiceRotaController(IServiceRotaAppService serviceRotaAppService)
        {
            ServiceRotaAppService = serviceRotaAppService;
        }

        [HttpPost()]
        public async Task<HttpResult<ServiceRotaMessageResponse>> Create([FromBody] ServiceRotaCreateMessageRequest request)
        {
            return await ServiceRotaAppService.Create(request);
        }

        [HttpGet()]
        public async Task<HttpResult<List<ServiceRotaMessageResponse>>> GetAll()
        {
            return await ServiceRotaAppService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<HttpResult<ServiceRotaMessageResponse>> Get(int id)
        {
            return await ServiceRotaAppService.Get(id);
        }

        [HttpPost("{id}")]
        public async Task<HttpResult<ServiceRotaMessageResponse>> Update(int id, [FromBody] ServiceRotaUpdateMessageRequest request)
        {
            return await ServiceRotaAppService.Update(id, request);
        }

        [HttpDelete("{id}")]
        public async Task<HttpResult<ServiceRotaMessageResponse>> Delete(int id)
        {
            return await ServiceRotaAppService.Delete(id);
        }
    }
}