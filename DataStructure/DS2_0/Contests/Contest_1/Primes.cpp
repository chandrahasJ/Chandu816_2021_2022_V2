#include<bits/stdc++.h>
using namespace std;

//https://www.hackerearth.com/problem/algorithm/monk-and-his-love-for-primes
char upperCase(char c){
    return c-32;
}

char lowerCase(char c){
    return c + 32;
}

string replaceUpperToLowerVC(string singleLine, int &resultASCII){

    string newSingleLine;
    for (int i = 0; i < singleLine.size(); ++i)
    {
        if ((int)singleLine[i]  >= 65 && (int)singleLine[i] <= 90)
        {
            char c = lowerCase(singleLine[i]);
            newSingleLine.push_back(c);            
            resultASCII = resultASCII + (int)c;
        }
        else if((int)singleLine[i]  >= 97 && (int)singleLine[i] <= 122)
        {           
            char c = upperCase(singleLine[i]);
            newSingleLine.push_back(c);
            resultASCII = resultASCII - (int)c;
        }
    }
    return newSingleLine;
}

int main()
{
   string singleLine, updatedSingleLine;
   int resultASCII;
   int primeFlag = 0;
   cin>>singleLine;
    updatedSingleLine = replaceUpperToLowerVC(singleLine, resultASCII);
    
    if(resultASCII < 0){
        resultASCII = resultASCII * -1;
    }

   // cout<< updatedSingleLine << " " << resultASCII << " " << endl;
    // 0 and 1 are not prime numbers
    // change flag to 1 for non-prime number
    if (resultASCII == 0 || resultASCII == 1)
        primeFlag = 1;

    for (int i = 2; i <= resultASCII/2; ++i)
    {
         if(resultASCII % i == 0){
                primeFlag = 1;
                break;
         }
    }
    
    if(primeFlag == 0){
        cout << 1;
    }
    else{
        cout << 0;
    }

    return 0;
}