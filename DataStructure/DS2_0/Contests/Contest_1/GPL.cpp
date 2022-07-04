#include<bits/stdc++.h>
using namespace std;

void Type1(){
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

void Type2(){
    //Working..
    int n;
    cin>>n;
    string binaryData;
    cin>>binaryData;
    long long result = 0;
    long long powerOf2 = 1;
    for (int i = binaryData.size() -1; i >= 0; i--)
    {
         int binary_digit = binaryData[i] - '0';
         result = result +(binary_digit * powerOf2);
         powerOf2 = powerOf2 * 2;
    }
    cout<<result<<endl;
}

//https://www.rapidtables.com/convert/number/binary-to-decimal.html
int main()
{
    int testcase = 0;
    cin>> testcase;
    while (testcase--)
    { 
       //Type1(); //My Solution 
       Type2();
    }       
    return 0;
}