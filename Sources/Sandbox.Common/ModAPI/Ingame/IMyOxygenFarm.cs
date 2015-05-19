using Sandbox.ModAPI.Ingame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sandbox.ModAPI.Ingame
{
    /// <summary>
    /// Oxygen farm interface
    /// </summary>
    public interface IMyOxygenFarm : IMyFunctionalBlock, IMyPowerConsumerBlock
    {
        /// <summary>
        /// Farm output in oxygen units per second - 1 astronaut consume 1 unit per second
        /// </summary>
        float GetOutput();
    }
}
