#include "SortableIntVector.h"

SortableIntVector::SortableIntVector(
    const int aArrayOfIntegers[], size_t aNumberOfElements) :
    IntVector(aArrayOfIntegers, aNumberOfElements)
{
}

void SortableIntVector::sort(Comparable aOrderFunction)
{
    for (size_t i = 0; i < fNumberOfElements - 1; i++)
    {
        for (size_t j = 0; j < fNumberOfElements - i - 1; j++)
        {
            if (!aOrderFunction(fElements[j], fElements[j + 1]))
            {
                swap(j, j + 1);
            }
        }
    }
}
