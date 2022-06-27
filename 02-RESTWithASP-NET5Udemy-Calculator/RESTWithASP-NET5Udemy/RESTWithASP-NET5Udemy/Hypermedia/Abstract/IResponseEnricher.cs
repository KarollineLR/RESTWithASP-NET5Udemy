using Microsoft.AspNetCore.Mvc.Filters;

namespace RESTWithASP_NET5Udemy.Hypermedia.Abstract
{
    public interface IResponseEnricher
    {
        bool CanEnrich(ResultExecutingContext context);
        Task Enrich(ResultExecutingContext context);
    }
}
