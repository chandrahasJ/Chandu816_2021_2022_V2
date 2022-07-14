/*

*/
#include<bits/stdc++.h>
using namespace std;

void factorial(int N){
    long long factorial =1;
    for (int i = 2; i <= N; i++)
    {
        factorial = factorial * i;
    }
    cout << "Normal Factorial > "<<factorial<<endl; 
}

void factorialWithModulo(int N){
    long long factorial = 1;
    int M = 1000000007;
    for (int i = 2; i <= N; i++)
    {
        factorial = (factorial * i) % M;
    }
    cout << "Modulo Factorial > "<<factorial<<endl; 
}

int main()
{
    int n;
    cin>>n;
    factorial(n);
    factorialWithModulo(n);
    return 0;
}