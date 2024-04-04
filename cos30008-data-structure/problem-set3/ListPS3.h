#pragma once
#include <stdexcept>

#include "DoublyLinkedList.h"
#include "DoublyLinkedListIterator.h"

template <typename T>
class List
{
private:
    // auxiliary definition to simplify node usage
    using Node = DoublyLinkedList<T>;
    Node* fRoot;
    size_t fCount;

public:
    // the first element in the list
    // number of elements in the list
    // auxiliary definition to simplify iterator usage
    using Iterator = DoublyLinkedListIterator<T>;

    // Print method
    void print() const
    {
        Iterator iter = begin();
        while (iter != end())
        {
            std::cout << *iter << " ";
            ++iter;
        }
        std::cout << std::endl;
    }

    // default constructor
    List() : fRoot(nullptr), fCount(0) {}

    // copy constructor
    List(const List& aOtherList) : fCount(0), fRoot(nullptr)
    {
        for (Iterator i = aOtherList.begin(); i != aOtherList.end(); ++i)
        {
            push_back(*i);
        }
    }

    // assignment operator
    List& operator=(const List& aOtherList)
    {
        if (&aOtherList == this) return *this;
        this->~List();
        *this = List(aOtherList);
        return *this;
    }

    // destructor - frees all nodes
    ~List()
    {
        if (!fRoot) return;

        Iterator i = ++begin();
        while (i != end()) delete i++.getCurrentNode();

        delete fRoot;
        fRoot = nullptr;
        fCount = 0;
    }

    // Is list empty?
    bool isEmpty() const
    {
        return fRoot == nullptr;
    }

    // list size
    size_t size() const
    {
        return fCount;
    }

    // adds aElement at front
    void push_front(const T& aElement)
    {
        if (isEmpty())
        {
            fRoot = new Node(aElement);
        }
        else
        {
            Node* lNode = new Node(aElement);
            fRoot->push_front(*lNode);
            fRoot = lNode;
        }
        ++fCount;
    }

    // adds aElement at back
    void push_back(const T& aElement)
    {
        Node* newNode = new Node(aElement);

        if (isEmpty())
        {
            fRoot = newNode;
        }
        else
        {
            Node* lastNode = const_cast<Node*>(&fRoot->getPrevious());
            lastNode->push_back(*newNode);
        }

        ++fCount;
    }

    // remove first match from list
    void remove(const T& aElement)
    {
        if (!fRoot) return;

        if (**fRoot == aElement)
        {
            fRoot = const_cast<Node*>(&fRoot->getNext());
            const_cast<Node&>(fRoot->getPrevious()).isolate();
            return;
        }

        Iterator i = begin();
        while (i != end())
        {
            if (*i == aElement)
            {
                const_cast<Node*>(i.getCurrentNode())->isolate();
                return;
            }
            i++;
        }
    }

    // list indexer
    const T& operator[](size_t aIndex) const
    {
        if (aIndex > size() - 1)
        {
            throw std::out_of_range("Index out of bounds");
        }
        Iterator lIterator = Iterator(fRoot).begin();
        for (size_t i = 0; i < aIndex; i++)
        {
            ++lIterator;
        }
        return *lIterator;
    }

    Iterator begin() const
    {
        return Iterator(fRoot).begin();
    }  // return a forward iterator

    Iterator end() const
    {
        return Iterator(fRoot).end();
    }  // return a forward end iterator

    Iterator rbegin() const
    {
        return Iterator(fRoot).rbegin();
    }  // return a backward iterator

    Iterator rend() const
    {
        return Iterator(fRoot).rend();
    }  // return a backward end iterator

    // move constructor
    List(List&& aOtherList) noexcept : 
        fCount(aOtherList.fCount), fRoot(aOtherList.fRoot) 
    {
        aOtherList.fRoot = nullptr;
        aOtherList.fCount = 0;
    }

    // move assignment
    List& operator=(List&& aOtherList) noexcept
    {
        if (&aOtherList == this) return *this;

        fRoot = aOtherList.fRoot;
        fCount = aOtherList.fCount;

        aOtherList.fRoot = nullptr;
        aOtherList.fCount = 0;
        return *this;
    }

    // adds aElement at front
    void push_front(T&& aElement)
    {
        if (isEmpty())
        {
            fRoot = new Node(std::move(aElement));
        }
        else
        {
            Node* lNode = new Node(std::move(aElement));
            fRoot->push_front(*lNode);
            fRoot = lNode;
        }
        ++fCount;
    }

    // adds aElement at back
    void push_back(T&& aElement)
    {
        Node* newNode = new Node(aElement);

        if (isEmpty())
        {
            fRoot = newNode;
        }
        else
        {
            Node* lastNode = const_cast<Node*>(&fRoot->getPrevious());
            lastNode->push_back(*newNode);
        }
        ++fCount;
    }
};