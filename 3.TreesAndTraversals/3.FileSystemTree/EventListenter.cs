using System;
using System.Linq;

namespace FileSystemTree
{    

    public class EventListenter
    {
        private readonly Folder folderWithEvents;

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