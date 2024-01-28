using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTestHard
{
    public class Dijkstra
    {
        Dictionary<int, int> totalCosts = new Dictionary<int, int>();
        Dictionary<int, int> previousNode = new Dictionary<int, int>();
        Dictionary<int, int> priorityQueue = new Dictionary<int, int>();
        HashSet<int> visited = new HashSet<int>();
        Graph graph;

        public Dijkstra(Graph graph)
        {
            this.graph = graph;
            totalCosts.Add(0, 0);
            priorityQueue.Add(0, 0);
            previousNode.Add(0, -1);

            for (int i = 1; i < graph.nodeSet.Count; i++)
            {
                priorityQueue.Add(i, int.MaxValue);
                totalCosts.Add(i, int.MaxValue);
                previousNode.Add(i, -1);
            }
        }


        public void Run()
        {
            while(priorityQueue.Any())
            {
                var key = priorityQueue.MinBy(kvp => kvp.Value).Key;
                priorityQueue.Remove(key);
                var node = graph.nodeSet[key];
                visited.Add(key);

                foreach (var neighbor in node.neighbours)
                {

                    if(visited.Contains(neighbor.value))
                        continue;

                    var path = node.costs[neighbor.value] + totalCosts[node.value];
                    if (path < totalCosts[neighbor.value])
                    {
                        totalCosts[neighbor.value] = path;
                        previousNode[neighbor.value] = node.value;

                        priorityQueue[neighbor.value] = path;
                    }
                }
            }
        }

        public int GetCostForNode(int targetNode)
        {
            return totalCosts[targetNode];
        }
    }
}
