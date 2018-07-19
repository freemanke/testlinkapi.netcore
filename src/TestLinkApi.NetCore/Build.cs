namespace TestLinkApi
{
    /// <summary>
    ///  Build information returned by Testlink
    /// </summary>
    public class Build
    {
        /// <summary>
        ///  true if the build is active
        /// </summary>
        public bool active;

        /// <summary>
        ///  build ID
        /// </summary>
        public int id;

        /// <summary>
        ///  true if the build is currently open
        /// </summary>
        public bool is_open;

        /// <summary>
        ///  build name
        /// </summary>
        public string name;

        /// <summary>
        ///  any build notes
        /// </summary>
        public string notes;

        /// <summary>
        ///  the test plan the build is associated with
        /// </summary>
        public int testplan_id;
    }
}