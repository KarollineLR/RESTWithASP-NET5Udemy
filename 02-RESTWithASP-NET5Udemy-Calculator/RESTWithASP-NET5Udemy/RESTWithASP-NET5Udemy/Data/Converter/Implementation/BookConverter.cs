using RESTWithASP_NET5Udemy.Data.VO;
using RESTWithASP_NET5Udemy.Model;

namespace RESTWithASP_NET5Udemy.Data.Converter.Contract
{
    public class BookConverter : IParser<BookVO, Book>, IParser<Book, BookVO>
    {
        public Book Parse(BookVO origin)
        {
            if (origin == null) return null;
            return new Book
            {
                Id = origin.Id,
                nome = origin.nome,
                categoria = origin.categoria,
                autor = origin.autor,
                preco = origin.preco
            };

        }

        public BookVO Parse(Book origin)
        {
            if (origin == null) return null;
            return new BookVO
            {
                Id = origin.Id,
                nome = origin.nome,
                categoria = origin.categoria,
                autor = origin.autor,
                preco = origin.preco
            };
        }


        public List<BookVO> Parse(List<Book> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();

        }

        public List<Book> Parse(List<BookVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

    }
}
