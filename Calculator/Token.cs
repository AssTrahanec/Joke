using System.Collections.Generic;
using System.Globalization;

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
                        tokenList.Add(new Token(TokenType.Ast, 2));
                        break;
                    case '/':
                        tokenList.Add(new Token(TokenType.Slash, 2));
                        break;
                    case '^':
                        tokenList.Add(new Token(TokenType.Cap, 3));
                        break;
                    case '(':
                        if (str[i + 1] == '-') // if "-" is unary operator
                        {
                            var t = 0;
                            while (str[i + t] != ')')
                            {
                                t++;
                            }

                            tokenList.Add(new Token(TokenType.Number,
                                double.Parse(str.Substring(i + 1, t - 1), CultureInfo.InvariantCulture)));

                            i += t;
                        }
                        else // if "-" is binary
                        {
                            tokenList.Add(new Token(TokenType.LBracket, 0));
                        }

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

                        tokenList.Add(new Token(TokenType.Number,
                            double.Parse(str.Substring(i, k), CultureInfo.InvariantCulture)));

                        i += k - 1;

                        break;
                }
            }

            return tokenList;
        }
    }
}