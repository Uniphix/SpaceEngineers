using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sandbox.ModAPI.Ingame
{
    /// <summary>
    /// Virtual mass base (common for artificial mass and spaceball)
    /// </summary>
    public interface IMyVirtualMassBase : IMyFunctionalBlock
    {
        /// <summary>
        /// Virtualmass weight
        /// </summary>
        float VirtualMass { get; }
    }
}
