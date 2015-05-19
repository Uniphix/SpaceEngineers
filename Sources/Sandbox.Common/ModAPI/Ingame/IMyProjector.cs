using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sandbox.ModAPI.Ingame
{
    /// <summary>
    /// Projector interface
    /// </summary>
    public interface IMyProjector : IMyFunctionalBlock, IMyPowerConsumerBlock
    {
        /// <summary>
        /// Projection offset on X axis - in cubes
        /// </summary>
        int ProjectionOffsetX { get; }

        /// <summary>
        /// Projection offset Y axis - in cubes
        /// </summary>
        int ProjectionOffsetY { get; }

        /// <summary>
        /// Projection offset Z axis - in cubes
        /// </summary>
        int ProjectionOffsetZ { get; }

        /// <summary>
        /// Projection rotation around X axis
        /// </summary>
        int ProjectionRotX { get; }

        /// <summary>
        /// Projection rotation around Y axis
        /// </summary>
        int ProjectionRotY { get; }

        /// <summary>
        /// Projection rotation around Z axis
        /// </summary>
        int ProjectionRotZ { get; }

        /// <summary>
        /// Blocks remaining to build
        /// </summary>
        int RemainingBlocks { get; }

        /// <summary>
        /// Load random blueprint with name matching pattern
        /// </summary>
        void LoadRandomBlueprint(string searchPattern);

        /// <summary>
        /// Load random blueprint with matching name
        /// </summary>
        void LoadBlueprint(string name);
    }
}
