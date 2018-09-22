using Farfetch.App.Messages;
using Farfetch.Domain.Models.Entities;
using System.Collections.Generic;

namespace Farfetch.App.Mapper
{
    public class MapToResponseServiceRotaToggleMessage
    {
        public static List<ServiceRotaToggleMessageResponse> MapToListServiceRotaToggleMessageResponse(List<ServiceRotaToggle> serviceRotaToggles)
        {
            var lista = new List<ServiceRotaToggleMessageResponse>();

            foreach (var serviceRotaToggle in serviceRotaToggles)
                lista.Add(MapToServiceRotaToggleMessageResponse(serviceRotaToggle));

            return lista;
        }

        public static ServiceRotaToggleMessageResponse MapToServiceRotaToggleMessageResponse(ServiceRotaToggle serviceRotaToggle)
        {
            if (serviceRotaToggle == null) return new ServiceRotaToggleMessageResponse();

            return new ServiceRotaToggleMessageResponse
            {
                Id = serviceRotaToggle.Id,
                //Description = toggle.Description,
                //Flag = toggle.Flag,
                Active = serviceRotaToggle.Active                
            };
        }
    }
}
