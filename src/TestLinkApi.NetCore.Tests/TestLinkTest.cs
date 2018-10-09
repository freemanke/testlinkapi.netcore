using System;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace TestLinkApi.NetCore.Tests
{
    public class TestLinkTest
    {
        private const string apiKey = "81d3ea057c7e10938754661577f4b2aa";
        private const string testlinkUrl = "https://dev.testlink.tp.cmit.local/lib/api/xmlrpc/v1/xmlrpc.php";
        private TestLink testlink = new TestLink(apiKey, testlinkUrl);
        private ITestOutputHelper _testOutputHelper;

        public TestLinkTest(ITestOutputHelper helper)
        {
            _testOutputHelper = helper;
        }

        [Fact]
        public void SayHelloTest()
        {
            Assert.NotNull(testlink.SayHello());
            Console.WriteLine(testlink.SayHello());
        }

        [Fact]
        public void GetObjects()
        {
            Console.WriteLine(testlink.about());

            var projects = testlink.GetProjects();
            projects.ForEach(a => Console.WriteLine($"Project: {a.id}, {a.name}"));

            var project = projects.First(a => a.name == "CMGE");
            var testPlans = testlink.GetProjectTestPlans(project.id);
            testPlans.ForEach(a => Console.WriteLine($"Test Plans: {a.id}, {a.name}"));

            var testSuites = testlink.GetFirstLevelTestSuitesForTestProject(project.id);
            testSuites.ForEach(a => Console.WriteLine($"Test Suites: {a.id}, {a.name}"));

            var testSuite = testSuites.First();
            var testCases = testlink.GetTestCasesForTestSuite(testSuite.id, false);
            testCases.ForEach(a => Console.WriteLine($"Test Cases: {a.id}, {a.name}"));

            var testCase = testlink.GetTestCase(4510, 1);
            Console.WriteLine($"Test Case: {testCase.id}, {testCase.name}");
        }

        [Fact]
        public void GetTestCasesForTestPlanTest()
        {
            _testOutputHelper.WriteLine(testlink.about());

            var project = testlink.GetProjects().First(a => a.name == "CMGE");
            var testPlan = testlink.GetProjectTestPlans(project.id).First(a => a.name == "integration-test-plan");
            _testOutputHelper.WriteLine($"test plan id: {testPlan.id}");

            var platforms = testlink.GetTestPlanPlatforms(testPlan.id);
            _testOutputHelper.WriteLine($"\r\n{testPlan.name} includes platforms:");
            platforms.ForEach(a => _testOutputHelper.WriteLine($"{a.name} (id: {a.id})"));

            var builds = testlink.GetBuildsForTestPlan(testPlan.id);
            _testOutputHelper.WriteLine($"\r\n{testPlan.name} includes builds:");
            builds.ForEach(a => _testOutputHelper.WriteLine($"{a.name} (id: {a.id})"));

            var cases = testlink.GetTestCasesForTestPlan(testPlan.id);
            var testCases = cases.GroupBy(a => a.external_id).Select(g => g.First()).ToList();
            _testOutputHelper.WriteLine($"\r\n{testPlan.name} includes test cases: {testCases.Count}");
            testCases.ForEach(a=> _testOutputHelper.WriteLine($"ID:{a.tc_id} ExternalID:{a.external_id} {a.name} {a.tester_id}"));

            var platformTestCases = testCases.GroupBy(a => a.platform_name);
            _testOutputHelper.WriteLine("\r\nGroups:");
            var counter = 0;
            foreach (var group in platformTestCases)
            {
                counter += group.ToArray().Length;
                _testOutputHelper.WriteLine($"Platform: {group.Key} Test cases: {group.ToArray().Length}");
            }

            _testOutputHelper.WriteLine($"All platform total test cases: {counter}");
        }

        [Fact]
        public void GetTestCasesForTestPlanOfMeTest()
        {
            Console.WriteLine(testlink.about());

            var project = testlink.GetProjects().First(a => a.name == "CMGE");
            var testPlan = testlink.GetProjectTestPlans(project.id).First(a => a.name == "V0-H.1020");

            var platforms = testlink.GetTestPlanPlatforms(testPlan.id);
            Console.WriteLine($"\r\n{testPlan.name} includes platforms:");
            platforms.ForEach(a => Console.WriteLine($"{a.name} (id: {a.id})"));

            var builds = testlink.GetBuildsForTestPlan(testPlan.id);
            Console.WriteLine($"\r\n{testPlan.name} includes builds:");
            builds.ForEach(a => Console.WriteLine($"{a.name} (id: {a.id})"));

            var cases = testlink.GetTestCasesForTestPlan(testPlan.id,0,builds[0].id,0,false,0);
            var testCases = cases.GroupBy(a => a.external_id).Select(g => g.First()).ToList();
            Console.WriteLine($"\r\n{testPlan.name} includes test cases: {testCases.Count}");

            var platformTestCases = testCases.GroupBy(a => a.platform_name);
            Console.WriteLine("\r\nGroups:");
            var counter = 0;
            foreach (var group in platformTestCases)
            {
                counter += group.ToArray().Length;
                Console.WriteLine($"Platform: {group.Key} Test cases: {group.ToArray().Length}");
            }

            Console.WriteLine($"All platform total test cases: {counter}");
        }

        [Fact]
        public void DoesUserExistTest()
        {
            Assert.True(testlink.DoesUserExist("user"));
        }

        [Fact]
        public void GetCustomField()
        {
            var project = testlink.GetProject("CMGE");
            var firtRootTestSuite = testlink.GetFirstLevelTestSuitesForTestProject(project.id).First();
            var testSuites = testlink.GetTestSuitesForTestSuite(firtRootTestSuite.id);
            testSuites.ForEach(ts =>
            {
                Console.WriteLine($"Test Suite: {ts.id}, {ts.name}");
                var testCases = testlink.GetTestCasesForTestSuite(ts.id, false);
                testCases.ForEach(tc =>
                {
                    var testCase = testlink.GetTestCase(tc.id);
                    var product = testlink.GetCustomFileds(testCase.testcase_id, testCase.externalid, testCase.version, project.id, "Product");
                    var ef = testlink.GetCustomFileds(testCase.testcase_id, testCase.externalid, testCase.version, project.id, "ExecutionFramework");
                    Console.WriteLine($"Test Case: {tc.id}, {tc.name}, Product: {product}, ExecutionFramework: {ef}");
                });
            });
        }

        [Fact]
        public void ReportTCResultTest()
        {
            var testPlan = testlink.getTestPlanByName("CMGE", "dev-nunit-test-plan");
            var testCases = testlink.GetTestCasesForTestPlan(testPlan.id);
            var testCase = testCases.Last();

            testlink.ReportTCResult(testCase.tc_id, testPlan.id, TestCaseStatus.Failed, testCase.platform_id, testCase.platform_name, true, true, "notes");
            var result = testlink.GetLastExecutionResult(testPlan.id, testCase.tc_id);
            Assert.Equal("f", result.status);

            testlink.ReportTCResult(testCase.tc_id, testPlan.id, TestCaseStatus.Passed, testCase.platform_id, testCase.platform_name, true, true, "notes");
            result = testlink.GetLastExecutionResult(testPlan.id, testCase.tc_id);
            Assert.Equal("p", result.status);
        }

        [Fact]
        public void CreateTestCase()
        {
            var project = testlink.GetProject("CMGE");
            var testSuites = testlink.GetFirstLevelTestSuitesForTestProject(project.id);
            testSuites.ForEach(a => Console.WriteLine($"Test Suites: {a.id}, {a.name}"));

            var testSuite = testSuites.First();
            var created = testlink.CreateTestCase("user", testSuite.id, "新创建的测试用例", project.id, "summary",
                new[] {new TestStep(1, "<p>click(<img alt=\"\" src=\"http://dev-wiki-1.cmit.local/resources/assets/cmgos.png \" style=\"height:71px; width:139px\" />)</p>", "find", true, 2)},
                "", 1, false, ActionOnDuplicatedName.CreateNewVersion, 0, 0);

            Console.WriteLine($"{created.id}, {created.additionalInfo.has_duplicate}, {created.status}, {created.message}, {created.operation}");
            var testCases = testlink.GetTestCaseIDByName("新创建的测试用例");
            Assert.NotEmpty(testCases);
        }
    }
}