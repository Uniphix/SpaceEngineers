using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sandbox.ModAPI.Ingame
{
    public interface IMyButtonPanel : IMyTerminalBlock, IMyPowerConsumerBlock
    {
        bool AnyoneCanUse
        {
            get;
        }
    }
}
