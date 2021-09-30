using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculator
{
    public class Calculation
    {
        
        private readonly Stack<Token> _operatorsStack = new Stack<Token>();
        private readonly Stack<Token> _numsStack = new Stack<Token>();
        private readonly List<Token> _tokensList;
        
        public Calculation(string str)
        {
            _tokensList =Token.StringToTokenList(str);
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
                Console.WriteLine("token._value ={0}({1})",token._value,token._type);
                if (token._type == '0')
                {
                    _numsStack.Push(token);
                }
                else
                {
                    if (!_operatorsStack.Any())//stack is empty
                    {
                        _operatorsStack.Push(token);
                    }
                    else if(token._value > _operatorsStack.Peek()._value)//operation priority of token > top of stack
                    {
                        _operatorsStack.Push(token);
                    }
                    else if(token._value <= _operatorsStack.Peek()._value)//operation priority of token <= top of stack
                    {
                        ExecuteOperation();
                    }
                }
            }

            while (_operatorsStack.Any())
            {
                ExecuteOperation();
            }

            return _numsStack.Peek()._value;
        }

        private void ExecuteOperation()
        {
            var token = new Token();
            double result;
            var arg1 = _numsStack.Pop()._value;
            var arg2 = _numsStack.Pop()._value;
            switch (_operatorsStack.Pop()._type)
            {
                case '+':
                    result = arg1 + arg2;
                    token._type = '0';
                    token._value = result;
                    _numsStack.Push(token);
                    break;
                case '-':
                    result = arg1 - arg2;
                    token._type = '0';
                    token._value = result;
                    _numsStack.Push(token);
                    break;
                case '*':
                    result = arg1 * arg2;
                    token._type = '0';
                    token._value = result;
                    _numsStack.Push(token);
                    break;
                case '/':
                    if(arg1 == 0)
                        Console.WriteLine("Деление на 0");
                    else
                    {
                        result = arg2 / arg1;
                        token._type = '0';
                        token._value = result;
                        _numsStack.Push(token);
                    }
                    break;
                case '^':
                    result = Math.Pow(arg1,arg2);
                    token._type = '0';
                    token._value = result;
                    _numsStack.Push(token);
                    break;
                case ')':
                    while (_operatorsStack.Peek()._type != '(')
                        ExecuteOperation();
                    _operatorsStack.Pop();
                    break;
            }
        }
    }
}