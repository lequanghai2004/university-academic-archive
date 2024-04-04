#include "BernsteinPolynomial.h"

#include <cmath>
#include <iostream>

BernsteinBasisPolynomial::BernsteinBasisPolynomial(
    unsigned int aV, unsigned int aN) :
    fFactor(aN, aV)
{
}

double BernsteinBasisPolynomial::operator()(double aX) const
{
    unsigned int v = fFactor.getK();
    unsigned int n = fFactor.getN();

    return fFactor() * pow(aX, v) * pow(1 - aX, n - v);
}
