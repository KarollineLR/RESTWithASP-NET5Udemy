namespace RESTWithASP_NET5Udemy.Hypermedia.Abstract
{
    public interface ISupportHyperMedia
    {
        List<HyperMediaLink> Links { get; set; }
    }
}
