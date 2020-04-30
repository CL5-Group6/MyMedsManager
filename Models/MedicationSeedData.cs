using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyMedsManager.Data;
using System;
using System.Linq;


namespace MyMedsManager.Models
{
    public class MedicationSeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {
                // Look for any movies.
                if (context.Medication.Any())
                {
                    return;   // DB has been seeded
                }

                context.Medication.AddRange(
                    new Medication
                    {
                        Medicine = "Medicine's Name Here",
                        MedQuantity = 0,
                        Dosage = "Dosage ex: 1/day, 2/6hrs",
                        Notes = "Any additional info you would like here"
                    }
                );
                context.SaveChanges();
            }
        }
        }
}
