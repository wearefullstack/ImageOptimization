using EPiServer.ServiceLocation;
using Geta.ImageOptimization.Configuration;
using Geta.ImageOptimization.Helpers;
using Geta.ImageOptimization.Interfaces;
using Geta.ImageOptimization.Messaging;
using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;

namespace Geta.ImageOptimization.Implementations
{
    [ServiceConfiguration(typeof(IImageOptimization))]
    public class ImageOptimization : IImageOptimization
    {
        private readonly IKrakenProxy _krakenProxy;

        public ImageOptimization() : this(ServiceLocator.Current.GetInstance<IKrakenProxy>())
        {
        }

        public ImageOptimization(IKrakenProxy krakenProxy)
        {
            this._krakenProxy = krakenProxy;
        }

        string ReplaceHost(string original, string newHostName)
        {
            var builder = new UriBuilder(original);
            builder.Host = newHostName;
            return builder.Uri.ToString();
        }

        public ImageOptimizationResponse ProcessImage(ImageOptimizationRequest imageOptimizationRequest)
        {
            try
            {

                if (imageOptimizationRequest == null)
                {
                    return new ImageOptimizationResponse();
                }

                var ParentAuth = new Auth
                {
                   
                    api_key = ImageOptimizationSettings.Instance.ApiKey,
                    api_secret = ImageOptimizationSettings.Instance.ApiSecret
                };

                string strimage_url = imageOptimizationRequest.ImageUrl;


                var krakenRequest = new KrakenRequest
                {
                    auth = ParentAuth,
                    url = strimage_url,
                    wait = true,
                    lossy = true
                };
                KrakenResponse krakenResponse = this._krakenProxy.ProcessImage(krakenRequest);

                return krakenResponse.ConvertToResponse();

            }catch(Exception exception)
            {
                Debug.WriteLine(exception.ToString());
                throw new Exception(exception.Message);
            }
        }
    }
}