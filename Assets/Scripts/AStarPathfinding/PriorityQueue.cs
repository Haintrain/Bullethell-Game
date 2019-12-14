using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriorityQueue
{
    int maxSize, size;
    Node[] heap;

    List<Node> inQueue = new List<Node>();

    int front = 1;
    public PriorityQueue(int maxSize)
    {
        this.maxSize = maxSize;
        this.size = 0;
        heap = new Node[this.maxSize + 1];
        heap[0] = new Node(false, Vector3.one * 0, -1, -1);
    }

    void MinHeapify(int i)
    {
        int l = Left(i);
        int r = Right(i);
        int min = -1;

        if (l < size && heap[l].GetFCost() < heap[i].GetFCost())
        {
            min = l;
        }
        else
        {
            min = i;
        }

        if (r < size && heap[r].GetFCost() < heap[min].GetFCost())
        {
            min = r;
        }

        if (min != i)
        {
            Swap(min, i);
            MinHeapify(min);
        }
    }

    public void Push(Node node)
    {
        if (size >= maxSize)
        {
            return;
        }

        heap[++size] = node;
        inQueue.Add(node);
        int current = size;

        while (heap[current].GetFCost() < heap[Parent(current)].GetFCost())
        {
            Swap(current, Parent(current));
            current = Parent(current);
        }
    }

    public Node Pop()
    {
        Node popped = heap[front];
        heap[front] = heap[size--];

        inQueue.Remove(popped);
        
        MinHeapify(front);
        return popped;
    }

    public void MinHeap()
    {
        for (int i = (size / 2); i >= 1; i--)
        {
            MinHeapify(i);
        }
    }

    int Parent(int pos) { return pos / 2; }
    int Left(int pos) { return (pos * 2); }
    int Right(int pos) { return (pos * 2) + 1; }

    void Swap(int x, int y)
    {
        Node tmp;
        tmp = heap[x];
        heap[x] = heap[y];
        heap[y] = tmp;
    }

    public bool isDuplicate(Node node){
        return inQueue.Contains(node);
    }

    public int GetSize(){
        return size;
    }
}





