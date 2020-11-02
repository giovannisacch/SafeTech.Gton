using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SafeTech.Gton.Dtos;
using SafeTech.Gton.Dtos.Screen;
using SafeTech.Gton.Infra.Data.Interfaces;
using SafeTech.Gton.Infra.Data.Models;

namespace SafeTech.Gton.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationsController : ControllerBase
    {
        private readonly IOperationRepository _operationRepository;
        private readonly IMapper _mapper;

        public OperationsController(IOperationRepository operationRepository, IMapper mapper)
        {
            _operationRepository = operationRepository;
            _mapper = mapper;
        }


        [HttpGet("screen/list/{operationId}")]
        public async Task<IActionResult> GetOperationDetails(int operationId)
        {
            var model = await _operationRepository.GetOperationWithHistoryAndPatientsIncludedByIdAsync(operationId);
            return Ok(_mapper.Map<Operation, OperationScreenResponseDto>(model));
        }
        [HttpGet("screen/steps/{operationId}")]
        public async Task<IActionResult> GetOperationSteps(int operationId)
        {
            var model = await _operationRepository.GetOperationWithHistoryAndPatientsIncludedByIdAsync(operationId);
            return Ok(_mapper.Map<Operation, OperationStepsScreenResponseDto>(model));

        }

        // GET: api/<OperationsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var modelList = await _operationRepository.GetAllOperationWithHistoryIncludedAsync();

            var dtoList = _mapper.Map<List<Operation>, List<OperationDto>>(modelList);

            return Ok(dtoList);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var model = await _operationRepository.GetOperationWithHistoryIncludedByIdAsync(id);

            var viewModel = _mapper.Map<Operation, OperationDto>(model);

            return Ok(viewModel);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OperationDto operationDto)
        {
            var model = _mapper.Map<OperationDto, Operation>(operationDto);
            await _operationRepository.AddAsync(model);
            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] OperationDto operationDto)
        {
            var actualData = await _operationRepository.FindByIdAsync(id);
            if (actualData == null)
                return BadRequest(new ErrorResponseModel("Operação não encontrado"));

            actualData = _mapper.Map<OperationDto, Operation>(operationDto, actualData);
            await _operationRepository.UpdateAsync(actualData);
            return Ok(actualData);
        }

        [HttpPut("newOperationStep/{id}")]
        public async Task<IActionResult> UpdateToNextOperationStep(int id)
        {
            var actualData = await _operationRepository.GetOperationWithHistoryIncludedByIdAsync(id);
            if (actualData == null)
                return BadRequest(new ErrorResponseModel("Operação não encontrado"));

            actualData.AddNewOperationHistory();
            await _operationRepository.UpdateAsync(actualData);

            return Ok(_mapper.Map<Operation, OperationDto>(actualData));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await _operationRepository.FindByIdAsync(id);
            if (model == null)
                return BadRequest(new ErrorResponseModel("Operação não encontrado"));
            await _operationRepository.DeleteAsync(model);
            return Ok();
        }
    }
}
