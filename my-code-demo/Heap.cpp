#include <iostream>
#include <utility>

// test set: 7 23 43 54 2 321 65 98

int main()
{
    size_t n;  // size of array
    std::cin >> n;
    int a[n];  // array of inputs

    // insert input to heap
    for (size_t i = 0; i < n; i++)
    {
        std::cin >> a[i];
        size_t index = i;

        while (a[index] > a[(index - 1) / 2])
        {
            std::swap(a[index], a[(index - 1) / 2]);
            index = (index - 1) / 2;
        }
    }

    // delete heap root and add to last
    for (size_t i = n; i > 0; i--)
    {
        std::swap(a[0], a[i - 1]);

        int index = 0;
        while (index * 2 + 1 < i - 1)
        {
            if (index * 2 + 1 == i - 2)
            {
                if (a[index] < a[index * 2 + 1])
                {
                    std::swap(a[index], a[index * 2 + 1]);
                    index = index * 2 + 1;
                }
                break;
            }

            int higherChildIndex = a[index * 2 + 1] > a[index * 2 + 2]
                ? index * 2 + 1
                : index * 2 + 2;
            if (a[index] < a[higherChildIndex])
            {
                std::swap(a[index], a[higherChildIndex]);
                index = higherChildIndex;
            }
            else break;
        }
    }

    // print sorted array to console
    for (size_t i = 0; i < n - 1; i++)
    {
        std::cout << a[i] << ", ";
    }

    std::cout << a[n - 1] << "\n";
}
