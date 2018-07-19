using System;
using System.Collections.Generic;

namespace TestLinkApi
{
    /// <summary>
    /// test cases as they are returned from the getTestCase API call
    /// </summary>
    /// <remarks>This is different from other calls that return TestCases </remarks>
    public class TestCase
    {
        public bool active { get; set; }
        public string author_first_name { get; set; }
        public int author_id { get; set; }
        public string author_last_name { get; set; }
        public string author_login { get; set; }
        public DateTime creation_ts { get; set; }
        public int execution_type { get; set; }
        public string externalid { get; set; }
        public int id { get; set; }
        public int importance { get; set; }
        public bool is_open { get; set; }
        public string layout { get; set; }
        public DateTime modification_ts { get; set; }
        public string name { get; set; }
        public int node_order { get; set; }
        public string preconditions { get; set; }
        public int status { get; set; }
        public List<TestStep> steps { get; set; }
        public string summary { get; set; }
        public int testcase_id { get; set; }
        public int testsuite_id { get; set; }
        public string updater_first_name { get; set; }
        public int updater_id { get; set; }
        public string updater_last_name { get; set; }
        public string updater_login { get; set; }
        public int version { get; set; }
    }
}