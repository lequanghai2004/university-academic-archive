#include "VigenereForwardIterator.h" 

VigenereForwardIterator::VigenereForwardIterator(iVigenereStream& aIStream) : 
	fIStream(aIStream), fEOF(false)
{
	fIStream >> fCurrentChar;
}

char VigenereForwardIterator::operator*() const
{
	return fCurrentChar;
}

VigenereForwardIterator& VigenereForwardIterator::operator++()
{
	if (fEOF) return *this;
	fIStream >> fCurrentChar;
	if (fCurrentChar == '\0') fEOF = true;
	return *this;
} // prefix increment  

VigenereForwardIterator VigenereForwardIterator::operator++(int)
{
	auto temp = this;
	++*this;
	return *temp;
}// postfix increment  
	
bool VigenereForwardIterator::operator==(const VigenereForwardIterator& aOther) const
{
	return &fIStream == &aOther.fIStream && fEOF == aOther.fEOF;
}

bool VigenereForwardIterator::operator!=(const VigenereForwardIterator& aOther) const
{
	return !(*this == aOther);
}

VigenereForwardIterator VigenereForwardIterator::begin() const
{
	VigenereForwardIterator lResult = *this;
	lResult.fIStream.reset();
	lResult.fEOF = lResult.fIStream.eof();
	if (!lResult.fEOF) lResult.fIStream >> lResult.fCurrentChar;
	return lResult;
}

VigenereForwardIterator VigenereForwardIterator::end() const
{
	VigenereForwardIterator iter(fIStream);
	iter.fEOF = true;
	return iter;
}