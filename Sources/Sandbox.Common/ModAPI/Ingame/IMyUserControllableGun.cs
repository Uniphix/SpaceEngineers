using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sandbox.ModAPI.Ingame
{
    /// <summary>
    /// Base turret and ship weapon interface
    /// </summary>
    public interface IMyUserControllableGun : IMyFunctionalBlock
    {
        /// <summary>
        /// Weapon/Turret is shooting
        /// </summary>
        bool IsShooting { get; }
    }
}
