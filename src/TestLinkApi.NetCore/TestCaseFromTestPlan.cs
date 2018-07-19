using System;

namespace TestLinkApi
{
    /// <summary>
    ///  test cases as they are returned from a test plan
    /// </summary>
    /// <remarks>
    ///  This is different from TestCase as it returns additional info from the testplan.
    ///  Maybe this should be refactored with a testplandetails subclass
    /// </remarks>
    public class TestCaseFromTestPlan
    {
        /// <summary>
        ///  marks the test case as active
        /// </summary>
        public bool active;

        /// <summary>
        ///  the build id the test case is assigned to
        /// </summary>
        public int assigned_build_id;

        public int assigner_id;
        public int exec_id;

        /// <summary>
        ///  build id where it was last executed on
        /// </summary>
        public int exec_on_build;

        /// <summary>
        ///  test plan id where it was last executed
        /// </summary>
        public int exec_on_tplan;

        /// <summary>
        ///  the last execution status
        /// </summary>
        public string exec_status;

        /// <summary>
        /// </summary>
        public int executed;

        public string execution_notes;
        public int execution_order;

        /// <summary>
        ///  actual execution type on last run 1=manual, 2 = automatic
        /// </summary>
        public string execution_run_type;

        /// <summary>
        ///  timestamp when it was executed. blank if not yet executeed
        /// </summary>
        public string execution_ts;

        /// <summary>
        ///  the execution type set in the test case  1=manual, 2 = automatic
        /// </summary>
        public int execution_type;

        /// <summary>
        ///  the id displayed on the UI, but without hte prefix
        /// </summary>
        public string external_id;

        public int feature_id;
        public int importance;
        public int linked_by;
        public DateTime linked_ts;
        public string name;
        public int platform_id;

        public string platform_name;

        /// <summary>
        ///  //the priority assigned in the test case(?)
        /// </summary>
        public int priority;

        /// <summary>
        ///  not clear what this is. It is NOT the same as the status in the other test case classes
        /// </summary>
        public string status;

        public string summary;
        public int tc_id;
        public int tcversion_id;

        /// <summary>
        /// </summary>
        public int tcversion_number;

        public int tester_id;
        public int testsuite_id;
        public string tsuite_name;
        public string type;

        /// <summary>
        ///  urgency set in test plan
        /// </summary>
        public int urgency;

        public int user_id;
        public int version;
        public int z;
    }
}