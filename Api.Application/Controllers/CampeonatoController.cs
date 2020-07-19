using System;
using System.Net;
using System.Threading.Tasks;
using Application.ViewModel;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.AppService;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Service.ViewModel.Campeonato;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampeonatoController : Controller
    {

        private readonly ICampeonatoAppServices _campeonatoAppService;
        private readonly IMapper _mapper;
        public CampeonatoController(ICampeonatoAppServices campeonatoAppService, IMapper mapper)
        {
            _campeonatoAppService = campeonatoAppService;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<ActionResult> PostCampeonato([FromBody] AdicionarCampeonatoViewModel campeonato)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                var result = _mapper.Map<AdicionarCampeonatoViewModel, CampeonatoEntity>(campeonato);
                result = await _campeonatoAppService.Post(result);
                if (result == null) return BadRequest();
                return Redirect(new Uri(Url.Link("GetCampeonatoCodigo", new {codigoCampeonato = result.codigoCampeonato})).ToString());
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, ex.Message);
            }
        }
         
        [HttpGet]
        [Route("{codigoCampeonato}", Name="GetCampeonatoCodigo")]
        public async Task<ActionResult> GetCampeonatoCodigo(string codigoCampeonato)
        {
            if (!ModelState.IsValid) return BadRequest();
            try
            {
                var result = await _campeonatoAppService.GetByCod(codigoCampeonato);
                var back = _mapper.Map<CampeonatoEntity, CampeonatoViewModel>(result);
                return Ok(back);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> PutCampeonatoCodigo(AlterarCampeonatoViewModel campeonato)
        {
            if (!ModelState.IsValid) return BadRequest();
            try
            {
                var result = _mapper.Map<AlterarCampeonatoViewModel,CampeonatoEntity>(campeonato);
                result = await _campeonatoAppService.Put(result);
                return Redirect(new Uri(Url.Link("GetCampeonatoCodigo", new {result.codigoCampeonato})).ToString());
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}