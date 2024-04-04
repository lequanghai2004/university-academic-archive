#include <iostream>

// 7 23 43 54 2 321 65 98
// 9 10 16 8 12 15 6 3 9 5

size_t Partition(int* array, size_t low, size_t high)
{
    size_t left = low;
    size_t right = high;
    size_t i = (low + high) / 2;  // pivot index

    while (true)
    {
        while (array[left] <= array[i] && left < high) left++;
        while (array[right] >= array[i] && right > low) right--;
        if (left < right) std::swap(array[left++], array[right--]);
        else break;
    }

    if (i > left)
    {
        std::swap(array[i], array[left]);
        return left;
    }

    if (i < right)
    {
        std::swap(array[i], array[right]);
        return right;
    }

    return i;
}

void QuickSort(int* array, size_t low, size_t high)
{
    size_t breakpoint = Partition(array, low, high);
    if (breakpoint != low) QuickSort(array, low, breakpoint - 1);
    if (breakpoint != high) QuickSort(array, breakpoint + 1, high);
}

int main()
{
    size_t n;  // size of array
    std::cin >> n;
    int a[n];  // array of inputs

    // insert to array and sort
    for (size_t i = 0; i < n; i++) std::cin >> a[i];
    QuickSort(a, 0, n - 1);

    // print sorted array to console
    for (size_t i = 0; i < n - 1; i++) std::cout << a[i] << ", ";
    std::cout << a[n - 1] << "\n";
}