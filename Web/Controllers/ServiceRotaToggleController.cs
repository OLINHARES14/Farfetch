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
    public class ServiceRotaToggleController : ControllerBase
    {
        private IServiceRotaToggleAppService ServiceRotaToggleAppService { get; }

        public ServiceRotaToggleController(IServiceRotaToggleAppService serviceRotaToggleAppService)
        {
            ServiceRotaToggleAppService = serviceRotaToggleAppService;
        }

        [HttpPost()]
        public async Task<HttpResult<ServiceRotaToggleMessageResponse>> Create([FromBody] ServiceRotaToggleCreateMessageRequest request)
        {
            return await ServiceRotaToggleAppService.Create(request);
        }

        [HttpGet()]
        public async Task<HttpResult<List<ServiceRotaToggleMessageResponse>>> GetAll()
        {
            return await ServiceRotaToggleAppService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<HttpResult<ServiceRotaToggleMessageResponse>> Get(int id)
        {
            return await ServiceRotaToggleAppService.Get(id);
        }

        [HttpPost("{id}")]
        public async Task<HttpResult<ServiceRotaToggleMessageResponse>> Update(int id, [FromBody] ServiceRotaToggleUpdateMessageRequest request)
        {
            return await ServiceRotaToggleAppService.Update(id, request);
        }

        [HttpDelete("{id}")]
        public async Task<HttpResult<ServiceRotaToggleMessageResponse>> Delete(int id)
        {
            return await ServiceRotaToggleAppService.Delete(id);
        }
    }
}