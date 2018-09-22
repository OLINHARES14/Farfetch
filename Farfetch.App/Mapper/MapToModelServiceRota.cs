using Farfetch.App.Messages;
using Farfetch.Domain.Models.Entities;

namespace Farfetch.App.Mapper
{
    public class MapToModelServiceRota
    {
        public static ServiceRota MapToModel(ServiceRotaCreateMessageRequest request)
        {
            if (request == null) return new ServiceRota();

            return new ServiceRota
            {   
                Authorization = null, //TODO: Pegar do contexto
                Rota = request.Rota,
                ToggleServiceRotas = null, //TODO: Não sei
                Active = true,
            };
        }

        public static ServiceRota MapToModel(ServiceRotaUpdateMessageRequest request)
        {
            if (request == null) return new ServiceRota();

            return new ServiceRota
            {
                Authorization = null, //TODO: Pegar do contexto
                Rota = request.Rota,
                ToggleServiceRotas = null //TODO: Não sei
            };
        }
    }
}
