using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListImplementation
{
    public class ListItem<T>
    {
        private T value;
        private ListItem<T> nextItem;

	    public T Value
	    {
		    get { return value;}
		    set { this.value = value;}
	    }

        public ListItem<T> NextItem
        {
            get { return nextItem; }
            set { this.nextItem = value; }
        }

        internal ListItem(T value, ListItem<T> nextElement)
        {
            this.Value = value;
            this.NextItem = nextElement;
        }
    }
}
