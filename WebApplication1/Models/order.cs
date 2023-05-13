namespace WebApplication1.Models
{
    public class order
    {
        public int id { get; set; }
        public int productid { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public string clientname { get; set; }
        public string clientsurname { get; set; }
        public string address { get; set; }
        public int telephone { get; set; }
        public DateTime date { get; set; }
    }
}
