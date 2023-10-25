using AutoMapper;
using WebApiAutores.Dtos;
using WebApiAutores.Entities;

namespace WebApiAutores.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            MapsForBooks();    
            
        }

        void MapsForBooks()
        {
            CreateMap<BookDto, Book>().ReverseMap();

        }


    }
}
