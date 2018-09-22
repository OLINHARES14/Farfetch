using Farfetch.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Farfetch.Infra.Data.Imp.Contexts.Seeds
{
    public class SeedServiceRota
    {
        public static void InsertData(DbContextFarfetch context)
        {
            if (!context.ServiceRota.Any())
            {
                var listaServiceRota = new List<ServiceRota>();                

                var CONST_SERVICE_A = "/api/service/a";
                var CONST_SERVICE_B = "/api/service/b";
                var CONST_SERVICE_C = "/api/service/c";
                var CONST_SERVICE_ABC = "/api/service/abc";

                listaServiceRota.Add(new ServiceRota { Rota = CONST_SERVICE_A, Authorization = Guid.NewGuid().ToString(), Active = true });
                listaServiceRota.Add(new ServiceRota { Rota = CONST_SERVICE_B, Authorization = Guid.NewGuid().ToString(), Active = true });
                listaServiceRota.Add(new ServiceRota { Rota = CONST_SERVICE_C, Authorization = Guid.NewGuid().ToString(), Active = true });
                listaServiceRota.Add(new ServiceRota { Rota = CONST_SERVICE_ABC, Authorization = Guid.NewGuid().ToString(), Active = true });

                foreach (var item in listaServiceRota)
                {
                    context.ServiceRota.Add(item);
                }

                context.SaveChanges();
            }
        }
    }
}
