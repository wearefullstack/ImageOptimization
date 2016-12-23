using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using EPiServer;
using EPiServer.ServiceLocation;
using Geta.ImageOptimization.Interfaces;
using Geta.ImageOptimization.Messaging;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;
using System.Diagnostics;
using System;

namespace Geta.ImageOptimization.Implementations
{
    [ServiceConfiguration(typeof(IKrakenProxy))]
    public class KrakenProxy : IKrakenProxy
    {
        private readonly WebClient _webClient = new WebClient();
       

        public KrakenResponse ProcessImage(KrakenRequest krakenRequest)
        {
            try

            {

                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(KrakenRequest));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, krakenRequest);

                string jsonString = Encoding.Default.GetString(mem.ToArray());

                _webClient.Headers["Content-type"] = "application/json";

                string result = _webClient.UploadString("https://api.kraken.io/v1/url", "POST", jsonString);

                var json_serializer = new JavaScriptSerializer();
                var response = json_serializer.Deserialize<KrakenResponse>(result);

                return response;


            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.ToString());
                throw new Exception(exception.Message);
            }

        }

    }
}