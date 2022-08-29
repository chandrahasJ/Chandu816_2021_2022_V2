/*
	https://practice.geeksforgeeks.org/problems/max-sum-subarray-of-size-k5313/1
    https://www.youtube.com/watch?v=nZe7P674xZo&list=PLauivoElc3ggagradg8MfOZreCMmXMmJ-&index=20
    Max Sum Subarray of size K

    Given an array of integers Arr of size N and a number K. 
    Return the maximum sum of a subarray of size K.    

    Input:
        N = 4, K = 2
        Arr = [100, 200, 300, 400]
    Output:
        700
    Explanation:
        Arr3  + Arr4 =700,
        which is maximum.

    Your Task:
        You don't need to read input or print anything. 
        Your task is to complete the function maximumSumSubarray() 
        which takes the integer k, vector Arr with size N, 
        containing the elements of the array and returns the maximum sum of a subarray of size K.

	Constraints:
	1 <= N <= 10^6
	1 <= K <= N
		
    I was not able to solve it 
    https://www.codingninjas.com/codestudio/library/k-maximum-sums-of-overlapping-contiguous-sub-arrays
*/

#include <bits/stdc++.h>
using namespace std;
const int N = 10e6+20;
long long prefixSum[N];

 int getMaxSubArray(int k, int array[], int n){
        
        long long counter = 0, currentPos = 0;
        long long sum=0, maxSum = 0;
        long long i = 0;
        for (int j = 0; j <= n; j++)
        {
            prefixSum[j] = 0;
        }
        
        while ( i <= n ){
            
            if(counter == k){
                counter=0;                
                maxSum = prefixSum[currentPos];
                currentPos++;
                i = currentPos;
                //cout<<" "<<i<<" "<<endl;  
                continue;           
            }     
            prefixSum[currentPos] += array[i];
           // cout<<maxSum<<" "<<prefixSum[currentPos]<<" "<<prefixSum[currentPos-1]<<" - ";
            i++;             
            counter++;
           
        }
        if(counter == k){
            if(maxSum >= prefixSum[currentPos-1]){
                    maxSum = prefixSum[currentPos-1];
            }
        }
        else{
            if(maxSum >= prefixSum[currentPos]){ //>= prefixSum[currentPos-1]){
                    maxSum = prefixSum[currentPos];
            }
        }
        cout<<maxSum<<endl;
        return maxSum;        
    }


int main(){ 
    int array[4] = {100, 200, 300, 400};
    getMaxSubArray(2, array, 4);
    //cout<<endl<<"END"<<endl;
    int array3[4] = {100, 200, 300, 400};
    getMaxSubArray(4, array3, 4);
    int array2[7] = {4,5,3,1,10,1,5};
    //cout<<endl<<"END"<<endl;
    getMaxSubArray(3, array2, 7);
    return 0;
}
