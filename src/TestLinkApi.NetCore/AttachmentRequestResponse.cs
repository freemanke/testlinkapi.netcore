namespace TestLinkApi
{
    /// <summary>
    /// this is returned as a response to an attachment request
    /// </summary>
    public class AttachmentRequestResponse
    {
        /// <summary>
        /// description 
        /// </summary>
        public string description;

        /// <summary>
        /// filename 
        /// </summary>
        public string file_name;

        /// <summary>
        /// mime type
        /// </summary>
        public string file_type;

        /// <summary>
        /// the foreign key
        /// </summary>
        public int foreignKeyId;

        /// <summary>
        /// the name of the table containing hte event this is attached to (an execution for instance)
        /// </summary>
        public string linkedTableName;

        /// <summary>
        /// size in bytes
        /// </summary>
        public int size;

        /// <summary>
        /// title of the attachment
        /// </summary>
        public string title;
    }
}