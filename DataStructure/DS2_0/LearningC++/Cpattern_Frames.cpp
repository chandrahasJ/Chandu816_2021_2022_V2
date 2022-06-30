#include<bits/stdc++.h>
using namespace std;

int main()
{
    int testcase=0;
    cin>>testcase;
    while(testcase > 0){
        long int columns , rows = 0;
        cin >> rows >> columns;
        for(int i = 1; i <= rows;i++){
            for(int j = 1; j <= columns; j++){
                if(i == 1 || j == 1 || i == rows){
                   cout<<"*";
                }
                else if(j  == columns){
                   cout<<"*";
                }
                else{
                    cout<<".";
                }
            }
            cout<<endl;
         }
    }
    return 0;
}