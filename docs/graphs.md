# Graphs
## Disjoint Set
This implementation of *UnionFind* features Path Compression for the *Find()* and Optimization by Rankk for the *Union()*.  

```
public class UnionFind {
    private int[] root;
    private int[] rank;

    public UnionFind(int size) {
        root = new int[size];
        rank = new int[size];

        for (int i = 0; i < size; i++) {
            root[i] = i;
            rank[i] = 1;
        }
    }

    public int Find(int x) {
        if (x == root[x]) {
            return x;
        }
        
        root[x] = Find(root[x]);
        return root[x];
    }

    public void Union(int x, int y) {
        var rootX = Find(x);
        var rootY = Find(y);
        
        if (rootX == rootY) {
            return;
        }

        if (rank[rootX] > rank[rootY]) {
            root[rootY] = rootX;
            return;
        } 
        
        if (rank[rootX] < rank[rootY]) {
            root[rootX] = rootY;
            return;
        } 
        
        root[rootY] = rootX;
        rank[rootX]++;
    }

    public bool Connected(int x, int y) {
        return Find(x) == Find(y);
    }
}
```
## Undirected Graphs

## Directed Graphs

## Weighted Graphs
