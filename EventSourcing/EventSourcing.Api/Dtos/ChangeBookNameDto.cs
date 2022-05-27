namespace EventSourcing.Api.Dtos
{
    public class ChangeBookNameDto
    {
        public Guid Id { get; set; }
        public string NewName { get; set; }
    }
}
