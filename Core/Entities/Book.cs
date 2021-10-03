namespace Core.Entities
{
    public class Book: BaseEntity
    {
        public string Title { get; set; }    
        public Author Author { get; set; }
        public int AuthorId { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public Genre Genre { get; set; }
        public int GenreId { get; set; }
        public Publisher Publisher { get; set; }
        public int PublisherId { get; set; }
        public Language Language { get; set; }
        public int LanguageId { get; set; }

    }
}