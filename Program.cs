using CodeTestHard;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

int numberOfTestCases = int.Parse(Console.ReadLine());

for (int i = 0; i < numberOfTestCases; i++)
{
    var graph = new Graph();
    NumberOfCavesAndTunnels(out int caves, out int tunnels);

    for (int j = 0; j < caves; j++)
    {
        graph.AddNode(j);
    }

    for (int tunnel = 0; tunnel < tunnels; tunnel++)
    {
        ParseTunnel(out int fromCave, out int toCave, out int cost);
        graph.AddUndirectedEdge(fromCave, toCave, cost);
    }

    var dijkstra = new Dijkstra(graph);

    dijkstra.Run();

    var numberOfTreasures = int.Parse(Console.ReadLine());
    var treasures = Console.ReadLine().Split(' ');
    int collectedTreasures = 0;
    List<int> tunnelsTraversed = new List<int>();
    for (int j = 0; j < numberOfTreasures; j++)
    {
        var cost = dijkstra.GetCostForNode(int.Parse(treasures[j]));
        if(!cost.Equals(int.MaxValue))
        tunnelsTraversed.Add(cost);
    }
    tunnelsTraversed.Sort();

    var remainingAir = int.Parse(Console.ReadLine());

    for (int j = 0;j < tunnelsTraversed.Count; j++)
    {
        if (remainingAir - (tunnelsTraversed[j] * 2) >= 0)
        {
            collectedTreasures++;
            remainingAir = remainingAir - (tunnelsTraversed[j] * 2);
        }
        else
            break;
    }

    Console.WriteLine(collectedTreasures);
}

void ParseTunnel(out int fromCave, out int toCave, out int cost)
{
    var line = Console.ReadLine().Split(' ');
    fromCave = int.Parse(line[0]);
    toCave = int.Parse(line[1]);
    cost = int.Parse(line[2]);
}

void NumberOfCavesAndTunnels(out int caves, out int tunnels)
{
    var line = Console.ReadLine().Split(' ');
    caves = int.Parse(line[0]);
    tunnels = int.Parse(line[1]);
}