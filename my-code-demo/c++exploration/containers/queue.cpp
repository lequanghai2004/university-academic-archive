#include <iostream>
#include <queue>

int main()
{
    std::queue<int> pq;

    // Insert elements into the priority queue
    pq.push(1);
    pq.push(2);
    pq.push(3);
    pq.push(4);
    pq.push(5);

    // Print the priority queue elements
    std::cout << "Priority queue elements: ";
    while (!pq.empty())
    {
        std::cout << pq.front() << " ";
        pq.pop();
    }
    std::cout << "\n";
}