//Given an array arr[] of non negative integers. We can perform a swap operation on any two adjacent elements in the array.
//Find the minimum number of swaps needed to sort the array in ascending order. 

//Input: arr[] = { 3, 2, 1 }
//Output: 3
//We need to do following swaps
//(3, 2), (3, 1) and(1, 2)

//Input: arr[] = { 1, 20, 6, 4, 5 }
//Output: 5


//Inversion Count for an array indicates – how far (or close) the array is from being sorted.
//If the array is already sorted, then the inversion count is 0, but if the array is sorted in the reverse order, the inversion count is the maximum. 
//Formally speaking, two elements a[i] and a[j] form an inversion if a[i] > a[j] and i<j 
//Informally speaking, inversions represent elements out of order.

int[] inputArray = { 1, 20, 6, 4, 5 };
Console.WriteLine("Number of swaps for [1, 20, 6, 4, 5] is " + countSwaps(inputArray)); // Correct answer is 5

inputArray = new int[] { 3, 2, 1 };
Console.WriteLine("Number of swaps for [3, 2, 1] is " + countSwaps(inputArray)); // Correct answer is 3

inputArray = new int[] { 38, 27, 43, 3, 9, 82, 10 };
Console.WriteLine("Number of swaps for [3, 2, 1] is " + countSwaps(inputArray)); // Correct answer is 3


// Sorts the input array and returns the number of inversions in the array
static int countSwaps(int[] inputArray)
{
    int arrayLength = inputArray.Length;
    int []temp = new int[arrayLength];
    return mergeSort(inputArray, temp, 0, arrayLength - 1);
}

// Recursive function that sorts input array and returns number of inversions in the array.
// recursively calls itself to divide array till size becomes 1
static int mergeSort(int[] inputArrary, int[] temp, int left, int right)
{
    int inversionCount = 0;
    int mid;

    if (left < right)
    {
        // Divide array into two parts and call mergeSort for each of the parts
        mid = (right + left) / 2;

        // Inversion count will be the sum of:
        // inversions in the left side array, inversions in the right side array and number of inversions in merging

        inversionCount = mergeSort(inputArrary, temp, left, mid);

        inversionCount += mergeSort(inputArrary, temp, mid + 1, right);

        inversionCount += merge(inputArrary, temp, left, mid + 1, right);
    }

    return inversionCount;
}

// Merges two halves of an array and returns inversion count in the arrays
static int merge(int[] arr, int[] temp, int left, int mid, int right)
{
    int inversionCount = 0;

    // i is the index of the left subarray
    int i = left;

    // j is the index of the right subarray
    int j = mid;

    // k is the index of the merged array
    int k = left;

    while ((i < mid) && (j <= right))
    {
        if (arr[i] <= arr[j])
            temp[k++] = arr[i++];
        else
        {
            temp[k++] = arr[j++];

            // if a[i] > a[j] then there are (mid - i) inversions
            // this is true because left and right subarrays have to be sorted by the end of the flow
            // so a[i] creates an inversion with all remaining elements in
            inversionCount += (mid - i);
        }
    }

    // Copy remaining elements of left subarray to to temp
    while (i < mid)
        temp[k++] = arr[i++];

    // Copy remaining elements of right subarray to temp
    while (j <= right)
        temp[k++] = arr[j++];

    // Copy back merged elements to original array
    for (i = left; i <= right; i++)    
        arr[i] = temp[i];

    return inversionCount;
}