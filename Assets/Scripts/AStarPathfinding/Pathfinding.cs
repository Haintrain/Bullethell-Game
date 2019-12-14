using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    NodeGrid grid;
    public Transform startPosition, targetPosition;

    public void Start(){
        grid = GetComponent<NodeGrid>();      
        LoopPath();
        //InvokeRepeating("LoopPath", 0f, 1f);                
    }

    private void FixedUpdate(){
        FindPath(startPosition.position, targetPosition.position);
    }

    void LoopPath(){
        
    }

    void FindPath(Vector3 startPos, Vector3 targetPos){
        Node startNode = grid.NodeFromWorldPoint(startPos);
        Node targetNode = grid.NodeFromWorldPoint(targetPos);

        PriorityQueue openSet = new PriorityQueue(100);
        HashSet<Node> closedSet = new HashSet<Node>();

        openSet.Push(startNode);

        while(openSet.GetSize() > 0){
            Node currentNode = openSet.Pop();

            startNode.start = true;
            
            closedSet.Add(currentNode);

            if(currentNode == targetNode){
                ReconstructPath(startNode, targetNode); 
                break;
            }

            foreach(Node neighbourNode in grid.GetNeighboringNodes(currentNode)){
                if(!neighbourNode.walkable || closedSet.Contains(neighbourNode)){
                    continue;
                }

                neighbourNode.check = true;

                float moveCost = currentNode.gCost + GetManhattenDistance(currentNode, neighbourNode);

                if(moveCost < neighbourNode.gCost || !openSet.isDuplicate(neighbourNode)){
                    neighbourNode.gCost = moveCost;
                    neighbourNode.hCost = GetManhattenDistance(neighbourNode, targetNode);
                    neighbourNode.parentNode = currentNode;

                    if(!openSet.isDuplicate(neighbourNode)){
                        openSet.Push(neighbourNode);
                    }
                }
            }
        }
    }

    void ReconstructPath(Node startingNode, Node endNode){
        List<Node> finalPath = new List<Node>();//List to hold the path sequentially 
        Node currentNode = endNode;//Node to store the current node being checked

        while(currentNode != startingNode)//While loop to work through each node going through the parents to the beginning of the path
        {
            finalPath.Add(currentNode);//Add that node to the final path
            currentNode = currentNode.parentNode;//Move onto its parent node
        }

        finalPath.Reverse();//Reverse the path to get the correct order

        grid.finalPath = finalPath;//Set the final path
    }

    int GetManhattenDistance(Node nodeA, Node nodeB)
    {
        int ix = Mathf.Abs(nodeA.gridX - nodeB.gridX);//x1-x2
        int iy = Mathf.Abs(nodeA.gridY - nodeB.gridY);//y1-y2

        return ix + iy;//Return the sum
    }
}
