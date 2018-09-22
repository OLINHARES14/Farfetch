using Farfetch.Domain.HttpServices;
using Farfetch.Domain.Models.Entities;
using Farfetch.Domain.Services.Contracts.Entities;
using Farfetch.Domain.Services.Contracts.Infra.Data.UoW;
using Farfetch.Domain.Services.Contracts.Tasks;
using Farfetch.Domain.Services.Imp.Entities.Base;
using System.Linq;

namespace Farfetch.Domain.Services.Imp.Tasks
{
    public class OrderServiceTask : BaseService, IOrderServiceTask
    {
        private IToggleEntityService ToggleEntityService { get; }
        private IServiceRotaEntityService ServiceRotaEntityService { get; }
        private IServiceRotaToggleEntityService ServiceRotaToggleEntityService { get; }

        public OrderServiceTask(IUnitOfWork unitOfWork,
            IToggleEntityService toggleEntityService,
            IServiceRotaEntityService serviceRotaEntityService,
            IServiceRotaToggleEntityService serviceRotaToggleEntityService
            ) : base(unitOfWork)
        {            
            ToggleEntityService = toggleEntityService;
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
    }
}
