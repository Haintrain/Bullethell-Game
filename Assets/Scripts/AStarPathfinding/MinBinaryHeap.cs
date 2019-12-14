using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinBinaryHeap
{
    int maxSize, size;
    int[] heap;

    int front = 1;
    MinBinaryHeap(int maxSize)
    {
        this.maxSize = maxSize;
        this.size = 0;
        heap = new int[this.maxSize + 1];
        heap[0] = int.MinValue;
    }

    void minHeapify(int i)
    {
        int l = left(i);
        int r = right(i);
        int min = -1;

        if (l < size && heap[l] < heap[i])
        {
            min = l;
        }
        else
        {
            min = i;
        }

        if (r < size && heap[r]< heap[min])
        {
            min = r;
        }

        if (min != i)
        {
            swap(min, i);
            minHeapify(min);
        }
    }

    void insert(int tile)
    {
        if (size >= maxSize)
        {
            return;
        }

        heap[++size] = tile;
        int current = size;

        while (heap[current] < heap[parent(current)])
        {
            swap(current, parent(current));
            current = parent(current);
        }
    }

    public int remove()
    {
        int popped = heap[front];
        heap[front] = heap[size--];
        minHeapify(front);
        return popped;
    }

    public void minHeap()
    {
        for (int i = (size / 2); i >= 1; i--)
        {
            minHeapify(i);
        }
    }

    int parent(int pos) { return pos / 2; }
    int left(int pos) { return (pos * 2); }
    int right(int pos) { return (pos * 2) + 1; }

    void swap(int x, int y)
    {
        int tmp;
        tmp = heap[x];
        heap[x] = heap[y];
        heap[y] = tmp;
    }
}