using AutoMapper;
using BookManager.Application.ViewModels;
using BookManager.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookManager.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<Book, BookViewModel>()
                .ForMember(d => d.Isbn, o => o.MapFrom(s => s.Isbn.Isbn));

            CreateMap<Author, AuthorViewModel>()
                .ForMember(d => d.Cpf, d => d.MapFrom(s => s.Cpf.Cpf));

            CreateMap<Category, CategoryViewModel>();
        }
    }
}
