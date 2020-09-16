using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Application.Domains
{
    public class Image
    {
        public string Small { get; set; }
        public string Medium { get; set; }
        public string Big { get; set; }

    }
    public class DocumentModel
    {
        public string Reference { get; set; }
        public string Preview { get; set; }
    }

    public class DocumentInfo
    {
        public string Name { get; set; }
        public int Size { get; set; }
        public string Type { get; set; }
    } 
}
