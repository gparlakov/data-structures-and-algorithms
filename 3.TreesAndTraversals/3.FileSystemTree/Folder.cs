﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace FileSystemTree
{
    public delegate void ProgressHandler(object sender, EventArgs e);

    public class Folder
    {
        private readonly List<Folder> folders;

        private readonly List<File> files;

        private string name;

        public Folder(string fullPath)
        {
            this.FullPath = fullPath;
            this.Name = fullPath;
            this.folders = new List<Folder>();
            this.files = new List<File>();
        }

        public event ProgressHandler AddedNewFolder;

        public string FullPath { get; private set; }
        
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
                string fileName = this.ExtractFolderNameFromFullPath(value);
                this.name = fileName;
            }
        }

        public void AddFile(File file)
        {
            this.files.Add(file);
        }

        public void AddFolder(Folder folder)
        {
            this.folders.Add(folder);
            this.OnChanged(EventArgs.Empty);
        }

        public File[] GetFiles()
        {
            var filesCopy = new File[this.files.Count];
            this.files.CopyTo(filesCopy);

            return filesCopy;
        }

        public Folder[] GetFolders()
        {
            var foldersCopy = new Folder[this.folders.Count];
            this.folders.CopyTo(foldersCopy);

            return foldersCopy;
        }

        public void OnChanged(EventArgs args)
        {
            if (this.AddedNewFolder != null)
            {
                this.AddedNewFolder(new Object(), args);
            }
        }

        private string ExtractFolderNameFromFullPath(string value)
        {
            string folderName = null;
            var slashIndex = value.LastIndexOf('\\');
            if (slashIndex < 0)
            {
                folderName = value;
            }
            else
            {
                folderName = value.Substring(slashIndex + 1);
            }

            return folderName;
        }
    }
}