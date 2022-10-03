/*
    https://www.hackerearth.com/practice/data-structures/hash-tables/basics-of-hash-tables/practice-problems/algorithm/xsquare-and-double-strings-1/

    Xsquare got bored playing with the arrays all the time. 
    Therefore, he has decided to play with the strings. 
    Xsquare called a string P a "double string" 
    if string P is not empty and can be broken into two strings A and B 
    such that A + B = P and A = B. 
    for eg : strings like "baba" , "blabla" , "lolo" are all double strings 
    whereas strings like "hacker" , "abc" , "earth" are not double strings at all.

    Today, Xsquare has a special string S consisting of lower case English letters.
    He can remove as many characters ( possibly zero ) as he wants from his special string S.
    Xsquare wants to know , if its possible to convert his string S to a double string or not.
    Help him in accomplishing this task.
Note :
    Order of the characters left in the string is preserved even after deletion of some characters.
*/
#include <bits/stdc++.h>
using namespace std;
const int M = 100+20;
int N = 100+10;


void findDoubleString(){
    int queries;
    cin>>queries;
    while (queries--)
    {
        int hashArray[M];
        int flag = 0;
        string s;
        cin>> s;
        if(s.size() == 0)
            continue;
        
        for (int i = 0; i < M; i++)
        {
            hashArray[i] = 0;
        }
                 
        for (int i = 0; i <= s.size()-1; i++)
        {                        
            char upperCase = s[i]-32;
            ++hashArray[(int)upperCase];
           // cout<<s[i]<<" "<<(int)upperCase<<" "<<upperCase<<" "<<hashArray[(int)upperCase]<<endl;
        } 
        for (int i = 0; i <= N; i++)
        {            
            if(hashArray[i] != 0)
            {
               // cout<<hashArray[i]<<" "<<i<<endl;
                if (hashArray[i] >= 2){
                    flag = 1;  
                    break;                  
                }                
            }
        }

        if (flag == 0)
            cout << "No\n";
        else
            cout << "Yes\n";
        
    }
}

int main()
{    
    findDoubleString();
    return 0;
}