using Service.DTOs;

namespace Service.Mappers
{
    public static class CioccEventMapper
    {
        public static CioccEvent fromDto(CreateCioccEventDto cioccEventDto)
        {
            return CioccEvent.builder()
                .UserName1(cioccEventDto.UserName1)
                .Build();
        }
    }
}
