using System;

namespace TestLinkApi
{
    /// <summary>
    /// The object returned from Testlinkt when requesting an attachment
    /// </summary>
    public class Attachment
    {
        public byte[] content;
        public DateTime date_added;
        public string file_type;
        public int id;
        public string name;
        public string title;
    }
}