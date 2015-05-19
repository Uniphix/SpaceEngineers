using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sandbox.ModAPI.Ingame
{
    public interface IMyShipToolBase : IMyFunctionalBlock, IMyPowerConsumerBlock
    {
        bool UseConveyorSystem { get; }
    }
}
