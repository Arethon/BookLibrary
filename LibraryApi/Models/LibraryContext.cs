using Microsoft.EntityFrameworkCore;
using P20_Shared_Library.Auth;
using P20_Shared_Library.Model;
using System.Collections.Generic;

namespace LibraryManagementSystem.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
