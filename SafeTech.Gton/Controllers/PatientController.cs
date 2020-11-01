using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SafeTech.Gton.Dtos;
using SafeTech.Gton.Infra.Data;
using SafeTech.Gton.Infra.Data.Interfaces;
using SafeTech.Gton.Infra.Data.Models;

namespace SafeTech.Gton.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private IPatientRepository _patientRepository;
        private readonly IMapper _mapper;

        public PatientController(IPatientRepository patientRepository, IMapper mapper)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
        }
        // GET: api/<PatientController>
        /// <summary>
        /// Busca todos os pacientes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var modelList = await _patientRepository.FindAllAsync();

            var dtoList = _mapper.Map<List<Patient>, List<PatientDto>>(modelList);

            return Ok(dtoList);
        }

        // GET api/<PatientController>/5
        /// <summary>
        /// Busca paciente por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var model = await _patientRepository.FindByIdAsync(id);

            var viewModel = _mapper.Map<Patient, PatientDto>(model);

            return Ok(viewModel);
        }

        // POST api/<PatientController>
        /// <summary>
        /// Adiciona um novo paciente
        /// </summary>
        /// <param name="patientDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]PatientDto patientDto)
        {
            var cpfAlreadyRegistered = await _patientRepository.CpfIsAlreadyRegistered(patientDto.CPF);
            var model = _mapper.Map<PatientDto, Patient>(patientDto);
            if (cpfAlreadyRegistered)
                return BadRequest(new ErrorResponseModel("CPF já registrado"));

            await _patientRepository.AddAsync(model);
            return Ok(model);
        }

        // PUT api/<PatientController>/5
        /// <summary>
        /// Atualiza os dados do paciente
        /// </summary>
        /// <param name="id"></param>
        /// <param name="patientDto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PatientDto patientDto)
        {
            var actualData = await _patientRepository.FindByIdAsync(id);
            actualData = _mapper.Map<PatientDto, Patient>(patientDto, actualData);
            await _patientRepository.UpdateAsync(actualData);
            return Ok(actualData);
        }

        // DELETE api/<PatientController>/5
        /// <summary>
        /// Deleta um paciente pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await _patientRepository.FindByIdAsync(id);
            if (model == null)
                return BadRequest(new ErrorResponseModel("Paciente não encontrado") );

            return Ok();
        }
    }
}
