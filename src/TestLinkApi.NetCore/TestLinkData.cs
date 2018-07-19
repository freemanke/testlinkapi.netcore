using System;
using System.Collections.Generic;
using CookComputing.XmlRpc;

namespace TestLinkApi
{
    public abstract class TestLinkData
    {
        internal static TestLinkErrorMessage ToTestLinkErrorMessage(XmlRpcStruct data)
        {
            var item = new TestLinkErrorMessage();
            item.code = ToInt(data, "code");
            item.message = (string) data["message"];
            return item;
        }

        internal static TestCaseId ToTestCaseId(XmlRpcStruct data)
        {
            var item = new TestCaseId();
            item.parent_id = ToInt(data, "parent_id");
            item.tc_external_id = ToInt(data, "tc_external_id");
            item.id = ToInt(data, "id");
            item.name = (string) data["name"];
            item.tsuite_name = (string) data["tsuite_name"];

            return item;
        }

        internal static GeneralResult ToGeneralResult(XmlRpcStruct data)
        {
            var item = new GeneralResult();
            item.operation = (string) data["operation"];
            item.status = (bool) data["status"];
            item.id = ToInt(data, "id");
            item.message = (string) data["message"];
            if (data.ContainsKey("additionalInfo") &&
                data["additionalInfo"] is XmlRpcStruct)
                item.additionalInfo = ToAdditionalInfo(data["additionalInfo"] as XmlRpcStruct);
            else
                item.additionalInfo = null;

            return item;
        }


        /// <summary>
        ///  constructor used by XMLRPC interface on decoding the function return
        /// </summary>
        /// <param name="data">data returned by Testlink</param>
        internal static AttachmentRequestResponse ToAttachmentRequestResponse(XmlRpcStruct data)
        {
            var item = new AttachmentRequestResponse();
            item.foreignKeyId = ToInt(data, "fk_id");
            item.linkedTableName = (string) data["fk_table"];
            item.title = (string) data["title"];
            item.description = (string) data["description"];
            item.file_name = (string) data["file_name"];
            item.file_type = (string) data["file_type"];
            item.size = ToInt(data, "file_size");

            return item;
        }

        /// <summary>
        ///  constructor used by XMLRPC interface on decoding the function return
        /// </summary>
        /// <param name="data">data returned by Testlink</param>
        internal static AdditionalInfo ToAdditionalInfo(XmlRpcStruct data)
        {
            var item = new AdditionalInfo();
            item.new_name = (string) data["new_name"];
            item.status_ok = ToInt(data, "status_ok") == 1;
            item.msg = (string) data["msg"];
            item.id = ToInt(data, "id");
            item.external_id = ToInt(data, "external_id");
            item.version_number = ToInt(data, "version_number");
            item.has_duplicate = ToBool(data, "has_duplicate");

            return item;
        }

        internal static Attachment ToAttachment(XmlRpcStruct data)
        {
            var item = new Attachment();
            item.id = ToInt(data, "id");
            item.file_type = (string) data["file_type"];
            item.name = (string) data["name"];
            item.title = (string) data["title"];
            item.date_added = ToDate(data, "date_added");
            var s = (string) data["content"];
            item.content = Convert.FromBase64String(s);

            return item;
        }

        internal static Build ToBuild(XmlRpcStruct data)
        {
            var item = new Build();
            item.id = ToInt(data, "id");
            item.active = ToInt(data, "active") == 1;
            item.name = (string) data["name"];
            item.notes = (string) data["notes"];
            item.testplan_id = ToInt(data, "testplan_id");
            item.is_open = ToInt(data, "is_open") == 1;

            return item;
        }

        /// <summary>
        ///  constructor used by XMLRPC interface on decoding the function return
        /// </summary>
        /// <param name="data">data returned by Testlink</param>
        internal static ExecutionResult ToExecutionResult(XmlRpcStruct data)
        {
            var item = new ExecutionResult();
            item.id = ToInt(data, "id");
            item.notes = (string) data["notes"];
            item.execution_ts = ToDate(data, "execution_ts");
            item.execution_type = ToInt(data, "execution_type");
            item.build_id = ToInt(data, "build_id");
            item.tcversion_id = ToInt(data, "tcversion_id");
            item.tcversion_number = ToInt(data, "tcversion_number");
            item.status = (string) data["status"];

            return item;
        }

        /// <summary>
        ///  This is used for the call GetTestCasesForTestPlan
        ///  using the returned list from TestLink, generate a list of data
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<TestCaseFromTestPlan> GenerateFromResponse(XmlRpcStruct list)
        {
            var result = new List<TestCaseFromTestPlan>();
            if (list != null)
                foreach (var o in list.Values)
                {
                    TestCaseFromTestPlan tc = null;
                    if (o is XmlRpcStruct)
                    {
                        var list2 = o as XmlRpcStruct;
                        foreach (var o2 in list2.Values)
                        {
                            tc = ToTestCaseFromTestPlan(o2 as XmlRpcStruct);
                            result.Add(tc);
                        }
                    }
                    else
                    {
                        var olist = o as object[];
                        tc = ToTestCaseFromTestPlan(olist[0] as XmlRpcStruct);
                        result.Add(tc);
                    }
                }

            return result;
        }

        internal static TestCaseFromTestPlan ToTestCaseFromTestPlan(XmlRpcStruct data)
        {
            var item = new TestCaseFromTestPlan();
            if (data.ContainsKey("active")) item.active = int.Parse((string) data["active"]) == 1;
            item.name = (string) data["name"];
            item.tsuite_name = (string) data["tsuite_name"];
            item.z = ToInt(data, "z");
            item.type = (string) data["type"];
            item.execution_order = ToInt(data, "execution_order");
            item.exec_id = ToInt(data, "exec_id");
            item.tc_id = ToInt(data, "tc_id");
            item.tcversion_number = ToInt(data, "tcversion_number");
            item.status = (string) data["status"];
            item.external_id = (string) data["external_id"];
            item.exec_status = (string) data["exec_status"];
            item.exec_on_tplan = ToInt(data, "exec_on_tplan");
            item.executed = ToInt(data, "executed");
            item.feature_id = ToInt(data, "feature_id");
            item.assigner_id = ToInt(data, "assigner_id");
            item.user_id = ToInt(data, "user_id");
            item.active = ToInt(data, "active") == 1;
            item.version = ToInt(data, "version");
            item.testsuite_id = ToInt(data, "testsuite_id");
            item.tcversion_id = ToInt(data, "tcversion_id");
            //steps = (string)data["steps"];
            //expected_results = (string)data["expected_results"];
            item.summary = (string) data["summary"];
            item.execution_type = ToInt(data, "execution_type");
            item.platform_id = ToInt(data, "platform_id");
            item.platform_name = (string) data["platform_name"];
            item.linked_ts = ToDate(data, "linked_ts");
            item.linked_by = ToInt(data, "linked_by");
            item.importance = ToInt(data, "importance");
            item.execution_run_type = (string) data["execution_run_type"];
            item.execution_ts = (string) data["execution_ts"];
            item.tester_id = ToInt(data, "tester_id");
            item.execution_notes = (string) data["execution_notes"];
            item.exec_on_build = ToInt(data, "exec_on_build");
            item.assigned_build_id = ToInt(data, "assigned_build_id");
            item.urgency = ToInt(data, "urgency");
            item.priority = ToInt(data, "priority");

            return item;
        }

        internal static TestCaseFromTestSuite ToTestCaseFromTestSuite(XmlRpcStruct data)
        {
            var item = new TestCaseFromTestSuite();
            item.active = int.Parse((string) data["active"]) == 1;
            item.id = ToInt(data, "id");
            item.name = (string) data["name"];
            item.version = ToInt(data, "version");
            item.tcversion_id = ToInt(data, "tcversion_id");
            //steps = (string)data["steps"];
            //expected_results = (string)data["expected_results"];
            item.external_id = (string) data["tc_external_id"];
            item.testSuite_id = ToInt(data, "parent_id");
            item.is_open = int.Parse((string) data["is_open"]) == 1;
            item.modification_ts = ToDate(data, "modification_ts");
            item.updater_id = ToInt(data, "updater_id");
            item.execution_type = ToInt(data, "execution_type");
            item.summary = (string) data["summary"];
            if (data.ContainsKey("details"))
                item.details = (string) data["details"];
            else
                item.details = "";
            item.author_id = ToInt(data, "author_id");
            item.creation_ts = ToDate(data, "creation_ts");
            item.importance = ToInt(data, "importance");
            item.parent_id = ToInt(data, "parent_id");
            item.node_type_id = ToInt(data, "node_type_id");
            item.node_order = ToInt(data, "node_order");
            item.node_table = (string) data["node_table"];
            item.layout = (string) data["layout"];
            item.status = ToInt(data, "status");
            item.preconditions = (string) data["preconditions"];

            return item;
        }

        internal static TestPlanTotal ToTestPlanTotal(XmlRpcStruct data)
        {
            var item = new TestPlanTotal();
            item.Total_tc = ToInt(data, "total_tc");
            if (data.ContainsKey("type"))
                item.Type = (string) data["type"];
            if (data.ContainsKey("name"))
                item.Name = (string) data["name"];

            var xdetails = data["details"] as XmlRpcStruct;

            foreach (string key in xdetails.Keys)
            {
                var val = xdetails[key] as XmlRpcStruct;
                var qty = ToInt(val, "qty");
                item.Details.Add(key, qty);
            }

            return item;
        }

        /// <summary>
        /// </summary>
        /// <param name="data"></param>
        internal static TestPlatform ToTestPlatform(XmlRpcStruct data)
        {
            var item = new TestPlatform();
            item.id = ToInt(data, "id");
            item.name = (string) data["name"];
            item.notes = (string) data["notes"];

            return item;
        }

        /// <summary>
        ///  constructor used by XMLRPC interface on decoding the function return
        /// </summary>
        /// <param name="data">data returned by Testlink</param>
        internal static TestProject ToTestProject(XmlRpcStruct data)
        {
            var item = new TestProject();
            item.id = ToInt(data, "id");
            item.notes = (string) data["notes"];
            item.color = (string) data["color"];
            item.active = ToInt(data, "active") == 1;
            //changed option encoding sinc V 1.9
            var opt = data["opt"] as XmlRpcStruct;
            item.option_reqs = (int) opt["requirementsEnabled"] == 1;
            item.option_priority = (int) opt["testPriorityEnabled"] == 1;
            item.option_automation = (int) opt["automationEnabled"] == 1;
            item.option_inventory = (int) opt["inventoryEnabled"] == 1;
            item.prefix = (string) data["prefix"];
            item.tc_counter = ToInt(data, "tc_counter");
            item.name = (string) data["name"];

            return item;
        }

        /// <summary>
        ///  constructor used by the XML Rpc return
        /// </summary>
        /// <param name="data"></param>
        internal static TestStep ToTestStep(XmlRpcStruct data)
        {
            var item = new TestStep();
            item.id = ToInt(data, "id");
            item.step_number = ToInt(data, "step_number");
            item.actions = (string) data["actions"];
            item.expected_results = (string) data["expected_results"];
            item.active = ToInt(data, "active") == 1;
            item.execution_type = ToInt(data, "execution_type");

            return item;
        }

        /// <summary>
        ///  constructor used by XMLRPC interface on decoding the function return
        /// </summary>
        /// <param name="data">data returned by Testlink</param>
        internal static TestSuite ToTestSuite(XmlRpcStruct data)
        {
            var item = new TestSuite();
            item.name = (string) data["name"];
            item.id = ToInt(data, "id");
            item.parentId = ToInt(data, "parent_id");
            item.nodeTypeId = ToInt(data, "node_type_id");
            item.nodeOrder = ToInt(data, "node_order");

            return item;
        }


        public static TestPlan ToTestPlan(XmlRpcStruct data)
        {
            return new TestPlan
            {
                active = ToInt(data, "active") == 1,
                id = ToInt(data, "id"),
                name = (string) data["name"],
                notes = (string) data["notes"],
                testproject_id = ToInt(data, "testproject_id"),
                open = ToInt(data, "is_open") == 1,
                is_public = ToInt(data, "is_public") == 1
            };
        }

        internal static TestCase ToTestCase(XmlRpcStruct data)
        {
            var tc = new TestCase
            {
                active = int.Parse((string) data["active"]) == 1,
                externalid = (string) data["tc_external_id"],
                id = ToInt(data, "id"),
                updater_login = (string) data["updater_login"],
                author_login = (string) data["author_login"],
                name = (string) data["name"],
                node_order = ToInt(data, "node_order"),
                testsuite_id = ToInt(data, "testsuite_id"),
                testcase_id = ToInt(data, "testcase_id"),
                version = ToInt(data, "version"),
                layout = (string) data["layout"],
                status = ToInt(data, "status"),
                summary = (string) data["summary"],
                preconditions = (string) data["preconditions"],
                importance = ToInt(data, "importance"),
                author_id = ToInt(data, "author_id"),
                updater_id = ToInt(data, "updater_id"),
                modification_ts = ToDate(data, "modification_ts"),
                creation_ts = ToDate(data, "creation_ts"),
                is_open = int.Parse((string) data["is_open"]) == 1,
                execution_type = ToInt(data, "execution_type"),
                author_first_name = (string) data["author_first_name"],
                author_last_name = (string) data["author_last_name"],
                updater_first_name = (string) data["updater_first_name"],
                updater_last_name = (string) data["updater_last_name"],
                steps = new List<TestStep>()
            };

            var stepData = data["steps"] as object[];
            if (stepData != null)
                foreach (XmlRpcStruct aStepDatum in stepData)
                    tc.steps.Add(ToTestStep(aStepDatum));

            return tc;
        }

        protected static int ToInt(XmlRpcStruct data, string name)
        {
            if (data.ContainsKey(name))
            {
                var val = data[name];
                switch (val)
                {
                    case string s:
                        if (int.TryParse(s, out var n)) return n;
                        break;
                    case int _:
                        return (int) val;
                }
            }

            return 0;
        }

        protected static bool? ToBool(XmlRpcStruct data, string name)
        {
            if (data.ContainsKey(name))
            {
                var val = data[name];
                if (val is string)
                {
                    bool.TryParse(val as string, out var result);
                    return result;
                }

                return data[name] as bool?;
            }

            return null;
        }

        //protected TestCaseResultStatus ToExecStatus(XmlRpcStruct data, string name)
        //{
        //    var result = TestCaseResultStatus.undefined;
        //    if (data.ContainsKey(name))
        //    {
        //        var c = ToChar(data, name);
        //        switch (c)
        //        {
        //            case 'f':
        //            case 'F':
        //                result = TestCaseResultStatus.Failed;
        //                break;
        //            case 'b':
        //            case 'B':
        //                result = TestCaseResultStatus.Blocked;
        //                break;
        //            case 'p':
        //            case 'P':
        //                result = TestCaseResultStatus.Passed;
        //                break;
        //        }
        //    }
        //    return result;
        //}

        protected static DateTime ToDate(XmlRpcStruct data, string name)
        {
            if (data.ContainsKey(name) && DateTime.TryParse((string) data[name], out var n)) return n;
            return DateTime.MinValue;
        }

        protected static char ToChar(XmlRpcStruct data, string name)
        {
            if (data.ContainsKey(name) && data[name] is string)
            {
                var s = (string) data[name];
                return s[0];
            }

            return '\x00';
        }
    }
}