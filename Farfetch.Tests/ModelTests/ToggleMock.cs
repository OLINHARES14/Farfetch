using Farfetch.Domain.Models.Entities;
using System.Collections.Generic;

namespace Farfetch.Tests.ModelTests
{
    public class ToggleMock
    {
        public static Toggle ToggleValido()
        {
            var listaToggleServiceRotaMock = new List<ToggleServiceRota>();
            listaToggleServiceRotaMock.Add(ToggleServiceRotaMock.ToggleServiceRotaValido());

            return new Toggle
            {
                Id = 1,
                Description = "Toggle Description",
                Flag = true,
                Active = true,
                ToggleServiceRotas = listaToggleServiceRotaMock
            };
        }
    }
}
