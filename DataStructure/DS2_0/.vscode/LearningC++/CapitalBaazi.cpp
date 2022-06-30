#include<bits/stdc++.h>
using namespace std;

//CapitalBaazi

string makeTheWordCaptail(string inputStr) {
    for(int i = 0; i <= inputStr.size(); i++) {
      //  cout<< inputStr[i];
        inputStr[i] = inputStr[i]-32;
    }
    return inputStr;
}


int main()
{
    string inputSentence;
    getline(cin, inputSentence);
    string subStringSentence;
    inputSentence.push_back(' ');
    for(int i = 0; i <= inputSentence.size()-1; i++) {
        if(inputSentence[i] == ' ') {
            subStringSentence =
                makeTheWordCaptail(
                    subStringSentence
                );
            cout<< subStringSentence << endl;
subStringSentence.clear();
        }
        else {
            subStringSentence.push_back(
                inputSentence[i]
            );
        }
    }
    return 0;
}