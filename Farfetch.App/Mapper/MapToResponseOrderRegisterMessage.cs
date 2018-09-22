using Farfetch.App.Messages;
using Farfetch.Domain.Models.Entities;
using System.Collections.Generic;

namespace Farfetch.App.Mapper
{
    public class MapToResponseOrderRegisterMessage
    {
        public static List<OrderRegisterMessageResponse> MapToListOrderRegisterMessageResponse(List<Order> orders)
        {
            var lista = new List<OrderRegisterMessageResponse>();

            foreach (var order in orders)
                lista.Add(MapToOrderRegisterMessageResponse(order));

            return lista;
        }

        public static OrderRegisterMessageResponse MapToOrderRegisterMessageResponse(Order order)
        {
            if (order == null) return new OrderRegisterMessageResponse();

            return new OrderRegisterMessageResponse
            {
                Id = order.Id
                //Description = toggle.Description,
                //Flag = toggle.Flag,
                //Active = order.Active                
            };
        }
    }
}
