namespace API.Dtos
{
    public class BookToReturnDto
    {
        public int Id { get; set; }
        public string Title { get; set; }    
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public string Genre { get; set; }
        public string Publisher { get; set; }
        public string Language { get; set; }
    }
}