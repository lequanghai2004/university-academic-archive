#include <cmath>

#include "Polygon.h"

// Problem Set 1 extension
float Polygon::getSignedArea() const
{
    if (fNumberOfVertices < 3) return 0;

    float result = fVertices[fNumberOfVertices - 1].getX() * fVertices[0].getY()
        - fVertices[0].getX() * fVertices[fNumberOfVertices - 1].getY();

    for (size_t i = 1; i < fNumberOfVertices; i++)
    {
        result += fVertices[i - 1].getX() * fVertices[i].getY()
            - fVertices[i].getX() * fVertices[i - 1].getY();
    }

    return result / 2;
};