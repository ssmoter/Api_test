using DataLibrary;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace InterfejsApi.Models
{
    public class GarageContext : DbContext
    {
        public GarageContext(DbContextOptions<GarageContext> options)
            : base(options)
        { }
        public DbSet<GarageModel> Garamodels { get; set; }

        public List<GarageModel> GarageModels { get; set; }
        public GarageModel GarageModel { get; set; }
    }
}
