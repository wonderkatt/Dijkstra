using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTestHard
{
    public class Graph
    {
        public List<Node> nodeSet = new List<Node>();

        public Graph() { }


        public void AddNode(int value)
        {
            nodeSet.Add(new Node(value));
        }

        public void AddUndirectedEdge(int from, int to, int cost)
        {
            var toNode = nodeSet[to];
            var fromNode = nodeSet[from];

            fromNode.neighbours.Add(toNode);
            fromNode.costs.Add(to, cost);

            toNode.neighbours.Add(fromNode);
            toNode.costs.Add(from, cost);
        }
    }
}
