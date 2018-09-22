using Farfetch.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Farfetch.Infra.Data.Imp.Contexts.Seeds
{
    public class SeedToogle
    {
        public static void InsertData(DbContextFarfetch context)
        {
            if (!context.Toggle.Any())
            {
                var listaToggleDominio = new List<Toggle>();

                var CONST_SERVICE_A = "api/service/a";
                var CONST_SERVICE_B = "api/service/b";
                var CONST_SERVICE_C = "api/service/c";
                var CONST_SERVICE_ABC = "api/service/abc";

                var toggle1 = new Toggle { Description = "isButtonBlue", Flag = true, Active = true, CreationDate = DateTime.Now };
                listaToggleDominio.Add(toggle1);

                var toggle2 = new Toggle { Description = "isButtonBlue", Flag = false, Active = true, CreationDate = DateTime.Now };
                listaToggleDominio.Add(toggle2);

                var toggle3 = new Toggle { Description = "isButtonGreen", Flag = true, Active = true, CreationDate = DateTime.Now };
                listaToggleDominio.Add(toggle3);

                var toggle4 = new Toggle { Description = "isButtonRed", Flag = true, Active = true, CreationDate = DateTime.Now };
                listaToggleDominio.Add(toggle4);

                foreach (var item in listaToggleDominio)
                {
                    context.Toggle.Add(item);
                }
                                
                //Relacionamento
                var listaToggleRelacionamento = new List<Toggle>();
                var listaServicoRota = context.ServiceRota.ToList();

                if (listaServicoRota != null && listaServicoRota.Count > 0)
                {
                    var serviceRotaA = listaServicoRota.Where(x => x.Rota == CONST_SERVICE_A).First();
                    var serviceRotaB = listaServicoRota.Where(x => x.Rota == CONST_SERVICE_B).First();
                    var serviceRotaC = listaServicoRota.Where(x => x.Rota == CONST_SERVICE_C).First();
                    var serviceRotaABC = listaServicoRota.Where(x => x.Rota == CONST_SERVICE_ABC).First();

                    toggle2.Rotas.Add(new ToggleServiceRota { Toggle = toggle2, Rota = serviceRotaABC });

                    toggle3.Rotas.Add(new ToggleServiceRota { Toggle = toggle3, Rota = serviceRotaABC });

                    toggle4.Rotas.Add(new ToggleServiceRota { Toggle = toggle4, Rota = serviceRotaA });
                    toggle4.Rotas.Add(new ToggleServiceRota { Toggle = toggle4, Rota = serviceRotaB });
                    toggle4.Rotas.Add(new ToggleServiceRota { Toggle = toggle4, Rota = serviceRotaC });
                }

                context.SaveChanges();
            }
        }
    }
}
