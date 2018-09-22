using Farfetch.Domain.HttpServices;
using Farfetch.Domain.Models.Entities;
using Farfetch.Domain.Services.Contracts.Infra.Data.UoW;
using Farfetch.Domain.Services.Contracts.Tasks;
using Farfetch.Domain.Services.Imp.Entities.Base;

namespace Farfetch.Domain.Services.Imp.Tasks
{
    public class OrderServiceTask : BaseService, IOrderServiceTask
    {
        public OrderServiceTask(IUnitOfWork unitOfWork
            ) : base(unitOfWork)
        {            
            //ToggleEntityService = toggleEntityService;
        }

        public HttpResult<Order> Register(Order order)
        {
            var retorno = new HttpResult<Order>();
            
            _dbContext.Context.Order.Add(order);

            _dbContext.SaveChanges();

            retorno.Response = order;
            retorno.SetHttpStatusToCreated();

            return retorno;
        }

        //public async Task<HttpResult<List<Toggle>>> GetAll()
        //{
        //    var retorno = new HttpResult<List<Toggle>>();
        //    retorno.Response = new List<Toggle>();

        //    var retornotoggleGetAll = ToggleEntityService.GetAll();

        //    if (retornotoggleGetAll != null && retornotoggleGetAll.Result != null)
        //    {
        //        retorno.Response.AddRange(retornotoggleGetAll.Result);
        //    }
            
        //    retorno.SetHttpStatusToOk();

        //    return retorno;
        //}

        //public async Task<HttpResult<Toggle>> Get(int id)
        //{
        //    var retorno = new HttpResult<Toggle>();

        //    var retornoToggleGet = await ToggleEntityService.Get(id);

        //    if (retornoToggleGet == null) return retorno.SetHttpStatusToNotFound();

        //    retorno.Response = retornoToggleGet;
        //    retorno.SetHttpStatusToOk();

        //    return retorno;
        //}

        //public async Task<HttpResult<Toggle>> Update(int id, string description, bool flag)
        //{
        //    var retorno = new HttpResult<Toggle>();

        //    var retornoToggleGet = await ToggleEntityService.Get(id);

        //    if (retornoToggleGet == null) return retorno.SetHttpStatusToNotFound();

        //    retornoToggleGet.Description = description;
        //    retornoToggleGet.Flag = flag;

        //    _dbContext.SaveChanges();

        //    retorno.Response = retornoToggleGet;
        //    retorno.SetHttpStatusToOk();

        //    return retorno;
        //}

        //public async Task<HttpResult<Toggle>> Delete(int id)
        //{
        //    var retorno = new HttpResult<Toggle>();

        //    var retornoToggleGet = await ToggleEntityService.Get(id);

        //    if (retornoToggleGet == null) return retorno.SetHttpStatusToNotFound();

        //    retornoToggleGet.Active = false;

        //    _dbContext.SaveChanges();

        //    retorno.Response = retornoToggleGet;
        //    retorno.Set((HttpStatusCode)204, "Toggle delete");

        //    return retorno;
        //}
    }
}
