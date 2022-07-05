#include<bits/stdc++.h>
using namespace std;

//https://www.hackerearth.com/problem/algorithm/too-lazy-to-name-the-question/
// LCM = 
int main()
{
   int A, B, C;
   cin>> A >> B >> C;

   int cth_Number;
   // Given 3 positive numbers A, B and C. We make a set 
   // which contains numbers that are either multiples of A or B or (A and B) in increasing order.
   // We take the C-th number of set and print from C-th number
   // to 0 with a step value of A or B
   int i = 2;
   while (true)
   {
        if(i % A == 0 || i % B == 0){
            cth_Number = i;
            C--;           
     //       cout<< cth_Number << " ";
        }         
        if(C <= 0){
            break;;
        }
        i++;
   }

    int lcm;
   for (int ii = 1; ii <= A*B; ii++)
   {
       if(ii % A == 0 && ii % B == 0){
           lcm = ii;
           break;
        }    
   }
 //  cout<<lcm<< " ";

// Finding Step 
// print from C-th number to 0 with a step value of A or B 
// whichever it is multiple of and if its a multiple of both, then use step value as LCM(A, B)
   int step;
   if(cth_Number % A == 0 && cth_Number % B == 0 ){
        step = lcm;
   }
   else if(cth_Number % A == 0 ){
        step = A;
   }
   else if(cth_Number % B == 0 ){
    step = B;
   }

    // Print the LCM value 
     //We take the C-th number of set and print from C-th number to 0 with a step value of A or B whichever
     // it is multiple of and if its a multiple of both, then use step value as LCM(A, B)
   int iii = cth_Number;
   while (iii >= 0)
   {
        cout<< iii << " ";
        iii = iii - step;
   }
   
}