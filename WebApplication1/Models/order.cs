namespace WebApplication1.Models
{
    public class order
    {
        public int id { get; set; }
        public int productid { get; set; }
        public string productname { get; set; }
        public int price { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string address { get; set; }
        public string telephone { get; set; }
        public DateTime date { get; set; }
    }
}
