#include <bits/stdc++.h>
using namespace std;
const int M = 1000007+10;
int N = 100005+10;
int hashArray[M];

void findDuplicate(){

    bool isDuplicate;
    int n = 0;
    cin>> n;
    int arrayNumber[n];    
    for(int i =0; i <= n-1;i++){
        cin>>arrayNumber[i];
        hashArray[arrayNumber[i]]++;
    }
    for(int i =0; i <= n-1;i++){
        cout<<hashArray[arrayNumber[i]];
        if(hashArray[arrayNumber[i]]>=2){
            isDuplicate = true;
            break;
        }
    }
    if (isDuplicate)
    {
        cout<<"true";
    }
    else
    {
        cout<<"false";
    }
    
}

int main()
{
    findDuplicate();
    return 0;
}