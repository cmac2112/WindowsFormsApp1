using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Folder
    {
        public string Name { get; set; }
        public List<Folder> SubFolder { get; set; }

        public Folder(string name)
        {
            Name = name;
            SubFolder = new List<Folder>();
        }
    }
}
