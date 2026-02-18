using System;

namespace bsc_sc_rpn
{
    internal class ArrayStack<T> : IStack<T>
    {
        private readonly T[] _items;
        private int _top;
        private readonly int _capacity;

        public ArrayStack(int capacity)
        {
            _capacity = capacity;
            _items = new T[_capacity];
            _top = -1; // start with an empty stack represented by -1
        }

        // Pushes an item onto the top of the stack.
        public void Push(T item)
        {
            if (_top >= _capacity - 1)
                throw new StackOverflowException("Stack is full. Cannot push new item.");

            _items[++_top] = item; // Increment top and add item to stack, increment first to avoid writing to index -1 which is invalid. 
        }

        // Removes and returns the item at the top of the stack.
        public T Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack is empty. Cannot pop item.");

            T item = _items[_top];
            _items[_top--] = default; // Use default to clear value.
            return item;
        }

        public T Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack is empty. Cannot peek item.");
            return _items[_top];
        }

        public bool IsEmpty() => _top == -1;
    }
}
