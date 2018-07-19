namespace TestLinkApi
{
    /// <summary>
    /// represent a test plan
    /// </summary>
    public class TestPlan
    {
        /// <summary>
        /// True if the plan is currently active
        /// </summary>
        public bool active { get; set; }

        /// <summary>
        /// primary key
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool is_public { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string notes { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool open { get; set; }

        /// <summary>
        /// foreign key to test project
        /// </summary>
        public int testproject_id { get; set; }
    }
}