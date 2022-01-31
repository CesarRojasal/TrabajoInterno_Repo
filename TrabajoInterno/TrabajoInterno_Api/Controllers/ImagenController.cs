using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrabajoInterno_Api.DTOs;
using TrabajoInterno_Api.Interfaces;
using TrabajoInterno_Api.Models;

namespace TrabajoInterno_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagenController : ControllerBase
    {
        private readonly IImagenService imagenService;
        public readonly IMapper _mapper;
        public ImagenController(IMapper mapper, IImagenService imagenService)
        {
            _mapper = mapper;
            this.imagenService = imagenService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var personas = await imagenService.GetAll();
            return Ok(personas.Select(x => _mapper.Map<ImagenDto>(x)));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(string id)
        {
            var imagen = await imagenService.GetById(id);
            if (imagen == null)
                return NotFound();
            return Ok(_mapper.Map<ImagenDto>(imagen));
        }

        [HttpPost]
        public async Task<ActionResult> Post(ImagenDto imagenDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Por favor validar los datos");

            try
            {
                var imagen = await imagenService.Insert(_mapper.Map<Imagen>(imagenDto));
                return Ok(imagen);
            }
            catch (Exception ex) { return StatusCode(500, ex.Message); }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(ImagenDto imagenDto, string id)
        {
            if (!ModelState.IsValid)
                return BadRequest("Por favor validar los datos");
            if (imagenDto.Id != id)
                return BadRequest("Por favor validar id");

            try
            {
                var imagen = await imagenService.Update(_mapper.Map<Imagen>(imagenDto));
                return Ok(imagen);
            }
            catch (Exception ex) { return StatusCode(500, ex.Message); }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var imagen = await imagenService.GetById(id);
            if (imagen == null)
                return NotFound(string.Format("Imagen {0} no encontrada", id));

            var resp = await imagenService.Delete(id);

            return Ok(string.Format("Imagen Eliminada: {0}", resp));
        }

    }
}