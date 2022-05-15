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

public class Solution
{
    public int NetworkDelayTime(int[][] times, int n, int k)
    {
        var createdNodes = new Dictionary<int, Node>();
        var nodeHash = new HashSet<int>();
        var totalTime = 0;

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

            var endingTotalTime = SearchToEnd(kNode, nodeHash, totalTime);

            if (!nodeHash.Any())
                return endingTotalTime;
        }

        return -1;
    }

    public int SearchToEnd(Node node, HashSet<int> nodeHash, int totalTime)
    {
        if (nodeHash.Any())
        {
            foreach (var path in node.paths)
            {
                node.totalTime += path.time;
                for (int i = 0; i < path.path.Count; i++)
                {
                    if (nodeHash.Contains(path.path[i]))
                        nodeHash.Remove(path.path[i]);
                }
            }

            foreach (var nextNode in node.nextNodes)
            {
                int endTotalTime = SearchToEnd(nextNode, nodeHash, totalTime);
                if (node.totalTime > totalTime)
                    totalTime = node.totalTime;
            }
        }

        return totalTime;
    }
}

public class Node
{
    private int position;
    private Node prevNode;
    internal List<Node> nextNodes;
    internal int totalTime;
    internal List<(List<int> path, int time)> paths;
    public Node(int pos)
    {
        position = pos;
        paths = new List<(List<int> path, int time)>();
        nextNodes = new List<Node>();
        totalTime = 0;
    }

    internal void AddTarget(Node node, int time)
    {
        if (!paths.Any(p => p.path.Contains(node.position)))
        {
            paths.Add((path: new List<int>() { this.position, node.position},time: time));
            nextNodes.Add(node);
            node.prevNode = this;
        }
        else
        {
            node.paths = prevNode.paths;
            var path = paths.First(p => p.path.Last() == this.position);
            path.path.Add(node.position);
            path.time += time;
            this.nextNodes.Add(node);
        }
    }
}