using Farfetch.App.Messages;
using Farfetch.Domain.Models.Entities;
using System.Collections.Generic;

namespace Farfetch.App.Mapper
{
    public class MapToResponseServiceRotaMessage
    {
        public static List<ServiceRotaMessageResponse> MapToListServiceRotaMessageResponse(List<ToggleServiceRota> toggleServiceRotas)
        {
            var lista = new List<ServiceRotaMessageResponse>();

            foreach (var item in toggleServiceRotas)
                lista.Add(MapToServiceRotaMessageResponse(item.ServiceRota));

            return lista;
        }

        public static List<ServiceRotaMessageResponse> MapToListServiceRotaMessageResponse(List<ServiceRota> serviceRotas)
        {
            var lista = new List<ServiceRotaMessageResponse>();

            foreach (var serviceRota in serviceRotas)
                lista.Add(MapToServiceRotaMessageResponse(serviceRota));

            return lista;
        }

        public static ServiceRotaMessageResponse MapToServiceRotaMessageResponse(ServiceRota serviceRota)
        {
            if (serviceRota == null) return new ServiceRotaMessageResponse();

            return new ServiceRotaMessageResponse
            {
                Id = serviceRota.Id,
                Rota = serviceRota.Rota,
                Authorization = serviceRota.Authorization,
                Active = serviceRota.Active
            };
        }
    }
}
