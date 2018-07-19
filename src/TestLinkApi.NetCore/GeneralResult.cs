namespace TestLinkApi
{
    /// <summary>
    ///  returned when creating new TestProjects, TestCases, projects etc
    /// </summary>
    public class GeneralResult : TestLinkData
    {
        /// <summary>
        ///  Any potential additional information
        /// </summary>
        public AdditionalInfo additionalInfo;

        /// <summary>
        ///  id of an object involved in the operation. e.g. test case id
        /// </summary>
        public int id;

        /// <summary>
        ///  the message returned by Testlink
        /// </summary>
        public string message;

        /// <summary>
        ///  the name of the operation carried out
        /// </summary>
        public string operation;

        /// <summary>
        ///  a status. True means good
        /// </summary>
        public bool status;

        /// <summary>
        ///  used by the Exporter class
        /// </summary>
        /// <param name="message"></param>
        /// <param name="status"></param>
        public GeneralResult(string message, bool status)
        {
            this.message = message;
            this.status = status;
        }

        /// <summary>
        ///  conbstructor used to represent an empty response
        /// </summary>
        public GeneralResult()
        {
            status = false;
            message = "no response from server";
        }
    }
}