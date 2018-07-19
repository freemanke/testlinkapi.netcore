using System.Collections.Generic;

namespace TestLinkApi
{
    /// <summary>
    /// summary results for the execution of a testplan.
    /// 
    /// </summary>
    public class TestPlanTotal
    {
        /// <summary>
        /// Dictionary with execution totals
        /// </summary>
        public Dictionary<string, int> Details = new Dictionary<string, int>();

        /// <summary>
        /// category value
        /// </summary>
        public string Name = "";

        /// <summary>
        /// total test cases that are covered in this test plan
        /// </summary>
        public int Total_tc;

        /// <summary>
        /// category name
        /// </summary>
        public string Type = "";
    }
}