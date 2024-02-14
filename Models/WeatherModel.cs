namespace LR5.Models
{
    public class WeatherModel
    {
        public string name { get; set; }
        public main main { get; set; }
        public wind wind { get; set; }
        public List<weather> weather { get; set; }
    }

    public class weather
    {
        public string main { get; set; }
        public string description { get; set; }
    }

    public class main
    {
        public double temp { get; set; }
        public double pressure { get; set; }
        public double humidity { get; set; }
    }

    public class wind
    {
        public double speed { get; set; }
    }
}