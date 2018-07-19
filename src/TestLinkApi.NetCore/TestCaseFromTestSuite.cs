using System;

namespace TestLinkApi
{
    /// <summary>
    /// test case as it is retrieved from testsuite
    /// </summary>
    public class TestCaseFromTestSuite
    {
        public bool active;
        public int author_id;
        public DateTime creation_ts;
        public string details;

        /// <summary>
        /// manual or automatic
        /// </summary>
        public int execution_type;

        /// <summary>
        /// the id that is displayed on the UI, sans the prefix
        /// </summary>
        public string external_id;

        /// <summary>
        /// test case id
        /// </summary>
        public int id;

        public int importance;

        /// <summary>
        /// unknown purpose
        /// </summary>
        public bool is_open;

        /// <summary>
        /// not clear what this represents
        /// </summary>
        public string layout;

        /// <summary>
        /// 
        /// </summary>
        public DateTime modification_ts;

        public string name;
        public int node_order;
        public string node_table;
        public int node_type_id;

        public int parent_id;
        public string preconditions;

        /// <summary>
        /// not clear in its meaning
        /// </summary>
        public int status;

        public string summary;

        /// <summary>
        /// the internal id of this testcase version
        /// </summary>
        public int tcversion_id;

        /// <summary>
        /// the id of the owning testsuite
        /// </summary>
        public int testSuite_id;

        /// <summary>
        /// 
        /// </summary>
        public int updater_id;

        /// <summary>
        /// the version of the test case, starts with 1
        /// </summary>
        public int version;
    }
}