using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SSWProject.Models
{
    public class AgentFile
    {
        [Key]
        public int FileID { get; set; }

        public string FileName { get; set; }

        public string ContentType { get; set; }

        public byte[] Content { get; set; }

        public FileType FileType { get; set; }

        public int AgentID { get; set; }

        public virtual Agent Agent { get; set; }

    }

    public class CustomerFile
    {
        [Key]
        public int FileID { get; set; }

        public string FileName { get; set; }

        public string ContentType { get; set; }

        public byte[] Content { get; set; }

        public FileType FileType { get; set; }

        public int CustomerID { get; set; }

        public virtual Customer Customer { get; set; }
    }

     public class ListingFile
    {
        [Key]
        public int FileID { get; set; }

        public string FileName { get; set; }

        public string ContentType { get; set; }

        public byte[] Content { get; set; }

        public FileType FileType { get; set; }

        public int ListingID { get; set; }

        public virtual Listing Listing { get; set; }
    }
}