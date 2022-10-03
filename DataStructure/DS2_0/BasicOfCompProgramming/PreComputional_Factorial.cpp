/*
    Given T Test Cases and in each test cases a 
    Number N. Print its factorial for each test case % M
    where M = 10^9+7

    Constraints 
    1 <= T <= 10^5
    1 <= N <= 10^5
*/
#include<bits/stdc++.h>
using namespace std;
const int M = 1000000007;
int N = 100005+10;
void factorialWithModulo(int N){
    int T;
    cin>>T;
    while (T--)
    {
        int N;
        cin>>N;
        long long factorial = 1;
        
        for (int i = 2; i <= N; i++)
        {
            factorial = (factorial * i) % M;
        }
        cout << "Modulo Factorial for "<<N <<" is "<<factorial<<endl; 
    }
    // O(T*N) = 10^10 so this code will not run in online compiler in less than 1 sec.
}

void preComputedFactorial(){
    int T;
    
    long long factorial[N];
    factorial[0] = factorial[1] = 1;
    for (int i = 2; i < N; i++)
    {
        
        //cout<<i-1<<" "<<factorial[i-1]<<endl;
        factorial[i] = (factorial[i-1] * i) % M; 
    }
    cin>>T;
    while (T--)
    {
        int number;
        cin>>number;
        cout << "Modulo Factorial for "<<number <<" is "<<factorial[number]<<endl; 
    }
    // Now O(N) + O(T) = 10e5 + 10e5 
    // This complexity will run within 1 sec.
}

int main()
{
    preComputedFactorial();    
    return 0;
}