#pragma once

#include <fstream>
#include <functional>

#include "Vigenere.h"
#include "stdint.h"

using Cipher = std::function<char(Vigenere& aCipherProvider, char aCharacter)>;

class iVigenereStream
{
private:
    std::ifstream fIStream;
    Vigenere fCipherProvider;
    Cipher fCipher;

public:
    iVigenereStream(Cipher aCipher,
        const std::string& aKeyword,
        const char* aFileName = nullptr);
    ~iVigenereStream();

    void open(const char* aFileName);
    void close();
    void reset();

    // conversion operator to bool
    operator bool();
    // stream positioning
    uint64_t position();
    void seekstart();
    bool good() const;
    bool is_open() const;
    bool eof() const;

    iVigenereStream& operator>>(char& aCharacter);
};