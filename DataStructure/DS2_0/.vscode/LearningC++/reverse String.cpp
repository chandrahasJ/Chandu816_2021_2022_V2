#include<iostream>
using namespace std;

int main()
{
    string inputStr, reverseStr;
    getline(cin, inputStr);
    for(int i = inputStr.size();i > 0; i--){
          reverseStr.push_back(inputStr[i]);
    }
    cout<< reverseStr;
    return 0;
}