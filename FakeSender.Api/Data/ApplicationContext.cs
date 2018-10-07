using FakeSender.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace FakeSender.Api.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Sms> SmsBox { get; set; }
        public DbSet<Email> EmailBox { get; set; }
        public DbSet<ApnsQuery> ApnsQueryBox { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
    }
}