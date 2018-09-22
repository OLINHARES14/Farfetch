using Farfetch.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Farfetch.Infra.Data.Imp.Contexts.Seeds
{
    public class SeedOrder
    {
        public static void InsertData(DbContextFarfetch context)
        {
            //if (!context.ServiceRota.Any())
            //{
            //    var listaServiceRota = new List<ServiceRota>();                

            //    var CONST_SERVICE_A = "api/service/a";
            //    var CONST_SERVICE_B = "api/service/b";
            //    var CONST_SERVICE_C = "api/service/c";
            //    var CONST_SERVICE_ABC = "api/service/abc";

            //    listaServiceRota.Add(new ServiceRota { Rota = CONST_SERVICE_A, Active = true, UpdateDate = DateTime.Now });
            //    listaServiceRota.Add(new ServiceRota { Rota = CONST_SERVICE_B, Active = true, UpdateDate = DateTime.Now });
            //    listaServiceRota.Add(new ServiceRota { Rota = CONST_SERVICE_C, Active = true, UpdateDate = DateTime.Now });
            //    listaServiceRota.Add(new ServiceRota { Rota = CONST_SERVICE_ABC, Active = true, UpdateDate = DateTime.Now });

            //    foreach (var item in listaServiceRota)
            //    {
            //        context.ServiceRota.Add(item);
            //    }

            //    context.SaveChanges();
            //}
        }
    }
}
