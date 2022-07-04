#include<bits/stdc++.h>
using namespace std;

//https://www.hackerearth.com/problem/algorithm/city-tour/
// Question looked complicated but the answer was easy... 
// when it was exaplained..
// read the question 3 times is the learning...
int main()
{
   int testcase = 0;
   cin>> testcase;
   while (testcase--)
   {
        long long int no_of_steps;
        cin>>no_of_steps;
        //multiplying by 4 since we have four quardant.
        cout<< no_of_steps * 4 <<endl;
   }
}