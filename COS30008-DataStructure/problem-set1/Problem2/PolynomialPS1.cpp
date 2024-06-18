#include <cmath>
#include <iostream>
#include <sstream>

#include "Polynomial.h"

double Polynomial::operator()(double aX) const
{
    double Result = 0.0;
    for (size_t i = 0; i <= fDegree; i++)
    {
        Result += fCoeffs[i] * pow(aX, i);
    }

    return Result;
}

Polynomial Polynomial::getDerivative() const
{
    Polynomial Result;
    if (fDegree < 1) return Result;

    std::ostringstream ostream;
    ostream << fDegree - 1 << " ";

    for (size_t i = fDegree; i > 0; i--)
    {
        ostream << i * fCoeffs[i] << " ";
    }

    std::istringstream istream(ostream.str());
    istream >> Result;
    return Result;
}

Polynomial Polynomial::getIndefiniteIntegral() const
{
    std::ostringstream ostream;
    ostream << fDegree + 1 << " ";

    for (size_t i = fDegree + 1; i > 0; i--)
    {
        ostream << fCoeffs[i - 1] / i << " ";
    }

    std::istringstream istream(ostream.str());
    Polynomial Result;
    istream >> Result;
    return Result;
}

double Polynomial::getDefiniteIntegral(double aXLow, double aXHigh) const
{
    Polynomial integral = getIndefiniteIntegral();
    return integral(aXHigh) - integral(aXLow);
}