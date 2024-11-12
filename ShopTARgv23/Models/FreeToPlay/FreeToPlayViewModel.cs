namespace ShopTARgv23.Models.FreeToPlay
{
    public class FreeToPlayViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public Uri Thumbnail { get; set; }
        public string ShortDescription { get; set; }
        public Uri GameUrl { get; set; }
        public string Genre { get; set; }
        public string Platform { get; set; }
        public string Publisher { get; set; }
        public string Developer { get; set; }
        public DateTimeOffset ReleaseDate { get; set; }
        public Uri FreetogameProfileUrl { get; set; }
    }
}
