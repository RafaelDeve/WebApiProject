using Microsoft.EntityFrameworkCore;
using MVC.Models; // Asegúrate de que el espacio de nombres sea correcto

namespace MVC.Models // Cambia este espacio de nombres según la carpeta donde lo coloques
{
    public class YourDbContext : DbContext
    {
        public YourDbContext(DbContextOptions<YourDbContext> options) : base(options) { }

        public DbSet<Book> Book { get; set; } // Propiedad para acceder a los libros en la base de datos
    }
}
