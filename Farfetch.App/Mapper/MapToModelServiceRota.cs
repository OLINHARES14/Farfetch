using Farfetch.App.Messages;
using Farfetch.Domain.Models.Entities;
using Farfetch.Infra.Cross.Helpers;
using System.Collections.Generic;

namespace Farfetch.App.Mapper
{
    public class MapToModelServiceRota
    {
        public static List<ServiceRota> MapToList(List<ToggleServiceRota> toggleServiceRotas)
        {
            var lista = new List<ServiceRota>();

            foreach (var item in toggleServiceRotas)
                lista.Add(MapToModel(item));

            return lista;
        }

        public static ServiceRota MapToModel(ToggleServiceRota toggleServiceRota)
        {
            if (toggleServiceRota == null) return new ServiceRota();

            return new ServiceRota
            {
                Id = toggleServiceRota.ServiceRotaId,
                Authorization = toggleServiceRota.ServiceRota.Authorization,
                Rota = toggleServiceRota.ServiceRota.Rota,
                Active = toggleServiceRota.ServiceRota.Active
            };
        }

        public static ServiceRota MapToModel(ServiceRotaCreateMessageRequest request)
        {
            if (request == null) return new ServiceRota();

            return new ServiceRota
            {   
                Authorization = request.GetHeader(ServiceConstants.AUTHORIZATION),
                Rota = request.Rota,
                Active = true                
            };
        }

        public static ServiceRota MapToModel(ServiceRotaUpdateMessageRequest request)
        {
            if (request == null) return new ServiceRota();

            return new ServiceRota
            {
                Authorization = request.GetHeader(ServiceConstants.AUTHORIZATION),
                Rota = request.Rota
            };
        }
    }
}
