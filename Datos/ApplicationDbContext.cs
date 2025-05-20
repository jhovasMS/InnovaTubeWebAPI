using InnovaTubeWebAPI.Entidades;
using Microsoft.EntityFrameworkCore;

namespace InnovaTubeWebAPI.Datos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<VideoFavorito> VideosFavoritos { get; set; }
    }
}
