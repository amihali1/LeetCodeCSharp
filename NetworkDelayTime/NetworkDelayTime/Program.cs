// See https://aka.ms/new-console-template for more information


var solution = new Solution();
int[][] times;

Console.WriteLine("times = [[2,1,1],[2,3,1],[3,4,1]], n = 4, k = 2");
times = new int[][] { new int[] { 2, 1, 1 }, new int[] { 2, 3, 1 }, new int[] { 3, 4, 1 } };
Console.WriteLine("Expected Result: 2 | Actual Result: " + solution.NetworkDelayTime(times, 4, 2));

Console.WriteLine("times = [[1,2,1]], n = 2, k = 1");
times = new int[][] { new int[] { 1, 2, 1 } };
Console.WriteLine("Expected Result: 1 | Actual Result: " + solution.NetworkDelayTime(times, 2, 1));

Console.WriteLine("times = [[1,2,1]], n = 2, k = 2");
times = new int[][] { new int[] { 1, 2, 1 } };
Console.WriteLine("Expected Result: -1 | Actual Result: " + solution.NetworkDelayTime(times, 2, 2));

Console.WriteLine("times = [[1,2,1],[2,1,3]], n = 2, k = 2");
times = new int[][] { new int[] { 1, 2, 1 }, new int[] { 2, 1, 3 } };
Console.WriteLine("Expected Result: 3 | Actual Result: " + solution.NetworkDelayTime(times, 2, 2));

Console.WriteLine("times = [[1,2,1],[2,3,2]], n = 3, k = 1");
times = new int[][] { new int[] { 1, 2, 1 }, new int[] { 2, 3, 2 } };
Console.WriteLine("Expected Result: 3 | Actual Result: " + solution.NetworkDelayTime(times, 3, 1));

Console.WriteLine("times = [[1, 2, 1],[2, 3, 2],[1, 3, 2]], n = 3, k = 1");
times = new int[][] { new int[] { 1, 2, 1 }, new int[] { 2, 3, 2 }, new int[] { 1, 3, 2 } };
Console.WriteLine("Expected Result: 2 | Actual Result: " + solution.NetworkDelayTime(times, 3, 1));

public class Solution
{
    public int NetworkDelayTime(int[][] times, int n, int k)
    {
        var createdNodes = new Dictionary<int, Node>();
        var nodeHash = new HashSet<int>();

        for (int i = 1; i <= n; i++)
            nodeHash.Add(i);      

        foreach (var timeArray in times)
        {
            Node node;
            Node target;
            if (!createdNodes.ContainsKey(timeArray[0]))
            {
                node = new Node(timeArray[0]);
                createdNodes.Add(timeArray[0], node);
            }
            else
            {
                node = createdNodes[timeArray[0]];
            }
            if (!createdNodes.ContainsKey(timeArray[1]))
            {
                target = new Node(timeArray[1]);
                createdNodes.Add(timeArray[1], target);
            }
            else
            {
                target = createdNodes[timeArray[1]];
            }
                node.AddTarget(target, timeArray[2]);                
        }

        if (createdNodes.ContainsKey(k))
        {
            var kNode = createdNodes[k];
            nodeHash.Remove(k);

            var endingTotalTime = SearchToEnd(kNode, nodeHash, 0, 0, 0);

            if (!nodeHash.Any())
                return endingTotalTime;
        }

        return -1;
    }

    public int SearchToEnd(Node node, HashSet<int> nodeHash, int timeToNode, int totalTime, int highestTime)
    {
        totalTime += timeToNode;
        if (totalTime > highestTime)
            highestTime = totalTime;

        if (nodeHash.Any())
        {
            foreach (var nextNode in node.nextNodes)
            {
                nodeHash.Remove(nextNode.node.position);
                highestTime = SearchToEnd(nextNode.node, nodeHash, nextNode.timeToNode, totalTime, highestTime);
            }
        }

        return highestTime;
    }
}

public class Node
{
    internal int position;
    internal List<(Node node, int timeToNode)> nextNodes;
    public Node(int pos)
    {
        position = pos;
        nextNodes = new List<(Node node, int timeToNode)>();
    }

    internal void AddTarget(Node node, int time)
    {
        nextNodes.Add((node, time));
    }
}