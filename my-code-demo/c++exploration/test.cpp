#include <algorithm>
#include <iostream>
#include <unordered_map>
#include <vector>

using namespace std;
class Solution
{
public:
    void solveSudoku(vector<vector<char>>& board)
    {
        unordered_map<pair<int, int>, vector<int>> umap;

        for (size_t i = 0; i < 9; i++)
        {
            /* code */
        }
    }
};

namespace std
{
    template <>
    struct hash<pair<int, int>>
    {
        size_t operator()(const pair<int, int>& key) const
        {
            size_t h1 = hash<int>()(key.first);
            size_t h2 = hash<int>()(key.second);
            return h1 ^ h2; // Combine using XOR
        }
    };
} // namespace std