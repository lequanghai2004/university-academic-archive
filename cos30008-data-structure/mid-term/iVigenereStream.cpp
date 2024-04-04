#include "iVigenereStream.h"

iVigenereStream::iVigenereStream(
    Cipher aCipher, const std::string& aKeyword, const char* aFileName) :
    fIStream(), fCipher(aCipher), fCipherProvider(aKeyword)
{
    open(aFileName);
}

iVigenereStream::~iVigenereStream() 
{
    if(fIStream.is_open()) close();
}

void iVigenereStream::open(const char* aFileName) 
{
    fIStream.open(aFileName, std::ios::binary);
    fIStream.unsetf(std::ios_base::skipws);
}

void iVigenereStream::close() 
{
    fIStream.close();
}

void iVigenereStream::reset() 
{
    fCipherProvider.reset();
    seekstart();
}

// conversion operator to bool
iVigenereStream::operator bool()
{
    return !eof();
}

// stream positioning
uint64_t iVigenereStream::position()
{
    return fIStream.tellg();
}

void iVigenereStream::seekstart()
{
    fIStream.clear();
    fIStream.seekg(0, std::ios_base::beg);
}

bool iVigenereStream::good() const
{
    return fIStream.good();
}
bool iVigenereStream::is_open() const
{
    return fIStream.is_open();
}
bool iVigenereStream::eof() const
{
    return fIStream.eof();
}

iVigenereStream& iVigenereStream::operator>>(char& aCharacter)
{
    char lCharacter;
    fIStream >> lCharacter;
    aCharacter = fCipherProvider.decode(lCharacter);
    return *this;
}