using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sandbox.ModAPI.Ingame
{
    /// <summary>
    /// Timer block interface
    /// </summary>
    public interface IMyTimerBlock : IMyFunctionalBlock, IMyPowerConsumerBlock
    {
        /// <summary>
        /// Timer block start delay countdown active
        /// </summary>
        bool IsCountingDown { get; }

        /// <summary>
        /// Delay before first instruction in block
        /// </summary>
        float TriggerDelay { get; }
    }
}
