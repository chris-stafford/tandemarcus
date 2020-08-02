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

			CreateMap<User, UserGetResponseDto>();
			CreateMap<NotePatchRequestDto, User>();
			CreateMap<User, NotePatchResponseDto>();
			CreateMap<NotePostRequestDto, User>();
			CreateMap<User, NotePostResponseDto>();
		}
	}
}