// https://practice.geeksforgeeks.org/problems/in-first-but-second5423/1
/*
   Given two arrays A and B contains integers of size N and M, the task is to 
   find numbers which are present in the first array, 
   but not present in the second array.

Your Task:
    This is a function problem. You don't need to take any input, 
    as it is already accomplished by the driver code. You just need to complete the function 
    findMissing() that takes array A, array B, integer N, and integer M  as parameters and 
    returns an array that contains the missing elements and the order of the elements 
    should be the same as they are in array A.

Expected Time Complexity: O(N+M).
Expected Auxiliary Space: O(M).

Constraints:
1 ≤ N, M ≤ 10^6
-10^6 ≤ A[i], B[i] ≤ 10^6
*/
#include<bits/stdc++.h>
using namespace std;
const int M = 1000007+10;
int N = 100005+10;
int hashingArray[M];

int findingMissingNumber(){
    int n = 0;
    cin>> n;
    int arrayNumber[n];    
    for (int i = 0; i <= n-1; i++)
    {
        cin>>arrayNumber[i];       
        long long data =  100000 + arrayNumber[i];
        
        hashingArray[data]++;
        //cout<<hashingArray[data] << " " <<arrayNumber[i]<<endl; 
    }

    int m = 0;
    cin>>m;
    int secondArray[m];
    for (int i = 0; i <= m-1; i++)
    {
        cin>>secondArray[i]; 
        long long data =  100000 + secondArray[i];
        
        hashingArray[data]++;
        //cout<<hashingArray[data] << " " <<secondArray[i]<<endl;                    
    }

    for (int i = 0; i <= n-1; i++)
    {
        // cout<<hashingArray[secondArray[i]+100000] << "\t " 
        //     <<secondArray[i]<<"\t" <<hashingArray[arrayNumber[i]+100000]
        //     <<"\t"<<arrayNumber[i]<< endl;
        if (hashingArray[arrayNumber[i]+100000] == 1)
        {
           cout<<arrayNumber[i]<<"\t";
        }
        
    }
    
    return 0;
}


int main(){
    findingMissingNumber();
    return 0;
}
