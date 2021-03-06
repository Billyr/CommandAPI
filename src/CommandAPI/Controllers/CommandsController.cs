using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using CommandAPI.Data;
using AutoMapper;
using CommandAPI.Dtos;
using CommandAPI.Models;

namespace CommandAPI.Controllers 
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


        [HttpGet(Name = "GetAllCommands")]
        public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands();
            //return Ok(commandItems);
            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
        }

        [HttpGet("{id}", Name = "GetCommandById")]
        public ActionResult<CommandReadDto> GetCommandById(int id)
        {
            var commandItem = _repository.GetCommandById(id);
            if (commandItem == null)
                return NotFound();
            return Ok(_mapper.Map<CommandReadDto>(commandItem));

        }


        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
        {
            var commandModel = _mapper.Map<Command>(commandCreateDto);
            _repository.CreateCommnad(commandModel);
            _repository.SaveChanges();

            var commandReadDto = _mapper.Map<CommandReadDto>(commandModel);

            return CreatedAtRoute(nameof(GetCommandById), new { Id = commandReadDto.Id }, commandReadDto);
        }


        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, CommandUpdateDto commandUpdateDto)
        {
            var commandModelFromRepo = _repository.GetCommandById(id);
            if (commandModelFromRepo == null)
                return NotFound();

            _mapper.Map(commandUpdateDto, commandModelFromRepo);

            _repository.UpdateCommnad(commandModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var command = _repository.GetCommandById(id);
            if (command == null)
                return NotFound();
            _repository.DeleteCommnad(command);
            _repository.SaveChanges();
            return NoContent();
        }

    }
}
