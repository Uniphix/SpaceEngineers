using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sandbox.ModAPI.Ingame
{
    public interface IMyWarhead: IMyFunctionalBlock
    {
        bool IsCountingDown { get; }
        float DetonationTime { get; }
    }
}
