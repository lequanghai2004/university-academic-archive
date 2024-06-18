#include <iostream>
#include <numeric>
#include <stdexcept>
#include <vector>

void MoveDisk(std::vector<int>& src, std::vector<int>& dst)
{
    if (!dst.empty() && src.back() > dst.back())
    {
        throw std::runtime_error("Only lower or equal values are allowed");
    }

    dst.push_back(src.back());
    src.pop_back();
}

void PrintTowers(std::vector<int>* diskHolders, size_t height)
{
    std::cout << "Moved:\n";

    // for (size_t i = 0; i < 3; i++)
    // {
    //     for (size_t j = 0; j < diskHolders[i].size(); j++)
    //     {
    //         std::cout << diskHolders[i][j] << ", ";
    //     }

    //     std::cout << "\n";
    // }

    for (size_t i = height; i < height + 1; i--)
    {
        for (size_t j = 0; j < 3; j++)
        {
            if (diskHolders[j].size() <= i)
            {
                if (diskHolders[j].size() == i && i != 0)
                {
                    for (size_t k = 0; k <= height - diskHolders[j][i - 1] + 1;
                         k++)
                        std::cout << " ";
                    for (size_t k = 0; k <= diskHolders[j][i - 1] - 1; k++)
                        std::cout << "_";
                    std::cout << "|";
                    for (size_t k = 0; k <= diskHolders[j][i - 1] - 1; k++)
                        std::cout << "_";
                    for (size_t k = 0; k <= height - diskHolders[j][i - 1] + 1;
                         k++)
                        std::cout << " ";
                }
                else
                {
                    for (size_t k = 0; k <= height; k++) std::cout << " ";
                    std::cout << " | ";
                    for (size_t k = 0; k <= height; k++) std::cout << " ";
                }
                continue;
            }

            for (size_t k = 0; k <= height - diskHolders[j][i]; k++)
                std::cout << " ";
            std::cout << "/";
            for (size_t k = 0; k <= diskHolders[j][i] - 1; k++)
                std::cout << "_";
            std::cout << "|";
            for (size_t k = 0; k <= diskHolders[j][i] - 1; k++)
                std::cout << "_";
            std::cout << "\\";
            for (size_t k = 0; k <= height - diskHolders[j][i]; k++)
                std::cout << " ";
        }
        std::cout << "\n";
    }
}

/*
 * Time complexity: O(n^2 * 2^n)
 */
void RecursiveSolution(std::vector<int>* diskHolders,
    size_t height,
    size_t depth,
    size_t srcIndex,
    size_t dstIndex,
    size_t midIndex)
{
    // base case
    if (depth == 1)
    {
        MoveDisk(diskHolders[srcIndex], diskHolders[dstIndex]);
        PrintTowers(diskHolders, height);
        return;
    }

    // move n-1 top disk
    RecursiveSolution(
        diskHolders, height, depth - 1, srcIndex, midIndex, dstIndex);
    // move the largest disk to dst
    MoveDisk(diskHolders[srcIndex], diskHolders[dstIndex]);
    PrintTowers(diskHolders, height);
    // move n-1 top disk to dst
    RecursiveSolution(
        diskHolders, height, depth - 1, midIndex, dstIndex, srcIndex);
}

void HanoiTowerRecursive(int n)
{
    std::vector<int> diskHolders[3];
    for (int i = 0; i < 3; i++) diskHolders[i].reserve(n);
    for (size_t i = n; i > 0; i--) diskHolders[0].emplace_back(i);
    // std::iota(diskHolders[1].begin(), diskHolders[1].end(), 0);
    // std::iota(diskHolders[2].begin(), diskHolders[2].end(), 0);

    RecursiveSolution(diskHolders, n, n, 0, 2, 1);
    for (size_t i = 0; i < n; i++)
    {
        std::cout << diskHolders[2][i] << ", ";
    }
}

int main()
{
    HanoiTowerRecursive(5);
}