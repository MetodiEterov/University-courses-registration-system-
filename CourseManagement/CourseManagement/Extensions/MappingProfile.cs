using AutoMapper;

using DomainLayer.DTOs;
using DomainLayer.Entities;

namespace CourseManagement.Extensions
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<StudentRegistration, User>()
			.ForMember(u => u.UserName, opt => opt.MapFrom(x => x.StudentName))
			.ForMember(u => u.Email, opt => opt.MapFrom(x => x.StudentEmail))
			.ForMember(u => u.StudentPassword, opt => opt.MapFrom(x => x.StudentPassword.Encrypt()));

			CreateMap<Student, StudentRegistration>().ReverseMap()
			.ForMember(u => u.StudentPassword, opt => opt.MapFrom(x => x.StudentPassword.Encrypt()));

			CreateMap<Course, CourseCreate>().ReverseMap()
			.ForMember(u => u.CourseName, opt => opt.MapFrom(x => x.CourseName));

			CreateMap<CourseRegister, StudentCourse>()
				.ForMember(u => u.CourseId, opt => opt.MapFrom(x => x.CourseId));

			CreateMap<CourseRegister, Course>()
				.ForMember(u => u.Id, opt => opt.MapFrom(x => x.CourseId));

			CreateMap<StudentLogin, StudentRegistration>()
				.ForMember(u => u.StudentEmail, opt => opt.MapFrom(x => x.StudentEmail));

			CreateMap<CourseEdit, Course>()
				.ForMember(u => u.CourseName, opt => opt.MapFrom(x => x.CourseName))
				.ForMember(u => u.Id, opt => opt.MapFrom(x => x.CourseId));
		}
	}
}
