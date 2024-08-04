using AutoMapper;
using Livraria.DTO.Input;
using Livraria.DTO.Modelo;
using Livraria.Models;
using Livraria.repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Livraria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {

        readonly IAutorRepository _autorRepository;
        readonly IMapper _mapper;

        public AutorController(IAutorRepository autorRepository, IMapper mapper)
        {
            _autorRepository = autorRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<AutorDTO>>> ListarAutores()
        {
            var AutoresDTO = _mapper.Map<List<AutorDTO>>(await _autorRepository.GetAllAscync());

            return Ok(AutoresDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AutorDTO>> BuscarAutor(int id)
        {
            var AutorDTO = _mapper.Map<AutorDTO>(await _autorRepository.GetAutorByIdAscync(id));

            return Ok(AutorDTO);
        }

        [HttpPost]
        public async Task<ActionResult<AutorDTO>> SalvarAutor(AutorInputDTO autor) {
            var autorAssembler = _mapper.Map<Autor>(autor);
            var AutorDTO = _mapper.Map<AutorDTO>( await _autorRepository.CreateAutorAscync(autorAssembler));
            return Created("", AutorDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AutorDTO>> AtualizarAutor(int id, AutorInputDTO autor)
        {
            var autorAssembler = _mapper.Map<Autor>(autor);
            var AutorDTO = _mapper.Map<AutorDTO>(await _autorRepository.UpdateAutorAscync(autorAssembler, id));

            return Ok(AutorDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletarAutor(int id)
        {
           await _autorRepository.DeleteAutorAscync(id);
            return NoContent();

        }
    }
}
