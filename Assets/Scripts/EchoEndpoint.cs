using System.Xml.Serialization;
using VRTX.Net;

namespace Gallery.FlickrAPIIntegration.Endpoints
{
    public class Echo : SoapOperation<EchoRequest, EchoResponse, Echo>
    {
        public Echo () : base("echo") { }
    }

    [XmlRoot(ElementName = "FlickrResponse", Namespace = Config.NAMESPACE)]
    public class EchoResponse : SoapResponseType
    {
        [XmlElement("value")]
        public string Value { get; set; }
    }

    [XmlRoot(ElementName = "FlickrRequest", Namespace = Config.NAMESPACE)]
    public class EchoRequest : SoapRequestType
    {
        [XmlElement("method")]
        public string Method { get; set; } = "flickr.test.echo";
        [XmlElement("value")]
        public string Value { get; set; }
    }
}


