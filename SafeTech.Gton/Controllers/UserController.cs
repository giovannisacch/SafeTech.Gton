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
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet("screen/home/{userId}")]
        public async Task<IActionResult> GetHomeInformations(int userId)
        {
            var model = await _userRepository.GetUserWithUnityAndOperationsByIdAsync(userId);
            return Ok(_mapper.Map<User, HomeScreenResponseDto>(model));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var modelList = await _userRepository.FindAllAsync();

            var dtoList = _mapper.Map<List<User>, List<UserDto>>(modelList);

            return Ok(dtoList);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UserDto userDto)
        {
            var actualData = await _userRepository.FindByIdAsync(id);
            if (actualData == null)
                return BadRequest(new ErrorResponseModel("Usuário não encontrado"));

            actualData = _mapper.Map<UserDto, User>(userDto, actualData);
            await _userRepository.UpdateAsync(actualData);
            return Ok(actualData);
        }

    }
}
