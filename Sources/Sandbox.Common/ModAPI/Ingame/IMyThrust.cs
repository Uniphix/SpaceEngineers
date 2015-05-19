﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sandbox.ModAPI.Ingame
{
    /// <summary>
    /// Base thruster interface
    /// </summary>
    public interface IMyThrust: IMyFunctionalBlock, IMyPowerConsumerBlock
    {
        /// <summary>
        /// Thrust override value
        /// </summary>
        float ThrustOverride { get;}
    }
}
