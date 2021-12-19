using System;

namespace MathLib.Graph
{
    public class VertexChangeEventArgs : EventArgs
    {
        public int VertexId { get; }

        public VertexChangeEventArgs(int id)
        {
            VertexId = id;
        }
    }
}
