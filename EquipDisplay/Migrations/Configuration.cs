namespace EquipDisplay.Migrations
{
    using EquipDisplay.Models;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EquipDisplay.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EquipDisplay.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            System.IO.StreamReader sr = new System.IO.StreamReader("C:\\Users\\xenio\\Desktop\\Test\\EquipmentData.json");

            string jsonString = sr.ReadToEnd();
            Equipment allEquip = JsonConvert.DeserializeObject<Equipment>(jsonString);


            foreach (EquipmentType item in allEquip.EquipmentType.ToList())
            {

                context.EquipmentTypes.AddOrUpdate(
                    new EquipmentType()
                    {
                        Id = item.Id,
                        ExternalId = item.ExternalId,
                        Description = item.Description
                    }
                    );
            }

            foreach (SerialisedEquipment item in allEquip.SerialisedEquipment.ToList())
            {

                context.SerialisedEquipments.AddOrUpdate(
                    new SerialisedEquipment()
                    {
                        Id = item.Id,
                        ExternalId = item.ExternalId,
                        EquipmentTypeId = item.EquipmentTypeId,
                        MeterReading = item.MeterReading
                    }
                    );
                
            }


            List<Display> displayOBJ = new List<Display>();
            foreach (SerialisedEquipment item in allEquip.SerialisedEquipment.ToList())
            {
                foreach (EquipmentType itemD in allEquip.EquipmentType.ToList())
                {

                    if (item.EquipmentTypeId == itemD.Id)
                    {
                        context.Displays.AddOrUpdate(
                            new Display()
                            {
                                MeterReading = item.MeterReading,
                                ExternalId = item.ExternalId,
                                Description = itemD.Description
                            });
                    }

                }


            }



        }
    }
}
