using chat.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chat.DATA.Context
{
    public partial class chatContext : DbContext
    {
        private readonly chatContext _context;
        public chatContext()
            : base("name=ChatDBEntities")
        {
            Configuration.LazyLoadingEnabled = false;
        }
        public virtual DbSet<AdminUser> AdminUser { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<Favorites> Favorites { get; set; }
        public virtual DbSet<PoolBan> PoolBan { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<Messages> Messages { get; set; }
        public virtual DbSet<GenderChoice> GenderChoice { get; set; }
        public virtual DbSet<TimeLine> TimeLine { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<MessageEmpAdmin> MessageEmpAdmin { get; set; }
        public virtual DbSet<MessageCusAdmin> MessageCusAdmin { get; set; }
        public virtual DbSet<HairColors> HairColors { get; set; }
        public virtual DbSet<HairTypes> HairTypes { get; set; }
        public virtual DbSet<EyeColors> EyeColors { get; set; }
        public virtual DbSet<BodyTypes> BodyTypes { get; set; }
        public virtual DbSet<CustomerPayment> CustomerPayment { get; set; }

        public virtual DbSet<PayChart> PayChart { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdminUser>().ToTable("AdminUser", "dbo");
            modelBuilder.Entity<Favorites>().ToTable("Favorites", "dbo");
            modelBuilder.Entity<PoolBan>().ToTable("PoolBan", "dbo");
            modelBuilder.Entity<Customer>().ToTable("Customer", "dbo");
            modelBuilder.Entity<Gender>().ToTable("Gender", "dbo");
            modelBuilder.Entity<Payment>().ToTable("Payment", "dbo");
            modelBuilder.Entity<GenderChoice>().ToTable("GenderChoice", "dbo");
            modelBuilder.Entity<TimeLine>().ToTable("TimeLine", "dbo");
            modelBuilder.Entity<Employee>().ToTable("Employee", "dbo");
            modelBuilder.Entity<Messages>().ToTable("Messages", "dbo");
            modelBuilder.Entity<Status>().ToTable("Status", "dbo");
            modelBuilder.Entity<HairColors>().ToTable("HairColors", "dbo");
            modelBuilder.Entity<HairTypes>().ToTable("HairTypes", "dbo");
            modelBuilder.Entity<EyeColors>().ToTable("EyeColors", "dbo");
            modelBuilder.Entity<BodyTypes>().ToTable("BodyTypes", "dbo");
            modelBuilder.Entity<PayChart>().ToTable("PayChart", "dbo");
            modelBuilder.Entity<MessageCusAdmin>().ToTable("MessageCusAdmin", "dbo");
            modelBuilder.Entity<MessageEmpAdmin>().ToTable("MessageEmpAdmin", "dbo");
            modelBuilder.Entity<CustomerPayment>().ToTable("CustomerPayment", "dbo");
            base.OnModelCreating(modelBuilder);
        }


    }
}
