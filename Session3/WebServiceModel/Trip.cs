namespace WebServiceModel
{
    public class Trip
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int numberOfStops { get; set; }
        public Stop[] stops { get; set; }
    }

    public class Stop
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }
}
