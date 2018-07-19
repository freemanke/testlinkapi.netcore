namespace TestLinkApi
{
    /// <summary>
    /// Additional Info is provided in some cases when objects are created.
    /// <see cref="GeneralResult"/>
    /// </summary>
    public class AdditionalInfo
    {
        /// <summary>
        /// external id if used
        /// </summary>
        public int external_id; //	"5"	

        /// <summary>
        /// true if a duplicate exists
        /// </summary>
        public bool? has_duplicate;

        /// <summary>
        /// internal id
        /// </summary>
        public int id; //	1313	

        /// <summary>
        /// extra message, e.g."Created new version 2"	
        /// </summary>
        public string msg;

        /// <summary>
        /// new namee given
        /// </summary>
        public string new_name;

        /// <summary>
        /// true means good
        /// </summary>
        public bool status_ok;

        /// <summary>
        /// version number in test cases
        /// </summary>
        public int version_number; //	
    }
}