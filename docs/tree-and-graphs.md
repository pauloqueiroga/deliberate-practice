# Binary Trees
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

# N-Ary Trees
## Pre-order Traversal
### Iterative
Time Complexity is **O(*n*)**: each tree node is visited once.  
Space Complexity is **O(*n*)**: the stack **variable** grows to *n* elements in the worst case.  
```
public IList<int> Preorder(Node root) {
    var result = new List<int>();
    
    if (root == null) {
        return result;
    }

    var toProcess = new Stack<Node>();
    toProcess.Push(root);
    
    while (toProcess.Any()) {
        var curr = toProcess.Pop();
        result.Add(curr.val);
        
        // go "right-to-left" through the children since we're stacking them
        for (int i = curr.children.Count - 1; i >= 0; i--) {
            if (curr.children[i] != null) {
                toProcess.Push(curr.children[i]);
            }
        }
    }
    
    return result;
}
```

### Recursive
Time Complexity is **O(*n*)**: each tree node is visited once.  
Space Complexity is **O(*n*)**: the **call stack** grows to *n* elements in the worst case.  
```
public IList<int> Preorder(Node root) {
    var result = new List<int>();
    PreorderRecursive(root, result);
    return result;
}

private void PreorderRecursive(Node root, IList<int> result) {
    if (root == null) {
        return;
    }          
    
    result.Add(root.val);
    
    foreach (var sub in root.children) {
        PreorderRecursive(sub, result);
    }
}
```

## Post-order Traversal
### Iterative
Time Complexity is **O(*n*)**: each tree node is visited once.  
Space Complexity is **O(*n*)**: the stack **variable** grows to *n* elements in the worst case.  
```
public IList<int> Postorder(Node root) {
    IList<int> result = new List<int>();
    
    if (root == null) {
        return result;
    }
    
    var toProcess = new Stack<Node>();
    var toPrint = new Stack<int>();  // more time&space efficient than Insert(0)!
    toProcess.Push(root);
    
    while (toProcess.Any()) {
        var curr = toProcess.Pop();
        toPrint.Push(curr.val);
        
        foreach (var child in curr.children) {
            if (child != null) {
                toProcess.Push(child);
            }
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
public IList<int> Postorder(Node root) {
    IList<int> result = new List<int>();
    PostorderRecursive(root, result);
    return result;
}

private void PostorderRecursive(Node root, IList<int> result) {
    if (root == null) {
        return;
    }
    
    foreach (var child in root.children) {
        PostorderRecursive(child, result);
    }
    
    result.Add(root.val);
}
```

## Level-order Traversal
### Iterative
Time Complexity is **O(*n*)**: each tree node is visited once.  
Space Complexity is **O(*n*)**: the stack **variable** grows to *n* elements in the worst case.  
```
public IList<IList<int>> LevelOrder(Node root) {
    IList<IList<int>> result = new List<IList<int>>();
    
    if (root == null) {
        return result;
    }
    
    var toProcess = new Queue<Node>();
    var level = 0;
    toProcess.Enqueue(root);
    
    while (toProcess.Any()) {
        var levelCount = toProcess.Count();
        
        if (result.Count == level) {
            result.Add(new List<int>());
        }
        
        for (int i = 0; i < levelCount; i++) {
            var curr = toProcess.Dequeue();
            result[level].Add(curr.val);
            
            foreach (var child in curr.children) {
                toProcess.Enqueue(child);
            }
        }
        
        level++;
    }
    
    return result;
}
```

### Recursive
Time Complexity is **O(*n*)**: each tree node is visited once.  
Space Complexity is **O(*n*)**: the **call stack** grows to *n* elements in the worst case.  
```
public IList<IList<int>> LevelOrder(Node root) {
    IList<IList<int>> result = new List<IList<int>>();
    LevelOrderRecursive(root, result);
    return result;
}

private void LevelOrderRecursive(Node root, IList<IList<int>> result, int level=0) {
    if (root == null) {
        return;
    }
    
    if (result.Count == level) {
        result.Add(new List<int>());
    }
    
    result[level].Add(root.val);
    
    foreach (var child in root.children) {
        LevelOrderRecursive(child, result, level + 1);
    }
}
```