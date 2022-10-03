#include<bits/stdc++.h>
using namespace std;


int main()
{
   int testcase = 0;
   cin>> testcase;
   while (testcase--)
   {
        int inputs = 0;
        cin>> inputs;
        long long product= 1;;
        for (int i = 0; i < inputs; ++i)
        {   
            int x;
            cin>> x;
            product = product * x;
        }

        int result =product % 10;
        //cout <<result << " "<< product ;
        if (result == 2 || 
            result == 3 || 
            result == 5)
        {
            cout << "YES\n";
        }
        else{
            cout << "NO\n";
        }
        
   }       
    return 0;
}