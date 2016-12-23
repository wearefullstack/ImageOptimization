using System.Net;
using Geta.ImageOptimization.Messaging;

namespace Geta.ImageOptimization.Helpers
{
    public static class KrakenMapper
    {
        public static ImageOptimizationResponse ConvertToResponse(this KrakenResponse krakenResponse)
        {
            if (krakenResponse == null)
            {
                return new ImageOptimizationResponse();
            }

            var webClient = new WebClient();

            var imageOptimizationResponse = new ImageOptimizationResponse
            {
                OriginalImageUrl = krakenResponse.file_name,
                OriginalImageSize = krakenResponse.original_size,
                PercentSaved = (krakenResponse.kraked_size / krakenResponse.original_size) * 100,
                OptimizedImageSize = krakenResponse.kraked_size,
                ErrorMessage = "An error has occurred while compressing image"
            };

            if (!string.IsNullOrEmpty(krakenResponse.file_name))
            {
                imageOptimizationResponse.OptimizedImage = webClient.DownloadData(krakenResponse.kraked_url);
                imageOptimizationResponse.Successful = true;
            }

            return imageOptimizationResponse;
        }
    }
}