# Trees and Graphs
## Pre-order Traversal
### Iterative
Time Complexity is **O(*n*)**: each tree node is visited once.  
Space Complexity is **O(*n*)**: the stack **variable** grows to *n* elements in the worst case.  
```
public IList<int> PreorderTraversal(TreeNode root) {
    IList<int> result = new List<int>();
    
    if (root == null) {
        return result;
    }
    
    var toProcess = new Stack<TreeNode>();
    toProcess.Push(root);
    
    while (toProcess.Any()) {
        var curr = toProcess.Pop();
        result.Add(curr.val);
        
        if (curr.right != null) {
            toProcess.Push(curr.right);
        }

        if (curr.left != null) {
            toProcess.Push(curr.left);
        }
    }
    
    return result;
}
```

### Recursive
Time Complexity is **O(*n*)**: each tree node is visited once.  
Space Complexity is **O(*n*)**: the **call stack** grows to *n* elements in the worst case.  
```
private IList<int> result = new List<int>();

private void PreorderRecursive(TreeNode root) {
    if (root == null) {
        return;
    }
    
    result.Add(root.val);
    PreorderRecursive(root.left);
    PreorderRecursive(root.right);
}
```


## In-order Traversal
### Iterative
Time Complexity is **O(*n*)**: each tree node is visited once.  
Space Complexity is **O(*n*)**: the stack **variable** grows to *n* elements in the worst case.  
```
public IList<int> InorderTraversal(TreeNode root) {
    IList<int> result = new List<int>();   

    if (root == null) {
        return result;
    }
    
    var toProcess = new Stack<TreeNode>(); 
    var curr = root;
    
    while (curr != null || toProcess.Any()) {
        while (curr != null) {
            toProcess.Push(curr);
            curr = curr.left;
        }
        
        curr = toProcess.Pop();
        result.Add(curr.val);
        curr = curr.right;
    }
    
    return result;
}
```

### Recursive
Time Complexity is **O(*n*)**: each tree node is visited once.  
Space Complexity is **O(*n*)**: the **call stack** grows to *n* elements in the worst case.  
```
private IList<int> result = new List<int>();

private void InorderRecursive(TreeNode root) {
    if (root == null) {
        return;
    }
    
    InorderRecursive(root.left);
    result.Add(root.val);
    InorderRecursive(root.right);
}
```

## Post-order Traversal
### Iterative
Time Complexity is **O(*n*)**: each tree node is visited once.  
Space Complexity is **O(*n*)**: the processing stack **variable** grows to *n* elements in the worst case. The printing stack always grows to *n* elements. 
```
public IList<int> PostorderTraversal(TreeNode root) {
    IList<int> result = new List<int>();

    if (root == null) {
        return result;
    }

    var toProcess = new Stack<TreeNode>();
    var toPrint = new Stack<int>();
    toProcess.Push(root);
    
    while (toProcess.Any()) {
        var curr = toProcess.Pop();
        toPrint.Push(curr.val);

        if (curr.left != null) {
            toProcess.Push(curr.left);
        }
        
        if (curr.right != null) {
            toProcess.Push(curr.right);
        }
    }
    
    while (toPrint.Any()) {
        result.Add(toPrint.Pop());
    }
    
    return result;
}
```

### Recursive
Time Complexity is **O(*n*)**: each tree node is visited once.  
Space Complexity is **O(*n*)**: the **call stack** grows to *n* elements in the worst case.  
```
private IList<int> result = new List<int>();

private void PostorderRecursive(TreeNode root) {
    if (root == null) {
        return;
    }

    PostorderRecursive(root.left);
    PostorderRecursive(root.right);
    result.Add(root.val);
}
```