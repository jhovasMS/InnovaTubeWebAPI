using InnovaTubeWebAPI.Datos;
using InnovaTubeWebAPI.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InnovaTubeWebAPI.Controllers
{
    [Route("api/videosfavoritos")]
    public class VideosFavoritosController: ControllerBase
    {
        private readonly ApplicationDbContext context;

        public VideosFavoritosController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<List<VideoFavorito>> Get()
        {
            return await context.VideosFavoritos.ToListAsync();
        }


        [HttpPost]
        public async Task<CreatedResult> Post([FromBody] VideoFavorito videoFavorito)
        {
            context.Add(videoFavorito);
            await context.SaveChangesAsync();
            return Created();
        }


        [HttpDelete("{idVideoYouTube}")]
        public async Task<ActionResult> Delete([FromRoute] string idVideoYouTube)
        {
            var filasBorradas = await context.VideosFavoritos.Where(x => x.IdVideoYouTube == idVideoYouTube).ExecuteDeleteAsync();
            if(filasBorradas == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
