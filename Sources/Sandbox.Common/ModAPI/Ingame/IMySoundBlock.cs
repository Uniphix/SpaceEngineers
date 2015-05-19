using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sandbox.ModAPI.Ingame
{
    /// <summary>
    /// Sound block interface
    /// </summary>
    public interface IMySoundBlock : IMyFunctionalBlock, IMyPowerConsumerBlock
    {
        /// <summary>
        /// Current volume
        /// </summary>
        float Volume { get; }

        /// <summary>
        /// Current audible range
        /// </summary>
        float Range { get; }

        /// <summary>
        /// Is sound for block defined ?
        /// </summary>
        bool IsSoundSelected{ get; }

        /// <summary>
        /// Current length of sound production
        /// </summary>
        float LoopPeriod { get; }
    }
}
