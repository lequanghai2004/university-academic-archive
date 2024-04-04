#include "IntVector.h"

#include <stdexcept>

IntVector::IntVector(const int aArrayOfIntegers[], size_t aNumberOfElements) :
    fElements(new int[aNumberOfElements]), fNumberOfElements(aNumberOfElements)
{
    for (size_t i = 0; i < fNumberOfElements; i++)
        fElements[i] = aArrayOfIntegers[i];
}

IntVector::~IntVector()
{
    delete[] fElements;
}

size_t IntVector::size() const
{
    return fNumberOfElements;
}

void IntVector::swap(size_t aSourceIndex, size_t aTargetIndex)
{
    if (aSourceIndex < fNumberOfElements && aSourceIndex >= 0
        && aTargetIndex < fNumberOfElements && aTargetIndex >= 0)
        std::swap(fElements[aSourceIndex], fElements[aTargetIndex]);
    else throw std::out_of_range("Illegal array indices");
}

const int IntVector::operator[](size_t aIndex) const
{
    if (aIndex < fNumberOfElements && aIndex >= 0) return fElements[aIndex];
    // else
    throw std::out_of_range("Illegal array index");
}

const int IntVector::get(size_t aIndex) const
{
    return operator[](aIndex);
}