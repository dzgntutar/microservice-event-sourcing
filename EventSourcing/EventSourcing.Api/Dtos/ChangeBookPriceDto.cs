namespace EventSourcing.Api.Dtos
{
    public class ChangeBookPriceDto
    {
        public Guid Id { get; set; }
        public decimal NewPrice { get; set; }
    }
}
