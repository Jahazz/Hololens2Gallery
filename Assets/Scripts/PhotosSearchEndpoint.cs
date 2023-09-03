using System.Xml.Serialization;
using VRTX.Net;

namespace Gallery.FlickrAPIIntegration.Endpoints
{
    public class PhotosSearch : SoapOperation<PhotosSearchRequest, PhotosSearchResponse, PhotosSearch>
    {
        public PhotosSearch () : base("photosSearch") { }
    }

    [XmlRoot(ElementName = "FlickrResponse", Namespace = Config.NAMESPACE)]
    public class PhotosSearchResponse : SoapResponseType
    {
        [XmlElement("value")]
        public string Value { get; set; }
    }

    [XmlRoot(ElementName = "FlickrRequest", Namespace = Config.NAMESPACE)]
    public class PhotosSearchRequest : SoapRequestType
    {
        [XmlElement("method")]
        public string Method { get; set; } 
        [XmlElement("text")]
        public string Text { get; set; }
        [XmlElement("extras")]
        public string Extras { get; set; }
        [XmlElement("per_page")]
        public int PerPage { get; set; }
        
    }
}
