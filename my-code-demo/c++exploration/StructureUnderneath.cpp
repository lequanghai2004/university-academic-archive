#include <iostream>
#include <map>
#include <set>
#include <stack>
#include <string>
#include <tuple>
#include <unordered_map>
#include <unordered_set>

#include "Container.hpp"

// #define STACK
// #define PTR_VEC

// #define VAL_SET
// #define VAL_USET
// #define VAL_MSET
// #define VAL_UMSET
#define VAL_UMMAP

// #define PTR_USET
// #define PTR_UMSET

int main()
{
#ifdef STACK
  std::stack<Container> stack;
  stack.push(Container(2, ""));
  stack.push(Container(4, ""));
  stack.push(Container(5, ""));
  stack.push(Container(2, ""));
  stack.push(Container(7, ""));
  while (!stack.empty())
  {
    stack.top().print();
    stack.pop();
  }
#endif // STACK

#ifdef VAL_SET
  std::set<Container> set;

  // less<Container> is used to balance the tree
  // when less(a,b) && less(b,a) == false no insertion is made
  set.insert(Container{6, ""});
  std::cout << "\n";
  set.insert(Container{6, ""});
  std::cout << "\n";
  set.insert(Container{3, ""});
  std::cout << "\n";
  set.insert(Container{4, ""});
  std::cout << "\n";
  set.insert(Container{1, ""});
  std::cout << "\n\n";

  for (const Container &con : set)
  {
    con.print();
  }
#endif // VAL_SET

#ifdef PTR_VEC
  std::vector<Container *> vec;
  vec.push_back(new Container(6, ""));
  vec.push_back(new Container(3, ""));
  vec.push_back(new Container(4, ""));
  vec.push_back(new Container(1, ""));
  vec.push_back(new Container(5, ""));

    Container* c = new  Container(1, ")";
    auto found = std::find(vec.begin(), vec.end(), c);

    for (const Container* con : vec)
    {
    con->print();
    }
#endif // PTR_VEC

#ifdef PTR_USET
    std::unordered_set<Container*> uset;
    uset.insert(new Container(6, ""));
    uset.insert(new Container(3, ""));
    uset.insert(new Container(4, ""));
    uset.insert(new Container(1, ""));

    // after hash<Container*> these 2 lines has same hash value
    // however equal_to<Container*> prove they are difference
    // therefore duplication depends completely on std::equal_to<T>
    uset.insert(new Container(5, "Sang"));
    uset.insert(new Container(5, "Hai"));

    for (const Container* con : uset)
    {
    con->print();
    }

    // can find since both are inserted
    (*uset.find(new Container(5, "Hai")))->print();
#endif // PTR_USET

#ifdef VAL_USET
    std::unordered_set<Container> uset;
    uset.insert(Container(6, ""));
    uset.insert(Container(3, ""));
    uset.insert(Container(4, ""));
    uset.insert(Container(1, ""));
    uset.insert(Container(5, ""));
    uset.insert(Container(5, ""));

    for (const Container& con : uset)
    {
    con.print();
    }
#endif // VAL_USET

#ifdef VAL_MSET
    std::multiset<Container> mset;

    // less is used to insert
    mset.insert(Container(6, ""));
    mset.insert(Container(3, ""));
    mset.insert(Container(4, ""));
    mset.insert(Container(1, ""));
    mset.insert(Container(5, "Hai"));
    mset.insert(Container(5, "Sang"));

    for (const Container& con : mset)
    {
    con.print();
    }

    // less is used to find as well
    (*mset.find(Container(5, "Sang"))).print();
    std::cout << "Contains?\n" << mset.contains(Container(5, "H")) << "\n";
#endif // VAL_MSET

#ifdef VAL_UMSET
    std::unordered_multiset<Container> muset;
    std::cout << "\n";
    muset.insert(Container(6, ""));
    std::cout << "\n";
    muset.insert(Container(3, ""));
    std::cout << "\n";
    muset.insert(Container(4, ""));
    std::cout << "\n";
    muset.insert(Container(1, ""));
    std::cout << "--\n";
    muset.insert(Container(5, "Hai"));
    std::cout << "--\n";
    muset.insert(Container(5, "Sang"));
    std::cout << "--\n";

    for (const Container& con : muset)
    {
    con.print();
    }

    (*muset.find(Container(5, "Hai"))).print();
    std::cout << "Contains?\n" << muset.contains(Container(5, "Hai")) << "\n";
#endif // VAL_UMSET

#ifdef PTR_UMSET
    std::unordered_multiset<Container*> muset;
    muset.insert(new Container(6, ""));
    muset.insert(new Container(3, ""));
    muset.insert(new Container(4, ""));
    muset.insert(new Container(1, ""));
    muset.insert(new Container(5, "Hai"));
    muset.insert(new Container(5, "Sang"));

    for (const Container* con : muset)
    {
    con->print();
    }

    if (muset.bucket_count())
    {
    std::cout << "-----------------\n";
    size_t bucketIndex = muset.bucket(new Container(5, "Hi"));

    std::unordered_multiset<Container *>::iterator it
        = muset.begin(bucketIndex);
    while (it != muset.end(bucketIndex)) (*it++)->print();
    }
    std::cout << "-----------------\n";

    (*muset.find(new Container(5, "Hai")))->print();
    std::cout << "Contains?\n" << muset.contains(new Container(5, "Hai")) << "\n";
#endif // VAL_UMSET

#ifdef VAL_UMMAP
    std::unordered_multimap<Container, int> ummap;

    // rvalue Container is moved to into pair
    // however, then pair is moved to map
    // since the Container in pair is value type
    // the Container is copied to the map's pair
    // e.g. pair<Container,int>(pair<Container,int>&& other)
    // : key(other.key) ---> this is where the copy happens
    // .......... { .... }
    // => it is not avoidable for value type
    ummap.emplace(std::pair<const Container, int>(Container(3, "A"), 3));
    std::cout << "==========\n";
    ummap.emplace(std::pair<const Container, int>(Container(3, "B"), 4));
    std::cout << "==========\n";
    ummap.emplace(std::pair<const Container, int>(Container(3, "C"), 5));
    std::cout << "==========\n";
    ummap.emplace(std::pair<const Container, int>(Container(3, "D"), 8));
    std::cout << "==========\n";
    ummap.emplace(std::pair<const Container, int>(Container(3, "E"), 1));
    std::cout << "==========\n";

    for (const std::pair<Container, int>& pair : ummap)
    {
    std::cout << "Key: ";
    pair.first.print();
    std::cout << "Value: " << pair.second << "\n";
    }
#endif // VAL_UMMAP
}
