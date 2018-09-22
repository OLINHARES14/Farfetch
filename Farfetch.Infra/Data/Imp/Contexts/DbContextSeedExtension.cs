using Farfetch.Infra.Data.Imp.Contexts.Seeds;

namespace Farfetch.Infra.Data.Imp.Contexts
{
    public static class DbContextSeedExtension
    {
        public static void EnsureSeeded(this DbContextFarfetch context)
        {
            SeedToogle.InsertData(context);
        }
    }
}
