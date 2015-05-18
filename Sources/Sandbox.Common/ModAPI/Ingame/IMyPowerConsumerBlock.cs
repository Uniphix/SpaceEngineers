using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sandbox.ModAPI.Ingame
{
    namespace Sandbox.ModAPI.Ingame
    {
        /// <summary>
        /// Block that requires power source (electricity)
        /// Access to power information
        /// </summary>
        public interface IMyPowerConsumerBlock
        {
            /// <summary>
            /// Current consumed power in [MW].
            /// </summary>
            float CurrentInput { get; }

            /// <summary>
            /// IsAdaptible consumers can work on less than their required power, but they will be less effective.
            /// </summary>
            bool IsAdaptible { get; }

            /// <summary>
            /// Is connected to power source
            /// </summary>
            bool IsPowered { get; }

            /// <summary>
            /// Does device require power at all? (some blocks doesn't require power)
            /// </summary>
            bool IsPowerNeeded { get; }

            /// <summary>
            /// Theoretical maximum of required input in [MW]. This can be different from RequiredInput, but
            /// it has to be >= RequiredInput. It is used to check whether current power supply can meet
            /// demand under stress. 
            /// </summary>
            float MaxRequiredPower { get; }

            /// <summary>
            /// Current required input in [MW].
            /// </summary>
            float RequiredPower { get; }
        }
    }
}
