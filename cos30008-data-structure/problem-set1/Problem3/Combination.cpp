#include "Combination.h"

Combination::Combination(size_t aN, size_t aK) : fN(aN), fK(aK) {}

size_t Combination::getK() const
{
    return fK;
}

size_t Combination::getN() const
{
    return fN;
}

unsigned long long Combination::operator()() const
{
    if (fK > fN) return 0;

    unsigned long long result = 1.0;

    for (size_t i = 0; i < fK; i++)
    {
        result *= (fN - i);
        result /= (i + 1);
    }

    return result;
}