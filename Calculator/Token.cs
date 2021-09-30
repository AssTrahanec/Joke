using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using Microsoft.VisualBasic;

enum TokenType
{
    Plus = '+',
    Number,
    Minus = '-',
    Ast = '*',
    Slash = '/',
    Cap = '^',
    LBracket = '(',
    RBracket = ')'
}

namespace Calculator
{
    internal class Token
    {
        public TokenType _type { get; set; }
        public double _value { get; set; }

        public Token(TokenType type, double value)
        {
            this._type = type;
            this._value = value;
        }
        
        public static List<Token> StringToTokenList(string str)
        {
            str = str.Replace(" ", "");
            var tokenList = new List<Token>();

            for (var i = 0; i < str.Length; i++)
            {
               switch (str[i])
                {
                    case '+':
                        tokenList.Add(new Token(TokenType.Plus, 1));
                        break;
                    case '-':
                        tokenList.Add(new Token(TokenType.Minus, 1));
                        break;
                    case '*':
                        tokenList.Add( new Token(TokenType.Ast, 2));
                        break;
                    case '/':
                        tokenList.Add( new Token(TokenType.Slash, 2));
                        break;
                    case '^':
                        tokenList.Add(new Token(TokenType.Cap, 3));
                        break;
                    case '(':
                        tokenList.Add( new Token(TokenType.LBracket, -(i + 1)));
                        break;
                    case ')':
                        tokenList.Add(new Token(TokenType.RBracket, 0));
                        break;
                    default:
                        var k = 0;
                        while (i + k < str.Length && "1234567890.".Contains(str[i + k]))
                        {
                            k++;
                        }

                        tokenList.Add(new Token(TokenType.Number, double.Parse(str.Substring(i, k), CultureInfo.InvariantCulture)));

                        i += k - 1;
                        
                        break;
                }
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
