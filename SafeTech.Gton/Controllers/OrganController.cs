using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SafeTech.Gton.Dtos;
using SafeTech.Gton.Infra.Data.Interfaces;
using SafeTech.Gton.Infra.Data.Models;
using SafeTech.Gton.Infra.Data.Repositories;

namespace SafeTech.Gton.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganController : ControllerBase
    {
        private readonly IOrganRepository _organRepository;
        private readonly IMapper _mapper;

        public OrganController(IOrganRepository organRepository, IMapper mapper)
        {
            _organRepository = organRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var modelList = await _organRepository.FindAllAsync();

            var dtoList = _mapper.Map<List<Organ>, List<OrganDto>>(modelList);

            return Ok(dtoList);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var model = await _organRepository.FindByIdAsync(id);

            var viewModel = _mapper.Map<Organ, OrganDto>(model);

            return Ok(viewModel);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrganDto organDto)
        {
            var model = _mapper.Map<OrganDto, Organ>(organDto);
            await _organRepository.AddAsync(model);
            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] OrganDto organDto)
        {
            var actualData = await _organRepository.FindByIdAsync(id);
            if (actualData == null)
                return BadRequest(new ErrorResponseModel("Tipo de orgão não encontrado"));
            actualData = _mapper.Map<OrganDto, Organ>(organDto, actualData);
            await _organRepository.UpdateAsync(actualData);
            return Ok(actualData);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await _organRepository.FindByIdAsync(id);
            if (model == null)
                return BadRequest(new ErrorResponseModel("Orgão não encontrado"));
            await _organRepository.DeleteAsync(model);
            return Ok();
        }
    }
}
