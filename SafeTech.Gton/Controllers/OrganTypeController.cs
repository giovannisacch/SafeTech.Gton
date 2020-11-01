using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SafeTech.Gton.Dtos;
using SafeTech.Gton.Infra.Data.Interfaces;
using SafeTech.Gton.Infra.Data.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SafeTech.Gton.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganTypeController : ControllerBase
    {
        private IOrganTypeRepository _organTypeRepository;
        private readonly IMapper _mapper;

        public OrganTypeController(IOrganTypeRepository organTypeRepository, IMapper mapper)
        {
            _organTypeRepository = organTypeRepository;
            _mapper = mapper;
        }
        // GET: api/<OrganTypeController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var modelList = await _organTypeRepository.FindAllAsync();

            var dtoList = _mapper.Map<List<OrganType>, List<OrganTypeDto>>(modelList);

            return Ok(dtoList);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var model = await _organTypeRepository.FindByIdAsync(id);

            var viewModel = _mapper.Map<OrganType, OrganTypeDto>(model);

            return Ok(viewModel);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrganTypeDto organTypeDto)
        {
            var model = _mapper.Map<OrganTypeDto, OrganType>(organTypeDto);
            await _organTypeRepository.AddAsync(model);
            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] OrganTypeDto organTypeDto)
        {
            var actualData = await _organTypeRepository.FindByIdAsync(id);
            actualData = _mapper.Map<OrganTypeDto, OrganType>(organTypeDto, actualData);
            await _organTypeRepository.UpdateAsync(actualData);
            return Ok(actualData);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await _organTypeRepository.FindByIdAsync(id);
            if (model == null)
                return BadRequest(new { Message = "Orgão não encontrado" });

            return Ok();
        }
    }
}
