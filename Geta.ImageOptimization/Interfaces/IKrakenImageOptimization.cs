using Geta.ImageOptimization.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geta.ImageOptimization.Interfaces
{
    public interface IKrakenImageOptimization
    {
        ImageOptimizationResponse ProcessImage(ImageOptimizationRequest imageOptimizationRequest);
    }
}
