namespace FixMeApplication.Migrations
{
    using Data;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FixMeApplication.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "FixMeApplication.Models.ApplicationDbContext";
        }

        protected override void Seed(FixMeApplication.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.
            RepairContext repairContext = new RepairContext();
            var repairTypes1 = repairContext.RepairTypes.
                Where(e => e.Id % 2 == 0)
                .ToList();

            var repairTypes2 = repairContext.RepairTypes.
                Where(e => e.Id % 2 == 1)
                .ToList();

            repairContext.RepairShops.Add(new RepairShop(
                )
            {
                Name = "Repair Alpha",
                Address = "42.5105141,27.4740824",
                RepairTypes = repairTypes1
            });

            repairContext.RepairShops.Add(new RepairShop(
                )
            {
                Name = "Repair Beta",
                Address = "42.5033381,27.4559481",
                RepairTypes = repairTypes2
            });

            repairContext.RepairShops.Add(new RepairShop(
                )
            {
                Name = "Repair Gamma",
                Address = "42.5156312,27.4347075",
                RepairTypes = repairTypes1
            });

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
