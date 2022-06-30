#include<bits/stdc++.h>
using namespace std;

void printPrimeNumber(long int input1,
                      long int input2)
{
    bool is_prime= 0;
    while(input1 <= input2){
        if(input1 == 0 || input1 == 1){
           input1++;
           continue;
        }
           
        for (int i = 2; i <= input1/2; ++i) {
            cout << (input1)<< " " << i << " x ";
            cout << input1 % i << endl;
            if (input1 % i == 0) {
              is_prime = false;
              break;
            }
        }
        if(is_prime){
          cout<<input1<<endl;
        }
        else{
            cout<<"test "<< input1 << endl;
        }
        input1++;
    }
}

int main()
{
    int testcase = 0;
    int a = 0;
    cin>>testcase;
    while(testcase >0){
       long int input1, input2 =0;
       cin >> input1>> input2;
       if(input1 < input2){
           printPrimeNumber(input1, input2);
        }
        else if(input1 > input2){
           printPrimeNumber(input2, input1);
        }
       cout<<endl;
       testcase--;
    }
    return 0;
}