using Farfetch.App.Messages;
using Farfetch.App.Services.Contracts;
using Farfetch.Domain.HttpServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Web.Filters;

namespace Web.Controllers
{
    [Route("api/[controller]/register")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderAppService OrderAppService { get; }

        public OrderController(IOrderAppService orderAppService)
        {
            OrderAppService = orderAppService;
        }

        [HttpPost()]        
        public async Task<HttpResult<OrderRegisterMessageResponse>> Register([FromBody] OrderRegisterMessageRequest request)
        {
            return await OrderAppService.Register(request);
        }
    }
}