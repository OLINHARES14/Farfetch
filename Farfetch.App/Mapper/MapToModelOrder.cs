using Farfetch.App.Messages;
using Farfetch.Domain.Models.Entities;
using System;

namespace Farfetch.App.Mapper
{
    public class MapToModelOrder
    {
        public static Order MapToModel(OrderRegisterMessageRequest request)
        {
            if (request == null) return new Order();

            return new Order
            {
                //Rota = request.,                
                CreationDate = DateTime.Now
            };
        }
    }
}
