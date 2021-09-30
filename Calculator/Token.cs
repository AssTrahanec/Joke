using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculator
{
    public class Token
    {
        public char _type { get; set; }
        public double _value { get; set; }
        
        public static List<Token> StringToTokenList(string str)
        {
            str = str.Replace(" ", "");
            str = str.Replace(".", ",");
            var tokenList = new List<Token>();
            
            for (var i = 0; i < str.Length; i++)
            {
                var token = new Token();
                var k = 0;
                switch (str[i])
                {
                    case '+':
                        token._type = '+';
                        token._value = 1;
                        tokenList.Add(token);
                        break;
                    case '-':
                        token._type = '-';
                        token._value = 1;
                        tokenList.Add(token);
                        break;
                    case '*':
                        token._type = '*';
                        token._value = 2;
                        tokenList.Add(token);
                        break;
                    case '/':
                        token._type = '/';
                        token._value = 2;
                        tokenList.Add(token);
                        break;
                    case '^':
                        token._type = '^';
                        token._value = 3;
                        tokenList.Add(token);
                        break;
                    case '(':
                        token._type = '(';
                        token._value = 0;
                        tokenList.Add(token);
                        break;
                    case ')':
                        token._type = ')';
                        token._value = 0;
                        tokenList.Add(token);
                        break;
                    default:
                        while (i + k < str.Length)
                        {
                            try
                            {
                                if (i == 0 && k == 0)
                                    k++;
                                else
                                {
                                    k++;
                                    Convert.ToDouble(str.Substring(i, k));
                                }
                            }
                            catch
                            {
                                token._type = '0';
                                token._value = Convert.ToDouble(str.Substring(i, k - 1));
                                tokenList.Add(token);
                                i = i + k - 2;
                                break;
                            }
                        }
                        
                        break;
                }

                if (i + k != str.Length) continue;
                token._type = '0';
                token._value = Convert.ToDouble(str.Substring(i, k));
                            
                tokenList.Add(token);
                break;
            }
            
            return tokenList;
        }
        // public static Stack<Token> MakeStackOfNumTokens(List<Token> listOfTokens)
        // {
        //     var stack = new Stack<Token>();
        //     foreach (var token in listOfTokens.Where(token => token._type == '0'))
        //     {
        //         stack.Push(token);
        //     }
        //     return stack;
        // }
        // public static Stack<Token> MakeStackOfOperatorTokens(List<Token> listOfTokens)
        // {
        //     var stack = new Stack<Token>();
        //     foreach (var token in listOfTokens.Where(token => token._type != '0'))
        //     {
        //         stack.Push(token);
        //     }
        //     return stack;
        // }
    }
}
