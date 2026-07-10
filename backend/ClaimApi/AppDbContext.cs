using ClaimApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ClaimApi.Data
{

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Claim> Claims {get;set;}
        public DbSet<AuditLog> AuditLogs {get;set;}
        public DbSet<ClaimDocument> ClaimDocuments {get;set;}
        public DbSet<Policy> Policies {get;set;}
        public DbSet<RejectReason> RejectReasons {get;set;}
        public DbSet<Status> Statuses {get;set;}
        public DbSet<User> Users {get;set;}

        



    }
}