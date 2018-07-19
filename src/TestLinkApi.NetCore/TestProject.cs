using System.Collections.Generic;

namespace TestLinkApi
{
    /// <summary>
    /// represent a test project object in testlink
    /// </summary>
    public class TestProject
    {
        /// <summary>
        /// 
        /// </summary>
        public bool active;

        /// <summary>
        /// 
        /// </summary>
        public string color;

        /// <summary>
        /// internal id
        /// </summary>
        public int id;

        /// <summary>
        /// project name
        /// </summary>
        public string name;

        /// <summary>
        /// notes
        /// </summary>
        public string notes;

        /// <summary>
        /// true if automation is enabled
        /// </summary>
        public bool option_automation;

        /// <summary>
        /// true of inventory is enabled
        /// </summary>
        public bool option_inventory;

        /// <summary>
        /// true if priority feature is enabled
        /// </summary>
        public bool option_priority;

        /// <summary>
        /// true of requirements feature is enabled
        /// </summary>
        public bool option_reqs;

        /// <summary>
        /// string prefix for test cases
        /// </summary>
        public string prefix;

        /// <summary>
        /// 
        /// </summary>
        public int tc_counter;


        public List<TestSuite> TestSuites { get; set; } = new List<TestSuite>();
    }
}