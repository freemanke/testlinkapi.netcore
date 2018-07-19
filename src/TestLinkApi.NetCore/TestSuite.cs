namespace TestLinkApi
{
    /// <summary>
    ///  represent a folder in the test specification tree
    /// </summary>
    public class TestSuite
    {
        /// <summary>
        ///  internal primary key
        /// </summary>
        public int id;

        /// <summary>
        ///  name of test suite
        /// </summary>
        public string name;

        /// <summary>
        ///  sequence id for ordering folders in tree
        /// </summary>
        public int nodeOrder;

        /// <summary>
        ///  internal value
        /// </summary>
        public int nodeTypeId;

        /// <summary>
        ///  foreign key to parent
        /// </summary>
        public int parentId;
    }
}