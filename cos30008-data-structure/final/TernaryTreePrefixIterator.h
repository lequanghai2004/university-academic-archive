#pragma once
#include "TernaryTree.h"
#include <stack>

template<typename T>
class TernaryTreePrefixIterator
{
private:
	using TTree = TernaryTree<T>;
	using TTreeNode = TTree*;
	using TTreeStack = std::stack<const TTree*>;
	
	const TTree* fTTree; // ternary tree
	TTreeStack fStack; // traversal stack

	// push subtree of aNode [30]
	void push_subtrees(const TTree* aNode)
	{
		if (!aNode->getRight().empty())
			fStack.push(&aNode->getRight());

		if (!aNode->getMiddle().empty())
			fStack.push(&aNode->getMiddle());

		if (!aNode->getLeft().empty())
			fStack.push(&aNode->getLeft());
	}

public:
	using Iterator = TernaryTreePrefixIterator<T>;

	// iterator constructor [12]
	TernaryTreePrefixIterator(const TTree* aTTree) : fTTree(aTTree), fStack()
	{
		if (!(fTTree)->empty()) fStack.push(fTTree);
	}

	// prefix increment [12]
	Iterator& operator++()
	{
		TTreeNode lTree = const_cast<TTreeNode>(fStack.top());
		fStack.pop();
		push_subtrees(lTree);
		return *this;
	}

	Iterator operator++(int)
	{
		Iterator old = *this;
		++(*this);
		return old;
	}

	// iterator equivalence [12]
	bool operator==(const Iterator& aOtherIter) const
	{
		return fTTree == aOtherIter.fTTree 
			&& fStack.size() == aOtherIter.fStack.size();
	}

	bool operator!=(const Iterator& aOtherIter) const
	{
		return !(*this == aOtherIter);
	}

	// iterator dereference [8]
	const T& operator*() const
	{
		return **fStack.top();
	}



	Iterator begin() const
	{
		Iterator temp = *this;
		temp.fStack = TTreeStack();

		if (!temp.fTTree->empty())
		{
			temp.fStack.push(const_cast<TTreeNode>(temp.fTTree));
		}
		
		return temp;
	}

	Iterator end() const
	{
		Iterator temp = *this;
		temp.fStack = TTreeStack();
		return temp;
	}
};