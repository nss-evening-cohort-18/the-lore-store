using backend.Models;
using System.Data.SqlClient;

namespace backend.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly IConfiguration _config;
        public BookRepository(IConfiguration config)
        {
            _config = config;
        }
        public SqlConnection Connection => new SqlConnection(_config.GetConnectionString("DefaultConnection"));
        public List<Book> GetBooks()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = Connection.CreateCommand())
                {
                    cmd.CommandText = @"
                                SELECT id,
                                        title,
                                        authorFirstName,
                                        authorLastName,
                                        datePublished,
                                        description,
                                        isFiction,
                                        subGenre,
                                        price,
                                        inventoryQuantity,
                                        photoUrl
                                FROM [dbo].[Book]
                                        ";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Book> books = new List<Book>();
                        while (reader.Read())
                        {
                            Book book = new Book()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("id")),
                                Title = reader.GetString(reader.GetOrdinal("title")),
                                AuthorFirstName = reader.GetString(reader.GetOrdinal("authorFirstName")),
                                AuthorLastName = reader.GetString(reader.GetOrdinal("authorLastName")),
                                DatePublished = reader.GetString(reader.GetOrdinal("datePublished")),
                                Description = reader.GetString(reader.GetOrdinal("description")),
                                IsFiction = reader.GetInt32(reader.GetOrdinal("isFiction")),
                                SubGenre = reader.GetString(reader.GetOrdinal("subGenre")),
                                Price = reader.GetFloat(reader.GetOrdinal("price")),
                                InventoryQuantity = reader.GetInt32(reader.GetOrdinal("inventoryQuantity")),
                                PhotoUrl = reader.GetString(reader.GetOrdinal("photoUrl"))
                            };

                            books.Add(book);
                        }

                        return books;
                    }
                }
            }
        }
    
    }
}
