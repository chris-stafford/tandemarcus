using System.Linq;
using API.Arcus.Domain.Model;
using API.Arcus.Infrastructure.Dto.Note;
using API.Arcus.Infrastructure.Dto.User;
using AutoMapper;

namespace API.Arcus.Infrastructure.Mapping
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Note, NoteGetResponseDto>();
			CreateMap<NotePatchRequestDto, Note>();
			CreateMap<Note, NotePatchResponseDto>();
			CreateMap<NotePostRequestDto, Note>();
			CreateMap<Note, NotePostResponseDto>();

			CreateMap<User, UserGetResponseDto>()
				.ForMember(
					x => x.Name,
					x => x.MapFrom(y => new[] { y.FirstName, y.MiddleName, y.LastName }
						.Where(x => !string.IsNullOrWhiteSpace(x))
						.Aggregate((x, y) => $"{x} {y}")));

			CreateMap<UserPatchRequestDto, User>();
			CreateMap<User, UserPatchResponseDto>();
			CreateMap<UserPostRequestDto, User>();
			CreateMap<User, UserPostResponseDto>();
		}
	}
}