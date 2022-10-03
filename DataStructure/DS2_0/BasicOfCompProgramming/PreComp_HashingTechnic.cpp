/*
    Given Array a of N intergers.
    Given Q Queries and in each query a number X,
    print count of that number in array.

    Constraints
    1 <= N <= 10e5;
    1 <= a[i] <= 10e7;
    1 <= Q <= 10^5;
*/

#include<bits/stdc++.h>
using namespace std;
const int M = 1000007+10;
int N = 100005+10;
int hashingArray[M];

void Normal(){
    int arraySize = 0;
    cin>> arraySize;
    int array[arraySize];
    for (int i = 0; i <= arraySize -1; i++)
    {
        cin>>array[i];
    }

    int queries = 0;
    cin>>queries;
    while (queries--)
    {
        int numberToSearch;
        cin>>numberToSearch;
        int counter = 0;
        for (int i = 0; i <= arraySize-1; i++)
        {
            if (array[i] == numberToSearch)
            {
                counter++;
            }            
        }

        cout<< counter<<endl;        
    }        
    // O(N) + O(Q * N) = O(Q^2) because limit for 10e5
}

void PreComp_Hashing(){
    int arraySize = 0;
    
    cin>> arraySize;
    int array[arraySize];
    for (int i = 0; i <= arraySize -1; i++)
    {
        cin>>array[i];
        hashingArray[array[i]]++;
    }

    int queries = 0;
    cin>>queries;
    while (queries--)
    {
        int numberToSearch;
        cin>>numberToSearch;         
        cout<< hashingArray[numberToSearch]<<endl;        
    }       
}

int main(){
    //Normal();

    PreComp_Hashing();
    return 0;
}