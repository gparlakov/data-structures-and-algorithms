using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private string ExtractFileNameFromFullPath(string value)
        {
            string fileName = null;
            var slashIndex = value.LastIndexOf('\\');
            if (slashIndex < 0)
            {
                fileName = value;
            }
            else
            {
                fileName = value.Substring(slashIndex + 1);
            }

            return fileName;
        }
        
    }
}
