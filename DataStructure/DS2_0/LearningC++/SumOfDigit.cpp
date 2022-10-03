#include<bits/stdc++.h>
using namespace std;

int main()
{
    //int testcase=0;
    //cin>>testcase;
   // while(testcase > 0){
   //     long int columns , rows = 0;
    //    cin >> rows >> columns;
        
   // }
   long int i = 0;
   cin>> i;
   if (i > 0){
       long int digit_sum = 0;
       while(i > 0){
          int last_digit= i % 10;
          digit_sum = digit_sum + last_digit;
          i = i / 10;
       }
       cout<< digit_sum;
   }
    return 0;
}