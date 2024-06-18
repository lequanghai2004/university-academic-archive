#include "Vigenere.h"

#include <iostream>

#define CHARACTERS 26

void Vigenere::initializeTable()
{
    for (char row = 0; row < CHARACTERS; row++)
    {
        char lChar = 'B' + row;

        for (char column = 0; column < CHARACTERS; column++)
        {
            if (lChar > 'Z') lChar = 'A';
            fMappingTable[row][column] = lChar++;
        }
    }
}

// Initialize Vigenere scrambler
Vigenere::Vigenere(const std::string& aKeyword) :
    fKeyword(aKeyword), fKeywordProvider(aKeyword)
{
    initializeTable();
}

// Return the current keyword
// This method scans the keyword provider and copies the keyword characters
// into a result string.
std::string Vigenere::getCurrentKeyword()
{
    std::string result = "";
    for (size_t i = 0; i < fKeyword.length(); i++)
    {
        char c = *fKeywordProvider;
        fKeywordProvider << c;
        result += c;
    }

    return result;
}

// Reset Vigenere scrambler
// This method has to initialize the keyword provider
void Vigenere::reset()
{
    fKeywordProvider.initialize(fKeyword);
}

// Encode a character using the current keyword character and update
// keyword.
char Vigenere::encode(char aCharacter)
{
    if (!isalpha(aCharacter)) return aCharacter;
    char key = *fKeywordProvider - 65;
    fKeywordProvider << aCharacter;
    char result = islower(aCharacter) 
        ? tolower(fMappingTable[toupper(aCharacter) - 65][key]) 
        : fMappingTable[toupper(aCharacter) - 65][key];
    return result;
}

// Decode a character using the current keyword character and update
// keyword.
char Vigenere::decode(char aCharacter)
{
    if (!isalpha(aCharacter)) return aCharacter;

    for (size_t i = 0; i < CHARACTERS; i++)
    {
        if (fMappingTable[*fKeywordProvider - 65][i] == toupper(aCharacter))
        {
            fKeywordProvider << (char)('A' + i);
            return islower(aCharacter) ? tolower('A' + i) : (char)('A' + i);
        }
    }

    return aCharacter;
};