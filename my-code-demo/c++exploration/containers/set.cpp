#include <algorithm>
#include <iostream>
#include <set>

int main()
{
    std::set<int> set;

    // Insert elements into the set
    set.insert(1);
    set.insert(2);
    set.insert(3);
    set.insert(4);
    set.insert(5);

    // Print the set elements
    std::cout << "Set elements: ";
    std::ranges::for_each(set, [](int i) { std::cout << i << " "; });
    std::cout << "\n";

    // Returns an iterator to the first element that is not less than 3 (>= 3)
    std::set<int>::iterator lower = set.lower_bound(3);
    // Returns an iterator to the first element that is greater than 3 (> 3)
    std::set<int>::iterator upper = set.upper_bound(3);

    std::cout << "lower_bound(3): " << *lower << "\n"; // Should print 3
    std::cout << "upper_bound(3): " << *upper << "\n"; // Should print 4
}
