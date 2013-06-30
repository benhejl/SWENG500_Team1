using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManagerLibrary.Models
{
    public class IssueAttachment
    {
        /// <summary>
        /// Issue Attachment ID
        /// </summary>
        public int IssueAttachmentID { get; set; }

        /// <summary>
        /// file name
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Entry Date
        /// </summary>
        public DateTime EntryDate { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// User ID
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// Issue ID
        /// </summary>
        public int IssueID { get; set; }

        /// <summary>
        /// Content Mime Type
        /// </summary>
        public string MimeType { get; set; }

        /// <summary>
        /// byte[] of data
        /// </summary>
        public byte[] FileData { get; set; }


    }
}
