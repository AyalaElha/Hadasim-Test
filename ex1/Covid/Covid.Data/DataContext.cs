using Covid.Core;
using Covid.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Covid.Data
{
    public class DataContext:DbContext
    {
        public DbSet<Vaccine> Vaccines { get; set; }
        public DbSet<CovidDetails> Covids { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Producer> Producers { get; set; }
        //public DataContext()
        //{
        //    Vaccines = new List<Vaccine> ();
        //    Vaccines.Add(new Vaccine { Id = 1, /*Producer = "germany",*/ Date = DateTime.Now });
        //    Covids = new List<CovidDetails> ();
        //    Covids.Add(new CovidDetails { });
        //    Members = new List<Member> ();
        //    Members.Add(new Member { Id = 1, Fname = "aya", Lname = "el", IdentityNum = "2155675475", City = "bnei braq", Street = "havakuk", numAdress = 14, BirthDay=DateTime.Now,Phone="03-5785120",MobilePhone="0566767654"});
        //    Producers=new List<Producer> ();
        //    Producers.Add(new Producer { Id = 1, Name = "germany" ,Status=true});
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=covid_dtb");

        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<Member>()
                .HasOne(m => m.CovidDetails)
                .WithOne(c => c.Member)
                .HasForeignKey<Member>(m => m.CovidDetailsId)
                .IsRequired(false);
            modelBuilder.Entity<CovidDetails>()
             .HasOne(cd => cd.Member) // Member has one CovidDetails
             .WithOne(m => m.CovidDetails) // CovidDetails is with one Member
             .HasForeignKey<CovidDetails>(c => c.MemberId)
             .IsRequired();// Member contains the foreign key
        }
    }
}
