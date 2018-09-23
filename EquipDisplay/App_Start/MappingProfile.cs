using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EquipDisplay.Models;
using EquipDisplay.Dtos;


namespace EquipDisplay.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Display, DisplayDto>();
            CreateMap<DisplayDto, Display>();

        }

    }
}