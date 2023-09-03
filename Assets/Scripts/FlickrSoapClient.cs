using Gallery.FlickrAPIIntegration;
using System.Xml.Linq;
using VRTX.Net;

namespace Gallery.FlickrAPIIntegration.Client
{
    public class FlickrSoapClient : SoapClient
    {
        private string ApiKey { get; set; } = SoapConfig.API_KEY;

        public FlickrSoapClient () : base(SoapConfig.API_URL, SoapConfig.NAMESPACE)
        {

        }

        protected override XDocument SoapRequest<T> (T requestParameters)
        {
            XElement serialziedParameters = SoapUtilities.Serialize(requestParameters);
            serialziedParameters.Add(
                new XElement(_xsvc + "api_key", ApiKey),
                new XElement(_xsvc + "format", "soap2"));

            XDocument soapRequest = new XDocument(
                new XDeclaration("1.0", "UTF-8", "no"),
                new XElement(_xns + "Envelope",
                    new XAttribute(XNamespace.Xmlns + "xsi", _xsi),
                    new XAttribute(XNamespace.Xmlns + "xsd", _xsd),
                    new XAttribute(XNamespace.Xmlns + "s", _xns),
                    new XElement(_xns + "Body", serialziedParameters)
                ));

            return soapRequest;
        }
    }
}
