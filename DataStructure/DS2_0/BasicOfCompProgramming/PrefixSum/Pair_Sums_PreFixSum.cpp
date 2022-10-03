/*
	https://www.hackerearth.com/practice/data-structures/hash-tables/basics-of-hash-tables/practice-problems/algorithm/pair-sums/
	Pair Sums
	Problem
	You have been given an integer array A and a number K. 
	Now, you need to find out whether any two different elements 
	of the array A sum to the number K. Two elements are considered 
	to be different if they lie at different positions in the array.
	If there exists such a pair of numbers, print "YES" (without quotes), 
	else print "NO" without quotes.

	Input Format:
	The first line consists of two integers N, denoting the size of array A and K. 
	The next line consists of N space separated integers denoting the elements of 
	the array A.

	Output Format:
		Print the required answer on a single line.

	Constraints:
	1 <= N <= 10^6
	1 <= K <= 2 * 10^6
	1 <= A[i] <= 10^6
		
*/

#include <bits/stdc++.h>
using namespace std;
const int N = 10e6+20;
long long prefix[N];

void pair_Sum(){
    long long n, pair_number; 
    cin>>n>>pair_number;

    long long array[n];
    prefix[0] = 0;
    int flag = 0;
    for (int i = 1; i <= n; i++)
    {
        cin>>array[i];
        prefix[i] =  array[i];          
        if((prefix[i] + prefix[i-1])  == pair_number){
            flag = 1;
            break;
        }      
    }
     if (flag == 0)
        cout << "NO\n";
    else
        cout << "YES\n";
}

int main()
{        
    pair_Sum();
    return 0;
}