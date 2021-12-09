using Authentication.DataAccess.Context;
using Authentication.Entities;
using DataAccess.Model;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Context
{
    public class SupportSystemContext : AuthContext
    {
        public SupportSystemContext(DbContextOptions<SupportSystemContext> options) : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Calendar> Calendars { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<UsersCompanies> UsersCompanies { get; set; }
        public DbSet<UserSemesters> UserSemesters { get; set; }

        //CUSTOM
        public virtual DbSet<OfferWithSemester> OfferWithSemesters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
