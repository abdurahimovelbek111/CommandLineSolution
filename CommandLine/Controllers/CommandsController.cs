using AutoMapper;
using CommandLine.Data;
using CommandLine.Dtos;
using CommandLine.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CommandLine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommandAPIRepo _repository;
        private readonly IMapper _mapper;

        public CommandsController(ICommandAPIRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> CreateCommandAsync(CommandCreateDto commandCreatedDto)
        {
            var commandModel = _mapper.Map<Command>(commandCreatedDto);
            await _repository.CreateCommandAsync(commandModel);
            await _repository.SaveChangesAsync();
            var commandReadDto = _mapper.Map<CommandReadDto>(commandModel);
            return Created("", commandModel);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCommandAsync()
        {
            var commands = await _repository.GetAllCommandsAsync();
            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commands));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllCommandByIdAsync(int id)
        {
            var command = await _repository.GetAllCommandByIdAsync(id);
            if (command == null)
            {
                NotFound();
            }
            return Ok(_mapper.Map<CommandReadDto>(command));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommandByIdAsync(int id)
        {
            var command = await _repository.GetAllCommandByIdAsync(id);
            if (command == null)
                throw new ArgumentNullException(nameof(command));
            _repository.DeleteCommandAsync(command);
            await _repository.SaveChangesAsync();
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCommandByIdAsync(int id, CommandUpdateDto updateDto)
        {
            var command = await _repository.GetAllCommandByIdAsync(id);
            if (command == null)
                NotFound();

            _mapper.Map(updateDto, command);

            await _repository.UpdateCommandAsync(command);
            await _repository.SaveChangesAsync();

            return NoContent();
        }

    }
}
