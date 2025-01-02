namespace BookManagerAPI.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public DateTime PublicationDate { get; set; }

        // Constructor to initialize all non-nullable properties
        public Book(string title, string author, string isbn, DateTime publicationDate)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            PublicationDate = publicationDate;
        }
    }
}
