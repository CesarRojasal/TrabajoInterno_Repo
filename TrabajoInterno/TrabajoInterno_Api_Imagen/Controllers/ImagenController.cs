using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrabajoInterno_Api_Imagen.DTOs;
using TrabajoInterno_Api_Imagen.Interfaces;

namespace TrabajoInterno_Api_Imagen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagenController : ControllerBase
    {
        private readonly IImagenService imagenService;
        
        public ImagenController(IImagenService imagenService)
        {
            this.imagenService = imagenService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ImagenDto>>> GetAll()
        {
            try { return new OkObjectResult(await imagenService.GetAll()); }
            catch (Exception ex) { return StatusCode(500, ex.Message); }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ImagenDto>> GetById(string id)
        {
            try { return new OkObjectResult(await imagenService.GetById(id)); }
            catch (Exception ex) { return StatusCode(500, ex.Message); }
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public async Task<ActionResult<ImagenDto>> Post(ImagenDto imagenDto)
        {
            try { return new OkObjectResult(await imagenService.Insert(imagenDto));}
            catch (Exception ex) { return StatusCode(500, ex.Message);}
        }

        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public async Task<ActionResult<ImagenDto>> Put(ImagenDto imagenDto, string id)
        {
            try
            {
                if (imagenDto.Id != id)
                    return BadRequest("Por favor validar id");
                return new OkObjectResult(await imagenService.Update(imagenDto));
            }
            catch (Exception ex) { return StatusCode(500, ex.Message); }
        }

        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public async Task<ActionResult<string>> Delete(string id)
        {
            try{ return await imagenService.GetById(id) != null
                          ? new OkObjectResult(await imagenService.Delete(id))
                          : NotFound(string.Format("Imagen {0} no encontrada", id));}
            catch (Exception ex) { return StatusCode(500, ex.Message);}

        }

        [HttpDelete("ByPersona/{idPersona}")]
        public async Task<ActionResult<int>> DeleteByPersona(int idPersona)
        {
            try
            {
                return await imagenService.DeleteImagenByIdPersona(idPersona);
            }
            catch (Exception ex) { return StatusCode(500, ex.Message); }

        }
    }
}