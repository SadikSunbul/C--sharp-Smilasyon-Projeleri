﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTopluKuyrukYapısı
{
    public class MyStack<T>
    {
        private readonly IStack<T> stack;
        public int count => stack.Count;
        public MyStack(StackType type = StackType.Array)
        {
            if (type == StackType.Array)
            {
                stack = new ArrayStack<T>();
            }
            else
            {
                stack = new LinkedListStack<T>();
            }
        }

        public T Pop()
        {
            return stack.Pop();
        }
        public T Peek()
        {
            return stack.Peek();
        }
        public void Push(T value)
        {
           stack.Push(value);
        }
    }

    public interface IStack<T>
    {
        int Count { get; }
        void Push(T item);
        T Peek();
        T Pop();
    }
    public enum StackType
    {
        Array = 0,    //List<T>
        LinkedList = 1  //SinglyLinkedKist<T>
    }

}
