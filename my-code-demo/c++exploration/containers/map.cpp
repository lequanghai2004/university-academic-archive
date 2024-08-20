#include <algorithm>
#include <iostream>
#include <map>

#define MAP
// #define MULTIMAP

int main()
{
#ifdef MAP
    std::map<int, std::string> map;
    map.insert({2, "two"});
    map.insert({1, "one"});
    map.insert({1, "four"}); // Duplicated element will not be inserted
    map.insert({3, "three"});
    std::ranges::for_each(map, [](std::pair<int, std::string> p) { std::cout << p.first << ": " << p.second << "\n"; });
    std::cout << "----------------\n";

    map.erase(2);
    std::ranges::for_each(map, [](std::pair<int, std::string> p) { std::cout << p.first << ": " << p.second << "\n"; });
    std::cout << "----------------\n";

    auto it = map.find(1);
#endif // MAP

    // -----------------------------------------------------------------------------------------------------------------

#ifdef MULTIMAP
    std::multimap<int, std::string, std::greater<int>> mmap;
    mmap.insert({2, "two"});
    mmap.insert({1, "one"});
    mmap.insert({1, "four"}); // Duplicated element will still be inserted
    mmap.insert({3, "three"});

    auto [lower, upper] = mmap.equal_range(1);
    std::ranges::for_each(
        lower,
        upper,
        [](std::pair<int, std::string> p) { std::cout << p.first << ": " << p.second << "\n"; });
    std::cout << "----------------\n";

    std::ranges::for_each(
        mmap,
        [](std::pair<int, std::string> p) { std::cout << p.first << ": " << p.second << "\n"; });
    std::cout << "----------------\n";

    mmap.erase(2);
    std::ranges::for_each(
        mmap,
        [](std::pair<int, std::string> p) { std::cout << p.first << ": " << p.second << "\n"; });
    std::cout << "----------------\n";
#endif // MULTIMAP

    // -----------------------------------------------------------------------------------------------------------------
}