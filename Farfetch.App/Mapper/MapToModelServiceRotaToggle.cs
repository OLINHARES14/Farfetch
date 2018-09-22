using Farfetch.App.Messages;
using Farfetch.Domain.Models.Entities;
using System;

namespace Farfetch.App.Mapper
{
    public class MapToModelServiceRotaToggle
    {
        public static ServiceRotaToggle MapToModel(ServiceRotaToggleCreateMessageRequest request)
        {
            if (request == null) return new ServiceRotaToggle();

            return new ServiceRotaToggle
            {
                //Description = request.Description,
                //Flag = request.Flag,
                Active = true,
                CreationDate = DateTime.Now
            };
        }

        public static ServiceRotaToggle MapToModel(ServiceRotaToggleUpdateMessageRequest request)
        {
            if (request == null) return new ServiceRotaToggle();

            return new ServiceRotaToggle
            {
                Rota = request.Rota,
                //Flag = request.Flag
            };
        }
    }
}
