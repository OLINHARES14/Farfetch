using Farfetch.Domain.Models.Entities;

namespace Farfetch.Tests.ModelTests
{
    public class Models
    {
        public static Toggle MockToggleValido()
        {
            return new Toggle
            {
                Description = "Toggle Description",
                Flag = true,
                Active = true                 
            };
        }
    }
}
