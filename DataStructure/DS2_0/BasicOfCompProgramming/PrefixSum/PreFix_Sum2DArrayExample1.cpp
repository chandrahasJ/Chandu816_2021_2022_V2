/*
    Given 2d Array a of N*N integer.
    Given Q Queries and in each query given a, b, c and d
    print the sum of square represented by (a,b) as top left point 
    and  (c,d) as bottom right point.

    Constraints
    1 <= N <= 10^3;
    1 <= a[i][j] <= 10e9;
    1 <= Q <= 10^5;
    1 <= a,b,c,d <= N
*/

#include <bits/stdc++.h>
using namespace std;
const long long M = 10e9;
const long long N = 10e3+10;
long long prefix[N][N];
long long ar[N][N];

void Normal(){
    int n;
    cin>>n;
    
    for (int i = 1; i <=n; i++)
    {
        for (int j = 1; j <= n; j++)
        {
            cin>>ar[i][j];
        }        
    }

    int Q;
    cin>>Q;
    while (Q--)
    {
        int a,b,c,d;
        cin>> a>>b>>c>>d;
        long long sum = 0;
        for (int i = a; i <= c; i++)
        {
            for (int j = b; j <= d; j++)
            {
                sum += ar[i][j];
            }        
        }
        cout<<sum<<endl;
    }
    // O(1N^2) + O(Q * N^2)   
    
}

void preFixSum_2DArray(){
        int n;
    cin>>n;
    
    for (int i = 1; i <=n; i++)
    {
        for (int j = 1; j <= n; j++)
        {
            cin>>ar[i][j];
            prefix[i][j] = ar[i][j]   +
                           prefix[i-1][j] +  
                           prefix[i][j-1] -
                           prefix[i-1][j-1];
        }         
    }

    int Q;
    cin>>Q;
    while (Q--)
    {
        int a,b,c,d;
        cin>> a>>b>>c>>d;
        long long sum = prefix[c][d] -
                        prefix[a-1][d] -
                        prefix[c][b-1] +
                        prefix[a-1][b-1];         
        cout<<sum<<endl;
    }
    // O(N^2) + O(Q)   
    
}

int main(){ 
    //Normal();
    preFixSum_2DArray();
    return 0;
}