#include <iostream>
#include <queue>
#include <tuple>

int main()
{
    std::priority_queue<std::tuple<int, int, int>,
        std::vector<std::tuple<int, int, int>>,
        std::greater<std::tuple<int, int, int>>>
        edges;  // min heap

    edges.emplace(1, 1, 2);
    edges.emplace(7, 1, 3);
    edges.emplace(5, 4, 2);
    edges.emplace(6, 5, 2);
    edges.emplace(2, 3, 4);
    edges.emplace(9, 5, 7);
    edges.emplace(3, 5, 6);
    edges.emplace(4, 7, 8);
    edges.emplace(8, 6, 8);

    int nodes[9] = {-1, -1, -1, -1, -1, -1, -1, -1, -1};

    while (!edges.empty())
    {
        auto [cost, i1, i2] = edges.top();
        edges.pop();

        int r1 = i1;
        int r2 = i2;

        while (nodes[r1] > 0) r1 = nodes[r1];
        while (nodes[r2] > 0) r2 = nodes[r2];

        if (r1 == r2)
        {
            std::cout << i1 << ", " << i2 << " - " << cost << "\n";
        }
        else if (nodes[r1] < nodes[r2])
        {
            nodes[r1] += nodes[r2];
            nodes[r2] = r1;
        }
        else
        {
            nodes[r2] += nodes[r1];
            nodes[r1] = r2;
        }
    }

    return 0;
}
