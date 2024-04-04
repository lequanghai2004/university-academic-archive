#pragma once 
#include "iVigenereStream.h" 

class VigenereForwardIterator
{
private:
	iVigenereStream& fIStream;
	char fCurrentChar;
	bool fEOF;
public:
	VigenereForwardIterator(iVigenereStream& aIStream);
	char operator*() const;
	VigenereForwardIterator& operator++();
	VigenereForwardIterator operator++(int);
	bool operator==(const VigenereForwardIterator& aOther) const;
	bool operator!=(const VigenereForwardIterator& aOther) const;
	VigenereForwardIterator begin() const;
	VigenereForwardIterator end() const;
};