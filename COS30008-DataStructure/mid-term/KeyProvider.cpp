#include "KeyProvider.h"

#include <cstring>

// char* fKeyword;  // keyword
// size_t fSize;  // length of keyword
// size_t fIndex;  // index to current keyword character
KeyProvider::KeyProvider(const std::string& aKeyword) : fKeyword(nullptr)
{
    initialize(aKeyword);
}

KeyProvider::~KeyProvider()
{
    delete[] fKeyword;
}

void KeyProvider::initialize(const std::string& aKeyword)
{
    if (fKeyword) delete[] fKeyword;

    fSize = aKeyword.length();
    fKeyword = new char[fSize + 1];
    fIndex = 0;

    for (size_t i = 0; i < fSize; ++i)
    {
        char c = aKeyword[i];
        if (isalpha(c)) fKeyword[i] = toupper(c);
        else fKeyword[i] = c;
    }

    // Null-terminate the fKeyword
    fKeyword[fSize] = '\0';
}

char KeyProvider::operator*() const
{
    return fKeyword[fIndex];
}

// Push new keyword character. [18]
// aKeyCharacter is a letter (isalpha() is true).
// aKeyCharacter replaces current keyword character.
// Key provider advances to next keyword character.
KeyProvider& KeyProvider::operator<<(char aKeyCharacter)
{
    fKeyword[fIndex]
        = isalpha(aKeyCharacter) ? toupper(aKeyCharacter) : aKeyCharacter;
    fIndex = fIndex < fSize - 1 ? fIndex + 1 : 0;
    return *this;
}