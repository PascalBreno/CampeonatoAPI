using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Application.ViewModel.Time;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.AppService;
using Domain.Interfaces.Services;
using Domain.PageList;
using Domain.Parameters;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Service.Validation;
using Service.Validation.Time;
using Service.ViewModel.Time;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    
    public class TimeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITimeAppService _timeAppService;
        public TimeController(ITimeAppService timeService,IMapper mapper)
        {
            _mapper = mapper;
            _timeAppService = timeService;
        }
        
        [HttpGet]
        [Route("{id}",Name = "GetTime")]
        public async Task<ActionResult> GetTime([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var result = await _timeAppService.Get(id);
                var back = _mapper.Map<TimeEntity, TimeViewModel>(result);
                return Ok(back);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpGet]
        [Route("{sigla}",Name = "GetTimeSigla")]
        public async Task<ActionResult> GetTime([FromRoute] string sigla)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var result = await _timeAppService.SelectCodigoAsync(sigla);
                var back = _mapper.Map<TimeEntity, TimeViewModel>(result);
                return Ok(back);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        
        [HttpGet(Name = "GetAllTimesPage")]
        public async Task<ActionResult> GetAllTimes([FromQuery] ParametersPage parametersPage)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var back = await _timeAppService.GetAll(parametersPage);
                var result = _mapper.MapList<TimeEntity, TimeViewModel>(back);
                var metadata = new
                {
                    result.TotalCount,
                    result.PageSize,
                    result.CurrentPage,
                    result.TotalPages,
                    result.HasNext,
                    result.HasPrevious
                };
 
                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(AdicionarTimeViewModel item)
        {
            
            var validator = new AdicionarTimeViewModelValidation(_timeAppService);
            var validateResult = validator.Validate(item);
            validateResult.AddToModelState(ModelState, null);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var map = _mapper.Map<AdicionarTimeViewModel, TimeEntity>(item);
                var result =await _timeAppService.Post(map);
                if (result == null) return BadRequest();
                return Redirect(new Uri(Url.Link("GetTime", new {id = result.Id})).ToString());
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Deleted([FromRoute] Guid id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                if (await _timeAppService.Delete(id))
                    return Redirect(new Uri(Url.Link("GetAllTimesPage", new {})).ToString());
                return BadRequest();
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Update(AlterarTimeViewModel item)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                var result = _mapper.Map<AlterarTimeViewModel, TimeEntity>(item);
                result = await _timeAppService.Put(result);
                if (result == null) return BadRequest();
                return Created(new Uri(Url.Link("GetTime", new {id = result.Id})), result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}