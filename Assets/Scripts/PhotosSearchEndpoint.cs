using System.Xml.Serialization;
using VRTX.Net;

namespace Gallery.FlickrAPIIntegration.Endpoints
{
    public class PhotosSearch : SoapOperation<EchoRequest, EchoResponse, Echo>
    {
        public PhotosSearch () : base("echo") { }
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
        public string PerPage { get; set; }
        
    }
}
