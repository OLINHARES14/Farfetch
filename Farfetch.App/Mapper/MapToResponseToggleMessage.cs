using Farfetch.App.Messages;
using Farfetch.Domain.Models.Entities;
using System.Collections.Generic;

namespace Farfetch.App.Mapper
{
    public class MapToResponseToggleMessage
    {
        public static List<ToggleMessageResponse> MapToListToggleMessageResponse(List<Toggle> toggles)
        {
            var lista = new List<ToggleMessageResponse>();

            foreach (var toggle in toggles)
                lista.Add(MapToToggleMessageResponse(toggle));

            return lista;
        }

        public static ToggleMessageResponse MapToToggleMessageResponse(Toggle toggle)
        {
            if (toggle == null) return new ToggleMessageResponse();

            return new ToggleMessageResponse
            {
                Id = toggle.Id,
                Description = toggle.Description,
                Flag = toggle.Flag,
                Active = toggle.Active,
                ServiceRotas = MapToResponseServiceRotaMessage.MapToListServiceRotaMessageResponse(toggle.ToggleServiceRotas)
            };
        }
    }
}
