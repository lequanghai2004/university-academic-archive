#include "ShakerSortableIntVector.h"

ShakerSortableIntVector::ShakerSortableIntVector(
    const int aArrayOfIntegers[], size_t aNumberOfElements) :
    SortableIntVector(aArrayOfIntegers, aNumberOfElements)
{
}

void ShakerSortableIntVector::sort(Comparable aOrderFunction)
{
    for (size_t i = 0; i < fNumberOfElements - 1; ++i)
    {
        bool reverse = false;

        // Forward pass (from left to right)
        for (size_t j = 0; j < fNumberOfElements - i - 1; ++j)
        {
            if (aOrderFunction(fElements[j], fElements[j + 1]))
            {
                swap(j, j + 1);
                reverse = true;
            }
        }

        if (!reverse) break;
        reverse = false;

        // Backward pass (from right to left)
        for (size_t j = fNumberOfElements - i - 1; j > i; --j)
        {
            if (aOrderFunction(fElements[j - 1], fElements[j]))
            {
                swap(j - 1, j);
                reverse = true;
            }
        }

        if (!reverse) break;
    }
}