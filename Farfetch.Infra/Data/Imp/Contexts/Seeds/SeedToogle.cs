using Farfetch.Domain.Models.Entities;
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

                var CONST_SERVICE_A = "/api/service/a";
                var CONST_SERVICE_B = "/api/service/b";
                var CONST_SERVICE_C = "/api/service/c";
                var CONST_SERVICE_ABC = "/api/service/abc";

                var toggle1 = new Toggle { Description = "isButtonBlue", Flag = true, Active = true };
                listaToggleDominio.Add(toggle1);

                var toggle2 = new Toggle { Description = "isButtonBlue", Flag = false, Active = true };
                listaToggleDominio.Add(toggle2);

                var toggle3 = new Toggle { Description = "isButtonGreen", Flag = true, Active = true };
                listaToggleDominio.Add(toggle3);

                var toggle4 = new Toggle { Description = "isButtonRed", Flag = true, Active = true };
                listaToggleDominio.Add(toggle4);

                foreach (var item in listaToggleDominio)
                {
                    context.Toggle.Add(item);
                }

                #region [ Relacionamento ]

                var listaToggleRelacionamento = new List<Toggle>();
                var listaServiceRota = context.ServiceRota.ToList();

                if (listaServiceRota != null && listaServiceRota.Count > 0)
                {
                    var serviceRotaA = listaServiceRota.Where(x => x.Rota == CONST_SERVICE_A).First();
                    var serviceRotaB = listaServiceRota.Where(x => x.Rota == CONST_SERVICE_B).First();
                    var serviceRotaC = listaServiceRota.Where(x => x.Rota == CONST_SERVICE_C).First();
                    var serviceRotaABC = listaServiceRota.Where(x => x.Rota == CONST_SERVICE_ABC).First();

                    toggle2.ToggleServiceRotas.Add(new ToggleServiceRota { Toggle = toggle2, ServiceRota = serviceRotaABC });

                    toggle3.ToggleServiceRotas.Add(new ToggleServiceRota { Toggle = toggle3, ServiceRota = serviceRotaABC });

                    toggle4.ToggleServiceRotas.Add(new ToggleServiceRota { Toggle = toggle4, ServiceRota = serviceRotaA });
                    toggle4.ToggleServiceRotas.Add(new ToggleServiceRota { Toggle = toggle4, ServiceRota = serviceRotaB });
                    toggle4.ToggleServiceRotas.Add(new ToggleServiceRota { Toggle = toggle4, ServiceRota = serviceRotaC });
                }

                #endregion

                context.SaveChanges();
            }
        }
    }
}
