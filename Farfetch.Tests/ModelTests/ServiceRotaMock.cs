using Farfetch.Domain.Models.Entities;
using System;
using System.Collections.Generic;

namespace Farfetch.Tests.ModelTests
{
    public class ServiceRotaMock
    {
        public static ServiceRota ServiceRotaValido()
        {
            var listaToggleServiceRotaMock = new List<ToggleServiceRota>();
            listaToggleServiceRotaMock.Add(ToggleServiceRotaMock.ToggleServiceRotaValido());

            return new ServiceRota
            {
                Id = 1,
                Authorization = Guid.NewGuid().ToString(),
                Rota = "/api/service/mock",
                Active = true,
                ToggleServiceRotas = listaToggleServiceRotaMock
            };
        }
    }
}
