using Farfetch.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Farfetch.Infra.Data.Imp.Contexts.Seeds
{
    public class SeedServiceRotaToggle
    {
        public static void InsertData(DbContextFarfetch context)
        {
            if (!context.ServiceRotaToggle.Any())
            {
                var listaServiceRotaToggle = new List<ServiceRotaToggle>();                

                var CONST_SERVICE = "/api/order/register";

                var toggle = context.Toggle.First();

                listaServiceRotaToggle.Add(new ServiceRotaToggle { Rota = CONST_SERVICE, Active = true, Toggle = toggle });

                foreach (var item in listaServiceRotaToggle)
                {
                    context.ServiceRotaToggle.Add(item);
                }

                context.SaveChanges();
            }
        }
    }
}
