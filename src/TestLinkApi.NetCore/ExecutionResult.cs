using System;

namespace TestLinkApi
{
    /// <summary>
    ///  Represent the recorded outcome of a test case execution.
    /// </summary>
    public class ExecutionResult
    {
        /// <summary>
        ///  id of the build this was run against
        /// </summary>
        public int build_id;

        /// <summary>
        ///  timestamp of execution
        /// </summary>
        public DateTime execution_ts;

        /// <summary>
        ///  execution type, 1=manual, 2=automatic
        /// </summary>
        public int execution_type;

        /// <summary>
        ///  internal id
        /// </summary>
        public int id;

        /// <summary>
        ///  notes provided
        /// </summary>
        public string notes;

        /// <summary>
        ///  status, p=pass, f=fail, b=blocked
        /// </summary>
        public string status;

        /// <summary>
        ///  version id of test case
        /// </summary>
        public int tcversion_id;

        /// <summary>
        ///  external version number
        /// </summary>
        public int tcversion_number;

        /// <summary>
        ///  id of tester
        /// </summary>
        public int tester_id;

        /// <summary>
        ///  id of testplan
        /// </summary>
        public int testplan_id;
    }
}