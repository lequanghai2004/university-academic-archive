#include <algorithm>
#include <iostream>
#include <queue>

int main()
{
    std::priority_queue<int> pq;

    // Insert elements into the priority queue
    pq.push(4);
    pq.push(2);
    pq.push(1);
    pq.push(5);
    pq.push(3);

    // Print the priority queue elements
    std::cout << "Priority queue elements: ";
    while (!pq.empty())
    {
        std::cout << pq.top() << " ";
        pq.pop();
    }
    std::cout << "\n";
}