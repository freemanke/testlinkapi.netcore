namespace TestLinkApi
{
    /// <summary>
    /// used for creating test cases to tell Testlink what to do 
    /// if another test case is found with the same name
    /// </summary>
    public enum ActionOnDuplicatedName
    {
        Block,
        GenerateNew,
        CreateNewVersion
    }
}