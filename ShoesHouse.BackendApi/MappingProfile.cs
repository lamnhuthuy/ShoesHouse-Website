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
            CreateMap<OrderDetail, OrderDetailsViewModel>().ForMember(des => des.Size, act => act.MapFrom(src => src.Product.Size));
            CreateMap<OrderDetail, OrderDetailsViewModel>().ForMember(des => des.Amount, act => act.MapFrom(src => src.Amount));
            CreateMap<OrderDetail, OrderDetailsViewModel>().ForMember(des => des.ProductName, act => act.MapFrom(src => src.Product.Name));
            CreateMap<OrderDetail, OrderDetailsViewModel>().ForMember(des => des.FileName, act => act.MapFrom(src => src.Product.ProductImages.FirstOrDefault().FileName));
            CreateMap<ProductImage, ProductImageViewModel>();
            CreateMap<Comment, CommentViewModel>().ForMember(des => des.UserName, act => act.MapFrom(src => src.User.Name));
        }
    }
}
