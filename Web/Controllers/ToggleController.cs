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
    public class ToggleController : ControllerBase
    {
        private IToggleAppService ToggleAppService { get; }

        public ToggleController(IToggleAppService toggleAppService)
        {
            ToggleAppService = toggleAppService;
        }

        [HttpPost()]
        public async Task<HttpResult<ToggleMessageResponse>> Create([FromBody] CreateToggleMessageRequest request)
        {
            return await ToggleAppService.Create(request);
        }

        [HttpGet()]
        public async Task<HttpResult<List<ToggleMessageResponse>>> GetAll()
        {
            return await ToggleAppService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<HttpResult<ToggleMessageResponse>> Get(int id)
        {
            return await ToggleAppService.Get(id);
        }

        [HttpPost("{id}")]
        public async Task<HttpResult<ToggleMessageResponse>> Update(int id, [FromBody] UpdateToggleMessageRequest request)
        {
            return await ToggleAppService.Update(id, request);
        }

        [HttpDelete("{id}")]
        public async Task<HttpResult<ToggleMessageResponse>> Delete(int id)
        {
            return await ToggleAppService.Delete(id);
        }
    }
}