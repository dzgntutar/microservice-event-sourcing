namespace EventSourcing.Api.Dtos
{
    public class CreateBookDto
    {
        public string Name { get; set; } = default!;
        public string Author { get; set; } = default!;
        public string Year { get; set; } = default!;
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
