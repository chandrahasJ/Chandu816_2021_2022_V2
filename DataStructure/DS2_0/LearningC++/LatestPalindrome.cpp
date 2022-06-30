#include<iostream>
using namespace std;

void palindromeV1(string inputStr) {
    string reverseStr;
    for(int i = inputStr.size()-1; i >= 0; i--) {
        reverseStr.push_back(inputStr[i]);
    }
    cout<< reverseStr<<endl;
    if(inputStr == reverseStr) {
        cout<< "Palindrome Yes"<< endl;
    }
    else {
        cout<< "Palindrome No"<< endl;
    }
}

void palindromeV2(string inputStr) {
    int length = inputStr.size();
    bool isPalindrome = true;
    for(int i = 0; i < length/2; i++) {
        if(inputStr[i] != inputStr[length - 1 - i]) {
            isPalindrome = false;
            break;
        }
    }
    if(isPalindrome == false) {
        cout<< "NO"<< endl;
    }
    else {
        cout<< "YES"<< endl;
    }
}


int main()
{
    string inputStr, reverseStr;
    getline(cin, inputStr);
   // palindromeV1(inputStr);

    palindromeV2(inputStr);
    return 0;
}