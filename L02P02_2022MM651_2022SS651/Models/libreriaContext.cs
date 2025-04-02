using Microsoft.EntityFrameworkCore;

namespace L02P02_2022MM651_2022SS651.Models
{
    public class libreriaContext : DbContext
    {
        public libreriaContext(DbContextOptions<libreriaContext> options) : base(options)
        {
        }

        public DbSet<autores> autores { get; set; }
        public DbSet<categorias> categorias { get; set; }
        public DbSet<clientes> clientes { get; set; }
        public DbSet<comentarios_libros> comentarios_Libros { get; set; }
        public DbSet<libros> libros { get; set; }
        public DbSet<pedido_detalle> pedido_detalle { get; set; }
        public DbSet<pedido_encabezado> pedido_encabezado { get; set; }
    }
}
