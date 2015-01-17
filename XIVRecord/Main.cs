using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XIVRecord
{
    public class Main
    {
        public ArchiveDir Archive { get; private set; }
        public string ArchivePath
        {
            get
            {
                return this.Archive != null 
                    ? this.Archive.Dir.FullName 
                    : null;
            }
            set
            {
                this.Archive = new ArchiveDir(new System.IO.DirectoryInfo(value));
            }
        }

        public Main()
        {
            this.Archive = ArchiveDir.TryReadFromRegistry();
        }
    }
}
