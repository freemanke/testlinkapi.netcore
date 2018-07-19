namespace TestLinkApi
{
    /// <summary>
    ///  represent a single test step in a test case
    /// </summary>
    public class TestStep
    {
        /// <summary>
        ///  string describing the actions
        /// </summary>
        public string actions;

        /// <summary>
        ///  flag whether this step is active
        /// </summary>
        public bool active;

        /// <summary>
        ///  1=manual or 2=automated
        /// </summary>
        public int execution_type;

        /// <summary>
        ///  string desribing the expected result in this step
        /// </summary>
        public string expected_results;

        /// <summary>
        ///  interenal primary key.
        /// </summary>
        public int id;

        /// <summary>
        ///  step number. Starts at 1
        /// </summary>
        public int step_number;

        public TestStep()
        {
        }

        /// <summary>
        ///  constructor used when defining new steps when creating testcases
        /// </summary>
        /// <param name="stepNr">sequential id, start with 1</param>
        /// <param name="actions">formatted text, use html style text format tags</param>
        /// <param name="expectedResult">formatted text, use html style text format tags</param>
        /// <param name="isActive">set to true</param>
        /// <param name="executionType">1=manual, 2=automatic</param>
        public TestStep(int stepNr, string actions, string expectedResult, bool isActive, int executionType)
        {
            step_number = stepNr;
            this.actions = actions;
            expected_results = expectedResult;
            active = isActive;
            execution_type = executionType;
        }
    }
}