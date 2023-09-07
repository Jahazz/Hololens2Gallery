namespace Gallery.FlickrAPIIntegration.Endpoints
{
    public static class RequestFactory
    {
        public static EchoRequest GetEchoRequest (string value)
        {
            return new EchoRequest()
            {
                Value = value,
                Method = "flickr.test.echo"
            };
        }

        public static PhotosSearchRequest GetPhotosSearchRequest (string text, int perPage)
        {
            return new PhotosSearchRequest()
            {
                Method = "flickr.photos.search",
                Extras = "url_s, url_c",
                Text = text,
                PerPage = perPage
            };
        }
    }
}
