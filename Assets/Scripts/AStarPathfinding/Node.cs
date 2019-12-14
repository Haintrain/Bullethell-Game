using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public int gridX, gridY;
    public Vector3 coord;
    public float gCost, hCost;
    public Node parentNode;
    public bool walkable;

    public bool check, start;

    public Node(bool walkable, Vector3 coord, int gridX, int gridY){
        this.walkable = walkable;
        this.coord = coord;
        this.gridX = gridX;
        this.gridY = gridY;
        check = false;
        start = false;
    }

    public float GetFCost(){
        return gCost + hCost;
    }
}
