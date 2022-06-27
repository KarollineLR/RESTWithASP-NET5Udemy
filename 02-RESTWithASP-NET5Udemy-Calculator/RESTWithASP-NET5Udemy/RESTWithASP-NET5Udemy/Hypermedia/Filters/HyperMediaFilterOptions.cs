using RESTWithASP_NET5Udemy.Hypermedia.Abstract;

namespace RESTWithASP_NET5Udemy.Hypermedia.Filters
{
    public class HyperMediaFilterOptions
    {
        public List<IResponseEnricher> ContentRespponseEnricherList { get; set; } = new List<IResponseEnricher>();
    }
}
