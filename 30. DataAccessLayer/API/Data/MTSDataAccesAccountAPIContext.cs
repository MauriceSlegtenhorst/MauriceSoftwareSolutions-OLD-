using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MTS.BL.Infra.APILibrary;

namespace MTS.DataAcces.AccountAPI.Data
{
    public class MTSDataAccesAccountAPIContext : DbContext
    {
        public MTSDataAccesAccountAPIContext (DbContextOptions<MTSDataAccesAccountAPIContext> options)
            : base(options)
        {
        }

        public DbSet<MTS.BL.Infra.APILibrary.Credit> Credit { get; set; }
    }
}
