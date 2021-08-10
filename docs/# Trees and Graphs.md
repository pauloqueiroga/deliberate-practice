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
    
    var curr = root;
    var toProcess = new Stack<TreeNode>();
    
    while (curr != null || toProcess.Any()) {
        while (curr != null) {
            result.Add(curr.val);
            toProcess.Push(curr.right);
            curr = curr.left;
        }
        
        while (curr == null && toProcess.Any()) {
            curr = toProcess.Pop();
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
