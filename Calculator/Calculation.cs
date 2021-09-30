using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculator
{
    public class Calculation
    {
        private readonly Stack<Token> _operatorsStack = new();
        private readonly Stack<double> _numsStack = new();
        private readonly List<Token> _tokensList;

        public Calculation(string str)
        {
            _tokensList = Token.StringToTokenList(str);

            foreach (var token in _tokensList)
            {
                Console.WriteLine(token._value);
            }

            Console.WriteLine();
        }

        public double Calculate()
        {
            foreach (var token in _tokensList)
            {
                Console.WriteLine("token._value ={0}({1})", token._value, token._type);
                if (token._type == TokenType.Number)
                {
                    _numsStack.Push(token._value);
                }
                else
                {
                    if (_operatorsStack.TryPeek(out var lastOperation) && token._value <= lastOperation._value)
                    {
                        ExecuteOperation();
                    }

                    _operatorsStack.Push(token);
                }
            }

            while (_operatorsStack.Any())
            {
                ExecuteOperation();
            }

            return _numsStack.Peek();
        }

        private void ExecuteOperation()
        {
            switch (_operatorsStack.Pop()._type)
            {
                case TokenType.Plus:
                    _numsStack.Push(_numsStack.Pop() + _numsStack.Pop());
                    break;
                case TokenType.Minus:
                    _numsStack.Push(-_numsStack.Pop() + _numsStack.Pop());
                    break;
                case TokenType.Ast:
                    _numsStack.Push(_numsStack.Pop() * _numsStack.Pop());
                    break;
                case TokenType.Slash:
                    _numsStack.Push(1 / _numsStack.Pop() * _numsStack.Pop());
                    break;
                case TokenType.Cap:
                    var arg2 = _numsStack.Pop();
                    var arg1 = _numsStack.Pop();
                    _numsStack.Push(Math.Pow(arg1, arg2));
                    break;
                case TokenType.RBracket:
                    while (_operatorsStack.Peek()._type != TokenType.LBracket)
                    {
                        ExecuteOperation();
                    }

                    _operatorsStack.Pop();
                    break;
            }
        }
    }
}