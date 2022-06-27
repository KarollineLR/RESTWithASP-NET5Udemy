using Microsoft.AspNetCore.Mvc;
using RESTWithASP_NET5Udemy.Data.VO;
using RESTWithASP_NET5Udemy.Hypermedia.Constants;
using System.Text;
using static RESTWithASP_NET5Udemy.Repository.UserRepository;

namespace RESTWithASP_NET5Udemy.Hypermedia.Envicher
{
    public class BookEnricher : ContentResponseEnricher<BookVO>
    {
        private readonly object _look = new object();


        protected override Task EnrichModel(BookVO content, IUrlHelper urlHelper)
        {
            var path = "api/book/v1";
            string link = GetLink(content.Id, urlHelper, path);

            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.GET,
                Href = Hashing.ToSHA256("test"),
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultGet
                
            });
            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.POST,
                Href = link,
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultPost

            });
            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.PUT,
                Href = link,
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultPut

            });
            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.DELETE,
                Href = link,
                Rel = RelationType.self,
                Type = "int"

            });
            return null;
        }

        private string GetLink(long id, IUrlHelper urlHelper, string path)
        {
            lock (_look)
            {
                var url = new { controller = path, id = id };
                return new StringBuilder(urlHelper.Link("DefaultApi", url))
                    .Replace("%2F", "/").ToString();
            };
        }
    }
}
