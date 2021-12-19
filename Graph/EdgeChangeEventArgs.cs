using System;

namespace MathLib.Graph
{
    public class EdgeChangeEventArgs : EventArgs
    {
        public int EdgeId { get; }

        public EdgeChangeEventArgs(int id)
        {
            EdgeId = id;
        }

    }
}
