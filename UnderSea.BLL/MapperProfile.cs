using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using UnderSea.BLL.DTO;
using UnderSea.BLL.ViewModels;
using UnderSea.DAL.Models;
using UnderSea.DAL.Models.Buildings;
using UnderSea.DAL.Models.Units;
using UnderSea.DAL.Models.Upgrades;

namespace UnderSea.BLL
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {

            CreateMap<Building, BuildingInfoViewModel>()
                        .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Type.Id))
                        .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Type.Name))
                        .ForMember(dest => dest.PearlPrice, opt => opt.MapFrom(src => src.Type.PearlPrice))
                        .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Type.Description))
                        .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.Type.ImageUrl))
                        .ForMember(dest => dest.StonePrice, opt => opt.MapFrom(src => src.Type.StonePrice));
            CreateMap<UnitPurchaseDTO, SimpleUnitViewModel>()
                        .ForMember(dest => dest.Count, opt => opt.MapFrom(src => src.Count))
                        .ForMember(dest => dest.TypeId, opt => opt.MapFrom(src => src.TypeId));
            CreateMap<Upgrade, UpgradeViewModel>()
                        .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Type.Id))
                        .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Type.Name))
                        .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Type.Description))
                        .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.Type.ImageUrl))
                        .ForMember(dest => dest.IsPurchased, opt => opt.MapFrom(src => src.State == UpgradeState.Researched));
            CreateMap<User, ScoreboardViewModel>();
            CreateMap<Building, StatusBarViewModel.StatusBarBuilding> ()
                        .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.Type.SmallIconUrl))
                        .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Type.Name))
                        .ForMember(dest => dest.TypeId, opt => opt.MapFrom(src => src.Type.Id)); 
        }
    }
}
