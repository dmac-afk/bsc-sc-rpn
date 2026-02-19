using System;

namespace bsc_sc_rpn
{
	internal class LinkedListStack<T> : IStack<T>
	{
		private class Node
		{
			public T Value;
			public Node Next;

			public Node(T value, Node next = null)
			{
				Value = value;
				Next = next;
			}
		}

		private Node _top;
		private int _count;

		public LinkedListStack()
		{
			_top = null;
			_count = 0;
		}

		public void Push(T item)
		{
			_top = new Node(item, _top);
			_count++;
		}

		public T Pop()
		{
			if (IsEmpty())
				throw new InvalidOperationException("Stack is empty.");

			T value = _top.Value;
			_top = _top.Next;
			_count--;
			return value;
		}

		public T Peek()
		{
			if (IsEmpty())
				throw new InvalidOperationException("Stack is empty.");

			return _top.Value;
		}

		public bool IsEmpty() => _count == 0;
	}
}
