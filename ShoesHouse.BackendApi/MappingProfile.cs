using AutoMapper;
using ShoesHouse.Data.Entities;
using ShoesHouse.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoesHouse.BackendApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<ProductImage, ProductImageViewModel>();
            CreateMap<Comment, CommentViewModel>().ForMember(des => des.UserName, act => act.MapFrom(src => src.User.Name));
        }
    }
}
