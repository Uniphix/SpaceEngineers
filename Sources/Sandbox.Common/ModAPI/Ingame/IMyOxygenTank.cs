using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sandbox.ModAPI.Ingame
{
    /// <summary>
    /// Oxygen tank interface
    /// </summary>
    public interface IMyOxygenTank : IMyFunctionalBlock, IMyPowerConsumerBlock
    {
        /// <summary>
        /// Oxygen level
        /// </summary>
        /// <returns>oxygen level as decimals (1 = 100%)</returns>
        float GetOxygenLevel();
    }
}
