namespace TestLinkApi
{
    /// <summary>
    /// view of test case identifiers returned by the api call GetTestCaseIdByName
    /// </summary>
    public class TestCaseId
    {
        /// <summary>
        /// test case internal id
        /// </summary>
        public int id;

        /// <summary>
        /// 
        /// </summary>
        public string name;

        /// <summary>
        /// that would be the id of the owning item in the nodes hierarchy table (i.e. the folder id)
        /// </summary>
        public int parent_id;

        /// <summary>
        /// the externally visible id without the prefix
        /// </summary>
        public int tc_external_id;

        /// <summary>
        /// name of the test suite that contains the test case
        /// </summary>
        public string tsuite_name;
    }
}