using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeGrid : MonoBehaviour
{
    public Vector2 gridWorldSize;
    public float xScale, yScale;
    public LayerMask terrain;
    int gridSizeX, gridSizeY;
    public float distance;

    public List<Node> finalPath;

    Node[,] grid;
    public List<Node> path;
    void Start()
    {
        gridSizeX = Mathf.RoundToInt(gridWorldSize.x / xScale);
        gridSizeY = Mathf.RoundToInt(gridWorldSize.y / yScale);
        CreateGrid();
    }

    void CreateGrid()
    {
        grid = new Node[gridSizeX, gridSizeY];
        Vector3 bottomLeft = transform.position - Vector3.right * gridWorldSize.x / 2 - Vector3.up * gridWorldSize.y / 2;

        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                Vector3 worldPoint = bottomLeft + new Vector3(xScale, 0, 0) * (x + 0.5f) + new Vector3(0, yScale, 0) * (y + 0.5f);
                bool walkable = false;

                if (Physics2D.OverlapCircle(worldPoint, 0.15f, terrain) == null)
                {
                    walkable = true;
                }

                grid[x, y] = new Node(walkable, worldPoint, x, y);
            }
        }
    }

    public Node NodeFromWorldPoint(Vector3 worldPos)
    {
        float xPos = ((worldPos.x + gridWorldSize.x / 2) / gridWorldSize.x);
        float yPos = ((worldPos.y + gridWorldSize.y / 2) / gridWorldSize.y);

        xPos = Mathf.Clamp01(xPos);
        yPos = Mathf.Clamp01(yPos);

        int x = Mathf.RoundToInt((gridSizeX - 1) * xPos);
        int y = Mathf.RoundToInt((gridSizeY - 1) * yPos);

        return grid[x, y];
    }

    public List<Node> GetNeighboringNodes(Node neighbourNode)
    {
        Debug.Log("Current node location is " + neighbourNode.gridX + " " + neighbourNode.gridY);
        List<Node> NeighborList = new List<Node>();
        int checkX = neighbourNode.gridX;
        int checkY = neighbourNode.gridY;

        Node node;

        node = CheckNeighbour(checkX - 1, checkY - 1);
        if (node != null)
        {
            NeighborList.Add(node);
        }
        node = CheckNeighbour(checkX - 1, checkY);
        if (node != null)
        {
            NeighborList.Add(node);
        }
        node = CheckNeighbour(checkX - 1, checkY + 1);
        if (node != null)
        {
            NeighborList.Add(node);
        }
        node = CheckNeighbour(checkX, checkY - 1);
        if (node != null)
        {
            NeighborList.Add(node);
        }
        node = CheckNeighbour(checkX, checkY + 1);
        if (node != null)
        {
            NeighborList.Add(node);
        }
        node = CheckNeighbour(checkX + 1, checkY - 1);
        if (node != null)
        {
            NeighborList.Add(node);
        }
        node = CheckNeighbour(checkX + 1, checkY);
        if (node != null)
        {
            NeighborList.Add(node);
        }
        node = CheckNeighbour(checkX + 1, checkY + 1);
        if (node != null)
        {
            NeighborList.Add(node);
        }

        return NeighborList;//Return the neighbors list.
    }

    private Node CheckNeighbour(int checkX, int checkY)
    {
        if (checkX >= 0 && checkX < gridSizeX)
        {
            if (checkY >= 0 && checkY < gridSizeY)
            {
                return grid[checkX, checkY];
            }
            else
            {
                return null;
            }
        }
        else
        {
            return null;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(gridWorldSize.x, gridWorldSize.y, 1));

        if (grid != null)
        {
            foreach (Node node in grid)
            {
                if (node.walkable)
                {
                    Gizmos.color = Color.white;
                }
                else if (node.start == true)
                {
                    Gizmos.color = Color.green;
                }
                else if (node.check == true)
                {
                    Gizmos.color = Color.magenta;
                }
                else
                {
                    Gizmos.color = Color.yellow;
                }



                if (finalPath != null)//If the final path is not empty
                {
                    if (finalPath.Contains(node))//If the current node is in the final path
                    {
                        Gizmos.color = Color.red;//Set the color of that node
                    }

                }

                Gizmos.DrawSphere(node.coord, 0.1f);
            }
        }
    }
}
