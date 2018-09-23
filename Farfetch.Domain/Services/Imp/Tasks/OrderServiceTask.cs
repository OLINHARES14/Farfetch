using Farfetch.Domain.HttpServices;
using Farfetch.Domain.Models.Entities;
using Farfetch.Domain.Services.Contracts.Entities;
using Farfetch.Domain.Services.Contracts.Infra.Data.UoW;
using Farfetch.Domain.Services.Contracts.Tasks;
using Farfetch.Domain.Services.Imp.Entities.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Farfetch.Domain.Services.Imp.Tasks
{
    public class OrderServiceTask : BaseService, IOrderServiceTask
    {
        private IToggleEntityService ToggleEntityService { get; }
        private IOrderEntityService OrderEntityService { get; }
        private IServiceRotaEntityService ServiceRotaEntityService { get; }
        private IServiceRotaToggleEntityService ServiceRotaToggleEntityService { get; }

        public OrderServiceTask(IUnitOfWork unitOfWork,
            IToggleEntityService toggleEntityService,
            IOrderEntityService orderEntityService,
            IServiceRotaEntityService serviceRotaEntityService,
            IServiceRotaToggleEntityService serviceRotaToggleEntityService
            ) : base(unitOfWork)
        {            
            ToggleEntityService = toggleEntityService;
            OrderEntityService = orderEntityService;
            ServiceRotaEntityService = serviceRotaEntityService;
            ServiceRotaToggleEntityService = serviceRotaToggleEntityService;
        }

        public HttpResult<Order> Register(Order order, string authorization, string rota)
        {
            var retorno = new HttpResult<Order>();

            var retornoServiceRotaToggleGetAll = ServiceRotaToggleEntityService.GetAll().Result.Where(x => x.Rota == rota).FirstOrDefault();
            if (retornoServiceRotaToggleGetAll == null) return retorno.SetHttpStatusToNotFound();

            var retornoServiceRotaGetAll = ServiceRotaEntityService.GetAll().Result.Where(x => x.Authorization == authorization).FirstOrDefault();
            if (retornoServiceRotaGetAll == null) return retorno.SetHttpStatusToNotFound();
            
            order.DescriptionToggle = retornoServiceRotaToggleGetAll.Toggle.Description;
            order.DescriptionServiceRota = retornoServiceRotaGetAll.Rota;

            _dbContext.Context.Order.Add(order);

            _dbContext.SaveChanges();

            retorno.Response = order;
            retorno.SetHttpStatusToCreated();

            return retorno;
        }

        public async Task<HttpResult<List<Order>>> GetAll()
        {
            var retorno = new HttpResult<List<Order>>();
            retorno.Response = new List<Order>();

            var retornoOrderGetAll = OrderEntityService.GetAll();
            if (retornoOrderGetAll != null && retornoOrderGetAll.Result != null)
            {
                retorno.Response.AddRange(retornoOrderGetAll.Result);
            }

            retorno.SetHttpStatusToOk();

            return retorno;
        }

        public async Task<HttpResult<Order>> Get(int id)
        {
            var retorno = new HttpResult<Order>();

            var retornoOrderGet = await OrderEntityService.Get(id);
            if (retornoOrderGet == null) return retorno.SetHttpStatusToNotFound();

            retorno.Response = retornoOrderGet;
            retorno.SetHttpStatusToOk();

            return retorno;
        }
    }
}
