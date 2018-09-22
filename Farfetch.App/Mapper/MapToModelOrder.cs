using Farfetch.App.Messages;
using Farfetch.Domain.Models.Entities;
using Farfetch.Infra.Cross.Helpers;

namespace Farfetch.App.Mapper
{
    public class MapToModelOrder
    {
        public static Order MapToModel(OrderRegisterMessageRequest request)
        {
            if (request == null) return new Order();

            return new Order
            {
                Protocol = request.GetHeader(ServiceConstants.PROTOCOL),
                DescriptionProduto = request.DescriptionProduto
            };
        }
    }
}
