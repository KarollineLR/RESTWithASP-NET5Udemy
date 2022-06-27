
using RESTWithASP_NET5Udemy.Hypermedia;
using RESTWithASP_NET5Udemy.Hypermedia.Abstract;
using System.Text.Json.Serialization;

namespace RESTWithASP_NET5Udemy.Data.VO
{
    public class BookVO : ISupportHyperMedia
    {
        public long Id { get; set; }
        public string nome { get; set; }
        public string categoria { get; set; }

        [JsonPropertyName("Escritor")]
        public string autor { get; set; }

        [JsonIgnore]
        public long preco { get; set; }
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
