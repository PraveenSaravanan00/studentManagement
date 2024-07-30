using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RepositoryCRUD.Models;

namespace RepositoryCRUD.Data
{
    public class RepositoryCRUDContext : DbContext
    {
        public RepositoryCRUDContext (DbContextOptions<RepositoryCRUDContext> options)
            : base(options)
        {
        }

        public DbSet<RepositoryCRUD.Models.StudentsData> StudentsData { get; set; } = default!;
    }
}
