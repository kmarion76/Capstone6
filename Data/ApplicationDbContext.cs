using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using revised_capstone6.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace revised_capstone6.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<TaskModel> TaskList { get; set; }
        public virtual DbSet<IdentityUser> Users { get; set; }
    }
}
