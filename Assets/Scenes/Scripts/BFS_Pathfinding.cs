using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BFS_Pathfinding : MonoBehaviour
{

    IDictionary<Vector3, Vector3> nodeParents = new Dictionary<Vector3, Vector3>();
    public IDictionary<Vector3, bool> walkablePositions;
    NodeNetworkCreator nodeNetwork;

    // Use this for initialization
    void Start () {
        nodeNetwork = GameObject.Find("NodeNetwork").GetComponent<NodeNetworkCreator>();
        walkablePositions = nodeNetwork.walkablePositions;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //Breadth first search of graph.
    //Populates IList<Vector3> path with a valid solution to the goalPosition.
    //Returns the goalPosition if a solution is found.
    //Returns the startPosition if no solution is found.
    Vector3 FindShortestPathBFS(Vector3 startPosition, Vector3 goalPosition)
    {

        uint nodeVisitCount = 0;
        float timeNow = Time.realtimeSinceStartup;

        Queue<Vector3> queue = new Queue<Vector3>();
        HashSet<Vector3> exploredNodes = new HashSet<Vector3>();
        queue.Enqueue(startPosition);

        while (queue.Count != 0)
        {
            Vector3 currentNode = queue.Dequeue();
            nodeVisitCount++;

            if (currentNode == goalPosition)
            {
                print("BFS time: " + (Time.realtimeSinceStartup - timeNow).ToString());
                print(string.Format("BFS visits: {0} ({1:F2}%)", nodeVisitCount, (nodeVisitCount / (double)walkablePositions.Count) * 100));

                return currentNode;
            }

            IList<Vector3> nodes = GetWalkableNodes(currentNode);

            foreach (Vector3 node in nodes)
            {
                if (!exploredNodes.Contains(node))
                {
                    //Mark the node as explored
                    exploredNodes.Add(node);

                    //Store a reference to the previous node
                    nodeParents.Add(node, currentNode);

                    //Add this to the queue of nodes to examine
                    queue.Enqueue(node);
                }
            }
        }

        return startPosition;
    }

    bool CanMove(Vector3 nextPosition)
    {
        return (walkablePositions.ContainsKey(nextPosition) ? walkablePositions[nextPosition] : false);
    }

    IList<Vector3> GetWalkableNodes(Vector3 curr)
    {

        IList<Vector3> walkableNodes = new List<Vector3>();

        IList<Vector3> possibleNodes = new List<Vector3>() {
            new Vector3 (curr.x + 1, curr.y, curr.z),
            new Vector3 (curr.x - 1, curr.y, curr.z),
            new Vector3 (curr.x, curr.y, curr.z + 1),
            new Vector3 (curr.x, curr.y, curr.z - 1),
            new Vector3 (curr.x + 1, curr.y, curr.z + 1),
            new Vector3 (curr.x + 1, curr.y, curr.z - 1),
            new Vector3 (curr.x - 1, curr.y, curr.z + 1),
            new Vector3 (curr.x - 1, curr.y, curr.z - 1)
        };

        foreach (Vector3 node in possibleNodes)
        {
            if (CanMove(node))
            {
                walkableNodes.Add(node);
            }
        }

        return walkableNodes;
    }
}
