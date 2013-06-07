using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemTree
{
    public class EventListenter
    {
        private Folder folderWithEvents;
        public EventListenter(Folder folder)
        {            
            this.folderWithEvents = folder;           
            folder.AddedNewFolder += new ProgressHandler(FolderAdded);
        }

        private void FolderAdded(object sender, EventArgs e)
        {           
            Console.Write('.');           
        }
    }
}
