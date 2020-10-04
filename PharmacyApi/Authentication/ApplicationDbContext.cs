using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PharmacyApi.Models;

namespace PharmacyApi.Authentication
{
    public class ApplicationDbContext: IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Country> Country { get; set; }

        //public virtual DbSet<Customer> Customer { get; set; }

        public virtual DbSet<Drug> Drug { get; set; }

        public virtual DbSet<DrugInteraction> DrugInteraction { get; set; }
        public virtual DbSet<Firm> Firm { get; set; }
        public virtual DbSet<Form> Form { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Pharmacy> Pharmacy { get; set; }

        public virtual DbSet<PurchasedItem> PurchasedItem { get; set; }

        public virtual DbSet<ROAD> ROAD { get; set; }
        public virtual DbSet<SubCategory> SubCategory { get; set; }

        public virtual DbSet<Supplier> Supplier { get; set; }
        public virtual DbSet<TheraGroup> TheraGroup { get; set; }
        public virtual DbSet<TheraSubGroup> TheraSubGroup { get; set; }
        public virtual DbSet<Unit> Unit { get; set; }
        public virtual DbSet<Pledge> Pledge { get; set; }






    }
}

