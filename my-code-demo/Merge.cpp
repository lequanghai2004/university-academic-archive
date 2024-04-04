#include <iostream>

// test set: 7 23 43 54 2 321 65 98

void Merge(int* array, int* tempArr, size_t low, size_t mid, size_t high)
{
    size_t lI = low;
    size_t rI = mid + 1;
    size_t aI = low;

    for (size_t i = low; i <= high; i++) tempArr[i] = array[i];

    while (lI <= mid && rI <= high)
        if (tempArr[rI] < tempArr[lI]) array[aI++] = tempArr[rI++];
        else array[aI++] = tempArr[lI++];

    // Copy the remaining elements of left and right arrays
    while (lI <= mid) array[aI++] = tempArr[lI++];
    while (rI <= high) array[aI++] = tempArr[rI++];
}

void MergeSort(int* array, int* tempArr, size_t low, size_t high)
{
    if (low >= high) return;
    // rounded floor value by default
    size_t mid = (low + high) / 2;
    MergeSort(array, tempArr, low, mid);
    MergeSort(array, tempArr, mid + 1, high);
    Merge(array, tempArr, low, mid, high);
}

int main()
{
    size_t n;  // size of array
    std::cin >> n;
    int a[n];  // array of inputs
    int temp[n];  // temp for merge sort

    // insert to array and sort
    for (size_t i = 0; i < n; i++) std::cin >> a[i];
    MergeSort(a, temp, 0, n - 1);
    // print sorted array to console
    for (size_t i = 0; i < n - 1; i++) std::cout << a[i] << ", ";
    std::cout << a[n - 1] << "\n";
}