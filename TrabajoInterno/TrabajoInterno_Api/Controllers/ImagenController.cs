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
        public async Task<ActionResult<IEnumerable<ImagenDto>>> GetAll()
        {
            try { return new OkObjectResult((await imagenService.GetAll()).Select(x => _mapper.Map<ImagenDto>(x))); }
            catch (Exception ex) { return StatusCode(500, ex.Message); }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ImagenDto>> GetById(string id)
        {
            try { return new OkObjectResult(_mapper.Map<ImagenDto>(await imagenService.GetById(id))); }
            catch (Exception ex) { return StatusCode(500, ex.Message); }
        }

        [HttpPost]
        public async Task<ActionResult<ImagenDto>> Post(ImagenDto imagenDto)
        {
            try { return new OkObjectResult(_mapper.Map<ImagenDto>(await imagenService.Insert(_mapper.Map<Imagen>(imagenDto))));}
            catch (Exception ex) { return StatusCode(500, ex.Message);}
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ImagenDto>> Put(ImagenDto imagenDto, string id)
        {
            try
            {
                if (imagenDto.Id != id)
                    return BadRequest("Por favor validar id");
                return new OkObjectResult(_mapper.Map<ImagenDto>(await imagenService.Update(_mapper.Map<Imagen>(imagenDto))));
            }
            catch (Exception ex) { return StatusCode(500, ex.Message); }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Delete(string id)
        {
            try{ return await imagenService.GetById(id) != null
                          ? new OkObjectResult(await imagenService.Delete(id))
                          : NotFound(string.Format("Imagen {0} no encontrada", id));}
            catch (Exception ex) { return StatusCode(500, ex.Message);}

        }
    }
}