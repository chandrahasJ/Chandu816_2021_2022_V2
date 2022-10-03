// https://leetcode.com/problems/single-number/
/*
    Given a non-empty array of integers nums, every element appears twice except for one.
     Find that single one.

    You must implement a solution with a linear runtime complexity and use only constant extra space.
    Constraints:

    1 <= nums.length <= 3 * 104
    -3 * 104 <= nums[i] <= 3 * 104
    Each element in the array appears twice except for one element which appears only once.
*/
#include<bits/stdc++.h>
using namespace std;
const int M = 1000007+10;
int N = 100005+10;
int hashingArray[M];

int solution(){
    int n = 0;
    cin>> n;
    int arrayNumber[n];
    for (int i = 0; i <= n-1; i++)
    {
        cin>>arrayNumber[i];        
    }
    for (int i = 0; i <= n-1; i++)
    {
        long long data =  30000 + arrayNumber[i];
        
        hashingArray[data]++;
    }
    
    for (int i = 0; i <= n-1; i++)
    {
        if (hashingArray[arrayNumber[i]+3*10000] == 1)
        {
            return arrayNumber[i];
        }        
    }
    return 0;
}


int main(){
    cout<<solution();
    return 0;
}
