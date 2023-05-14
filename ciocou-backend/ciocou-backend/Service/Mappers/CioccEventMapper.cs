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
        public static ReadCioccEventDto toDto(CioccEvent cioccEvent)
        {
            var readCiocc = new ReadCioccEventDto();
            readCiocc.Guid = cioccEvent.Guid;
            readCiocc.UserName1 = cioccEvent.UserName1;
            readCiocc.UserName2 = cioccEvent.UserName2;
            readCiocc.Winner = cioccEvent.Winner;
            return readCiocc;
        }
    }
}
