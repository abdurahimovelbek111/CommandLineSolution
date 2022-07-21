using AutoMapper;
using CommandLine.Dtos;
using CommandLine.Models;

namespace CommandLine.Profiles
{
    public class CommandsProfile:Profile
    {
        public CommandsProfile()
        {
            CreateMap<CommandCreateDto, Command>();
            CreateMap<Command, CommandReadDto>();
            CreateMap<CommandUpdateDto, Command>();
        }
    }
}
