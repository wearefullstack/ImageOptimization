using Geta.ImageOptimization.Messaging;

namespace Geta.ImageOptimization.Interfaces
{
    public interface IKrakenProxy
    {
        KrakenResponse ProcessImage(KrakenRequest krakenRequest);
    }
}