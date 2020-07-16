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
            CreateMap<Unit, SimpleUnitViewModel>();
            CreateMap<Unit, SimpleUnitWithNameViewModel>()
                        .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Type.Name));
            CreateMap<Building, BuildingInfoViewModel>()
                        .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Type.Name))
                        .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Type.Price))
                        .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Type.Description))
                        .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.Type.ImageUrl))
                        .ForMember(dest => dest.RemainingRounds, opt => opt.MapFrom(src => src.ConstructionTimeLeft));
            CreateMap<Unit, AvailableUnitViewModel>()
                        .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Type.Name))
                        .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.Type.ImageUrl))
                        .ForMember(dest => dest.AvailableCount, opt => opt.MapFrom(src => src.Count))
                        .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Type.Id));
            CreateMap<Unit, UnitViewModel>()                                            
                        .ForMember(dest => dest.AttackScore, opt => opt.MapFrom(src => src.Type.AttackScore))                                           
                        .ForMember(dest => dest.CoralCostPerTurn, opt => opt.MapFrom(src => src.Type.CoralCostPerTurn))                                           
                        .ForMember(dest => dest.Count, opt => opt.MapFrom(src => src.Count))                                           
                        .ForMember(dest => dest.DefenseScore, opt => opt.MapFrom(src => src.Type.DefenseScore))                                           
                        .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.Type.ImageUrl))                                           
                        .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Type.Name))                                           
                        .ForMember(dest => dest.PearlCostPerTurn, opt => opt.MapFrom(src => src.Type.PearlCostPerTurn))                                           
                        .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Type.Price))                                           
                        .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Type.Id));
            CreateMap<UnitPurchaseDTO, SimpleUnitViewModel>()
                        .ForMember(dest => dest.Count, opt => opt.MapFrom(src => src.Count))
                        .ForMember(dest => dest.TypeId, opt => opt.MapFrom(src => src.TypeId));
            CreateMap<Upgrade, UpgradeViewModel>()
                        .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Type.Id))
                        .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Type.Name))
                        .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Type.Description))
                        .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.Type.ImageUrl))
                        .ForMember(dest => dest.IsPurchased, opt => opt.MapFrom(src => src.State == UpgradeState.Researched))
                        .ForMember(dest => dest.RemainingRounds, opt => opt.MapFrom(src => src.State == UpgradeState.Researched));
            CreateMap<User, ScoreboardViewModel>();
        }
    }
}
