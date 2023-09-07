using System.Collections.Generic;
using System.Xml.Serialization;
using VRTX.Net;

namespace Gallery.FlickrAPIIntegration.Endpoints
{
    public class PhotosSearch : SoapOperation<PhotosSearchRequest, PhotosSearchResponse, PhotosSearch>
    {
        public PhotosSearch () : base("photosSearch") { }
    }

    [XmlRoot(ElementName = "FlickrResponse", Namespace = SoapConfig.NAMESPACE)]
    public class PhotosSearchResponse : SoapResponseType
    {
        [XmlArray("photos")]
        [XmlArrayItem(typeof(Photo), ElementName = "photo")]
        public List<Photo> PhotoCollection { get; set; }
    }

    public class Photos
    {
        [XmlArrayItem("photo")]
        public List<Photo> PhotoCollection { get; set; }
    }

    public class Photo
    {
        [XmlAttribute(AttributeName = "url_s")]
        public string ThumbnailUrl { get; set; }
        [XmlAttribute(AttributeName = "url_c")]
        public string MediumUrl { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public ulong ID { get; set; }
        [XmlAttribute(AttributeName = "title")]
        public string Title { get; set; }
    }

    [XmlRoot(ElementName = "FlickrRequest", Namespace = SoapConfig.NAMESPACE)]
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
