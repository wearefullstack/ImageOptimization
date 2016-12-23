namespace Geta.ImageOptimization.Messaging
{
    public class KrakenResponse
    {

        public bool success { get; set; }

        public string file_name { get; set; }

        public int original_size { get; set; }

        public int kraked_size { get; set; }

        public int saved_bytes { get; set; }

        public string kraked_url { get; set; }

    }
}