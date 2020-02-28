using AutoMapper;
using ClassPlanner.Application.Models.StudenstClassModel;
using ClassPlanner.Application.Models.StudentModel;
using ClassPlanner.Application.Models.TeacherModel;
using ClassPlanner.Application.Models.User;
using ClassPlanner.Domain.Entities;

namespace ClassPlanner.Application.Utils
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<StudentsClass, StudentsClassResponseDTO>().ReverseMap();
            CreateMap<StudentsClass, StudentsClassRequestDTO>().ReverseMap();
            CreateMap<Teacher, TeacherResponseDTO>().ReverseMap();
            CreateMap<Teacher, TeacherRequestDTO>().ReverseMap();
            CreateMap<Student, StudentResponseDTO>().ReverseMap();
            CreateMap<Student, StudentRequestDTO>().ReverseMap();
            CreateMap<User, UserReponseDTO>().ReverseMap();
            CreateMap<User, UserRequestDTO>().ReverseMap();                                                         
        }
    }
}
