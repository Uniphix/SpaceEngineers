using Sandbox.Common.ObjectBuilders;
using Sandbox.Definitions;
using Sandbox.Game.Entities.Cube;
using Sandbox.ModAPI.Ingame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sandbox.Game.Entities
{
    [MyCubeBlockType(typeof(MyObjectBuilder_ControlPanel))]
    class MyControlPanel : MyFunctionalBlock, IMyControlPanel
    {
        private int debugpoint = 1;
        public new MyControlPanelDefinition BlockDefinition { get { return base.BlockDefinition as MyControlPanelDefinition; } }
    }
}