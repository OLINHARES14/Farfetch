using Farfetch.App.Messages;
using Farfetch.Domain.Models.Entities;
using System;

namespace Farfetch.App.Mapper
{
    public class MapToModelToggle
    {
        public static Toggle MapToModel(CreateToggleMessageRequest request)
        {
            if (request == null) return new Toggle();

            return new Toggle
            {
                Description = request.Description,
                Flag = request.Flag,
                Active = true,
                CreationDate = DateTime.Now
            };
        }

        public static Toggle MapToModel(UpdateToggleMessageRequest request)
        {
            if (request == null) return new Toggle();

            return new Toggle
            {
                Description = request.Description,
                Flag = request.Flag
            };
        }
    }
}
