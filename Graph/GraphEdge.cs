using System;

namespace MathLib.Graph
{
    public readonly struct GraphEdge : IEquatable<GraphEdge>
    {
        public int FirstVertex { get; }

        public int SecondVertex { get; }

        public GraphEdge(int firstVertex, int secondVertex)
        {
            FirstVertex = firstVertex;
            SecondVertex = secondVertex;
        }

        #region IEquatable<GraphEdge> Members

        public bool Equals(GraphEdge other)
        {
            return FirstVertex == other.FirstVertex && SecondVertex == other.SecondVertex;            
        }

        #endregion
    }
}
