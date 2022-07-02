#include<bits/stdc++.h>
using namespace std;

//https://www.rapidtables.com/convert/number/binary-to-decimal.html
int main()
{
    int testcase = 0;
    cin>> testcase;
    while (testcase--)
    { 
        long long PowerOf2 = 1;
        int actualNumber = 0;
        long long  binaryPass = 0;
        cin>>binaryPass;
        while (binaryPass > 0)
        {
            long long binary_digit = binaryPass % 10;
            binaryPass = binaryPass / 10;     
            if(binary_digit > 1 ){
                actualNumber = 0;
                break;
            }
            actualNumber = actualNumber + (binary_digit * PowerOf2);  
             cout<<    binary_digit <<" " << (binary_digit * PowerOf2)   << " "    ; 
             cout<<    actualNumber <<" "       ; 
             cout<<    PowerOf2 <<" " << endl; 
            PowerOf2 = PowerOf2 * 2;
        }
        cout << actualNumber<<endl;
    }       
    return 0;
}