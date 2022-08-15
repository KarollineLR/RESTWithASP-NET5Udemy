using RESTWithASP_NET5Udemy.Hypermedia;
using RESTWithASP_NET5Udemy.Hypermedia.Abstract;

namespace RESTWithASP_NET5Udemy.Data.VO
{

    public class PersonVO : ISupportHyperMedia
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
      
        public string LastName { get; set; }
       
        public string Address { get; set; }

        public string Gender { get; set; }
        public bool Enabled { get; set; }
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
