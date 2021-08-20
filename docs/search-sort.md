# Search and Sort
## Quicksort
```
public static void QuickSort(int[] nums, int left, int right) {
    if (left < 0 || right < 0 || left >= right) {
        return;
    }
    
    var div = Partition(nums, left, right, (right + left)/2);  // consider other ways to select the pivot Index...
    QuickSort(nums, left, div-1);
    QuickSort(nums, div+1, right);
}
    
private static int Partition(int[] nums, int left, int right, int pivotIndex) {
    var pivot = nums[pivotIndex];
    nums[pivotIndex] = nums[right];
    nums[right] = pivot;
    pivotIndex = left;
    
    for (int i = left; i < right; i++) {
        if (nums[i] < pivot) {
            var swap = nums[pivotIndex];
            nums[pivotIndex++] = nums[i];
            nums[i] = swap;
        }
    }
    
    nums[right] = nums[pivotIndex];
    nums[pivotIndex] = pivot;
    return pivotIndex;
}
```
## Quickselect
```
public static int QuickSelect(int[] nums, int left, int right, int k) {
    if (left == right) {
        return nums[left];
    }
    
    var div = (left + right)/2;   // there are other strategies for selecting div
    div = Partition(nums, left, right, div);
    
    if (k == div) {
        return nums[k];
    }
    
    if (k < div) {
        return QuickSelect(nums, left, div-1, k);
    }
    
    return QuickSelect(nums, div+1, right, k);
}

private static int Partition(int[] nums, int left, int right, int pivotIndex) {
    var pivot = nums[pivotIndex];
    nums[pivotIndex] = nums[right];
    nums[right] = pivot;
    pivotIndex = left;
    
    for (int i = left; i < right; i++) {
        if (nums[i] < pivot) {
            var swap = nums[pivotIndex];
            nums[pivotIndex++] = nums[i];
            nums[i] = swap;
        }
    }
    
    nums[right] = nums[pivotIndex];
    nums[pivotIndex] = pivot;
    return pivotIndex;
}

```