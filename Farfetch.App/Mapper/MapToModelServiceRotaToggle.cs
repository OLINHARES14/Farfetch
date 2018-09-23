using Farfetch.App.Messages;
using Farfetch.Domain.Models.Entities;

namespace Farfetch.App.Mapper
{
    public class MapToModelServiceRotaToggle
    {
        public static ServiceRotaToggle MapToModel(ServiceRotaToggleCreateMessageRequest request)
        {
            if (request == null) return new ServiceRotaToggle();

            return new ServiceRotaToggle
            {
                Rota = request.Rota,
                Active = true,
            };
        }

        public static ServiceRotaToggle MapToModel(ServiceRotaToggleUpdateMessageRequest request)
        {
            if (request == null) return new ServiceRotaToggle();

            return new ServiceRotaToggle
            {
                Rota = request.Rota
            };
        }
    }
}
