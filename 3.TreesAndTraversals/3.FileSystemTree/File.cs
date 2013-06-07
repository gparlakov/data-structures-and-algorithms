using System;
using System.Linq;

namespace FileSystemTree
{
    public class File
    {
        private string name;

        public File(string name, int size)
        {
            this.Name = name;
            this.Size = size;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("File name can't be null.");
                }
                if (value.IndexOf('\\') > 0)
                {
                    throw new ArgumentException("File name can't hold a slash");
                }

                this.name = value;
            }
        }
        
        public int Size { get; private set; }
    }
}