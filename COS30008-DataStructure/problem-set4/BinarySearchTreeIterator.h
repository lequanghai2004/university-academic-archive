
// COS30008, Problem Set 4, Problem 3, 2022

#pragma once

#include "BinarySearchTree.h"

#include <stack>

template<typename T>
class BinarySearchTreeIterator
{
private:
    
    using BSTree = BinarySearchTree<T>;
    using BNode = BinaryTreeNode<T>;
    using BTreeNode = BNode*;
    using BTNStack = std::stack<BTreeNode>;

    const BSTree& fBSTree;		// binary search tree
    BTNStack fStack;			// DFS traversal stack
    
    void pushLeft( BTreeNode aNode )
    {
        while (!aNode->empty())
        {
            fStack.push(aNode);
            aNode = aNode->left;
        }
    }
    
public:
    
    using Iterator = BinarySearchTreeIterator<T>;
    
    BinarySearchTreeIterator( const BSTree& aBSTree ) : fBSTree(aBSTree)
    { }

    const T& operator*() const
    {
        return fStack.top()->key;
    }

    Iterator& operator++()
    {
        auto lTop = fStack.top();
        fStack.pop();
        if (!lTop->right->empty()) pushLeft(lTop->right);
        return *this;
    }
    
    Iterator operator++(int)
    {
        Iterator lTemp(*this);
        ++*this;
        return lTemp;
    }
    
    bool operator==( const Iterator& aOtherIter ) const
    {
        return &fBSTree == &aOtherIter.fBSTree && fStack == aOtherIter.fStack;
    }
    
    bool operator!=( const Iterator& aOtherIter ) const
    {
        return !(*this == aOtherIter);
    }
    
    Iterator begin() const
    {
        Iterator iter(fBSTree);
        iter.pushLeft(fBSTree.fRoot);
        return iter;
    }

    Iterator end() const
    {
        Iterator iter(fBSTree);
        BTNStack emptyStack;
        iter.fStack.swap(emptyStack);
        return iter;
    }
};
