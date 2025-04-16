using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISD4
{
	public class StackCastom
	{
		private int size;
		private char[] _a;
		private int last; //lastIndex

		public StackCastom(int size)
		{
			last = -1;
			this.size = size;
			_a = new char[size];
		}

		public bool Add(char x)
		{
			if (!IsFull())
			{
				_a[++last] = x;
				return true;
			}
			return false;
		}

		public char Delete()
		{
			if (!IsEmpty())
			{
				return _a[last--];
			}
			return '!';
		}

		public bool IsEmpty()
		{
			return last == -1;
		}

		public bool IsFull()
		{
			return last == size - 1;
		}
	}
}