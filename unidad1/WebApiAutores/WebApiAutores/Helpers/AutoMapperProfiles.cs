﻿using AutoMapper;
using WebApiAutores.Dtos.Autores;
using WebApiAutores.Dtos.Books;
using WebApiAutores.Entities;

namespace WebApiAutores.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            MapsForBooks();    
            MapsForAutores();
        }

        private void MapsForAutores() 
        {
            CreateMap<Autor, AutorDto>();
            CreateMap<Autor, AutorGetByIdDto>();
            CreateMap<AutorCreateDto, Autor>();
        }

        private void MapsForBooks()
        {
            //CreateMap<BookDto, Book>().ReverseMap();

            CreateMap<Book, BookDto>()
                .ForPath(dest => dest.AutorNombre, opt => opt.MapFrom(src => src.Autor.Name));
            
            CreateMap<BookCreateDto, Book>();
        }


    }
}
