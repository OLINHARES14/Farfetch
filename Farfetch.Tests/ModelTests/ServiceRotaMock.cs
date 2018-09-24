using Farfetch.Domain.Models.Entities;
using System;
using System.Collections.Generic;

namespace Farfetch.Tests.ModelTests
{
    public class ServiceRotaMock
    {
        public static ServiceRota ServiceRotaValido()
        {   
            return new ServiceRota
            {
                Id = 1,
                Authorization = Guid.NewGuid().ToString(),
                Rota = "/api/service/mock",
                Active = true,
                ToggleServiceRotas = new List<ToggleServiceRota>()
            };
        }
    }
}
