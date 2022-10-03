#include<bits/stdc++.h>
using namespace std;

//https://www.hackerearth.com/problem/algorithm/christmas-tree-of-height-n/
int main()
{
   int testcase = 0;
   cin>> testcase;
   while (testcase--)
   {
        int number = 0;
        cin>> number;
        long long a[number][number];
        a[0][0] = 1;

        for (int i = 1; i < number; i++)
        {
            a[i][0] = 1;
            a[i][i] = 1;   
            for (int j = 1; j < i; j++)
            {
                a[i][j] = a[i-1][j-1] + a[i-1][j];
            }
                     
        }

        for (int i = 0; i < number; i++)
        {
            for (int j = 0; j <= i; j++)
            {
                cout<< a[i][j] << " ";
            }
            cout<<endl;
        }
        
        

   }
}