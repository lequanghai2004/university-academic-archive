#include <algorithm>
#include <iostream>
#include <string>
#include <vector>

int main()
{
    std::vector<int> vec = {1, 2, 3, 4, 5};
    std::ranges::for_each(vec, [](int i) { std::cout << i << " "; });
    std::cout << "\n";

    // std::ranges::sort(vec, [](int i1, int i2) { return i2 < i1; }, [](int i) { return i; });
    // std::ranges::sort(vec.begin(), vec.end(), [](int i1, int i2) { return i2 < i1; }, [](int i) { return i; });

    vec.insert(vec.begin() + 1, 0);
    std::ranges::for_each(vec, [](int i) { std::cout << i << " "; });
    std::cout << "\n";

    vec.erase(vec.begin() + 3);
    std::ranges::for_each(vec, [](int i) { std::cout << i << " "; });
    std::cout << "\n";
}