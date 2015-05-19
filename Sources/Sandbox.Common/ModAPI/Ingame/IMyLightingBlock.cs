using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sandbox.ModAPI.Ingame
{
    /// <summary>
    /// Base light interface
    /// </summary>
    public interface IMyLightingBlock : IMyFunctionalBlock, IMyPowerConsumerBlock
    {
        float Radius{ get;}
        float Intensity{get;}
        float BlinkIntervalSeconds{get;}
        float BlinkLenght{get;}
        float BlinkOffset{get;}
    }
}
