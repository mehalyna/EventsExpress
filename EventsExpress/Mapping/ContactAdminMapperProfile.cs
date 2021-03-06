﻿using AutoMapper;
using EventsExpress.Core.DTOs;
using EventsExpress.Db.Entities;
using EventsExpress.ViewModels;

namespace EventsExpress.Mapping
{
    public class ContactAdminMapperProfile : Profile
    {
        public ContactAdminMapperProfile()
        {
            CreateMap<ContactAdmin, ContactAdminDto>()
                .ForMember(dest => dest.MessageText, opt => opt.MapFrom(src => src.EmailBody))
                .ForMember(dest => dest.MessageId, opt => opt.MapFrom(src => src.Id));

            CreateMap<ContactAdminDto, ContactAdmin>()
                .ForMember(dest => dest.EmailBody, opt => opt.MapFrom(src => src.MessageText))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.MessageId))
                .ForMember(dest => dest.Assignee, opt => opt.Ignore())
                .ForMember(dest => dest.AssigneeId, opts => opts.Ignore())
                .ForMember(dest => dest.DateUpdated, opts => opts.Ignore())
                .ForMember(dest => dest.Sender, opts => opts.Ignore());

            CreateMap<ContactAdminDto, ContactAdminViewModel>()
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.MessageText));

            CreateMap<ContactAdminViewModel, ContactAdminDto>()
                .ForMember(dest => dest.MessageText, opt => opt.MapFrom(src => src.Description));
        }
    }
}
