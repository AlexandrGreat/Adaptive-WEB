namespace LR5.Models
{
    public class ResponseModel
    {
        public string response { get; set; }
        public int status { get; set; }
        public string headers { get; set; }

        public string ToString()
        {
            return ("\nResponse: " + response + "\nStatus: " + status + "\nData: " + headers);
        }
    }
}
