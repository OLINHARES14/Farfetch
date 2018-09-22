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
                IList<Toggle> defaultValue = new List<Toggle>();

                defaultValue.Add(new Toggle { Description = "isButtonBlue", Flag = true, Active = true, CreationDate = DateTime.Now });
                defaultValue.Add(new Toggle { Description = "isButtonBlue", Flag = false, Active = true, CreationDate = DateTime.Now });
                defaultValue.Add(new Toggle { Description = "isButtonGreen", Flag = true, Active = true, CreationDate = DateTime.Now });
                defaultValue.Add(new Toggle { Description = "isButtonRed", Flag = true, Active = true, CreationDate = DateTime.Now });

                foreach (var toggle in defaultValue)
                    context.Toggle.Add(toggle);

                context.SaveChanges();
            }
        }
    }
}
