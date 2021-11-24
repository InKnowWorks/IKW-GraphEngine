// Graph Engine
// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
//
using System;
using Trinity;
using Xunit;

namespace FanoutSearch.UnitTest
{
    [Collection("All")]
    public class LambdaDSLTest2
    {
        private void LambdaQuery(string str)
        {
            var mod = Global.CommunicationInstance.GetCommunicationModule<FanoutSearchModule>();
            mod.LambdaQuery(str);
        }

        [Fact]
        public void LambdaDSLTest2_1()
        {
            Expect.FanoutSearchQueryException(
            LambdaQuery, @"
MAG
  .StartFrom(@""{
    type  : """"Author"""",
    match : {
      Name : """"bin shao""""
    }
  }"")
  .FollowEdge(""PaperIDs"")
  .VisitNode(Action.Return, new List<string>{ ""OriginalTitle"" });

MAG
  .StartFrom(@""{
    type  : """"Author"""",
    match : {
      Name : """"bin shao""""
    }
  }"")
  .FollowEdge(""PaperIDs"")
  .VisitNode(Action.Return, new List<string>{ ""OriginalTitle"" });
", "too many statements");
        }

        [Fact]
        public void LambdaDSLTest2_2()
        {
            Expect.FanoutSearchQueryException(LambdaQuery, @"
MAG
  .FollowEdge(""PaperIDs"")
  .VisitNode(Action.Return, new List<string>{ ""OriginalTitle"" });
", "Expecting StartFrom");

        }

        [Fact]
        public void LambdaDSLTest2_3()
        {
            Expect.FanoutSearchQueryException(LambdaQuery, @"MAG
  .StartFrom(@""{
    type  : """"Author"""",
    match : {
      Name : """"bin shao""""
    }
  }"")
  .FollowEdge(""PaperIDs"")
  .VisitNode(Action.Return, ""OriginalTitle"");
"
, "Syntax error");
        }

        [Fact]
        public void LambdaDSLTest2_4()
        {
            LambdaQuery(@"MAG
  .StartFrom(@""{
    type  : """"Paper"""",
    match : {
      NormalizedTitle : """"graph engine""""
    }
  }"")
  .FollowEdge(""AuthorIDs"")
  .VisitNode(Action.Return, new List<string>{ ""Wife"" });

"
                );
        }

        [Fact]
        public void LambdaDSLTest2_5()
        {
            LambdaQuery(@"MAG
  .StartFrom(@""{
    type  : """"Paper"""",
    match : {
      NormalizedTitle : """"graph engine""""
    }
  }"")
  .FollowEdge(""AffiliationIDs"")
  .VisitNode(Action.Return, new List<string>{ ""Name"", ""Aliases"" });

"
                );
        }

        [Fact]
        public void LambdaDSLTest2_6()
        {
            LambdaQuery(@"// the following query almost traverse through all entities in the graph.
        MAG
          .StartFrom(new List<long>{ 1290206253 }, new List<string>{ ""Name"" })
  .FollowEdge(""AuthorIDs"")
  .VisitNode(v => v.continue_if(v.get(""Name"").Contains(""bin"")), new List<string>{ ""DisplayAuthorName"" })
  .FollowEdge(""PaperIDs"")
  .VisitNode(v => v.continue_if(v.count(""AuthorIDs"") <= 3), new List<string>{ ""OriginalTitle"" })
  .FollowEdge(""ConferenceSeriesID"")
  .VisitNode(v => v.continue_if(v.count(""ConferenceInstanceIDs"") >= 3), new List<string>{ ""FullName"" })
  .FollowEdge(""ConferenceInstanceIDs"")
  .VisitNode(v => Action.Continue, new List<string>{ ""FullName"", ""OfficialURL"" })
  .FollowEdge(""FieldOfStudyIDs"")
  .VisitNode(v => Action.Return, new List<string>{ ""Name"", ""Aliases"" });

"
                );
        }

        [Fact]
        public void LambdaDSLTest2_7()
        {
            LambdaQuery(@"MAG
  .StartFrom(new List<long>{ 1290206253 }, new List<string>{ ""Name"" })
  .FollowEdge(""AuthorIDs"")
  .VisitNode(Action.Return, new List<string>{ ""Name"" });

"
                );
        }

        [Fact]
        public void LambdaDSLTest2_8()
        {
            LambdaQuery(@"MAG
  .StartFrom(@""{
    type: """"Affiliation"""",
    match:
    {
        Name: """"micro rf""""
    }
}"", new List<string>{ ""Name"" })
  .FollowEdge(""AuthorIDs"")
  .VisitNode(Action.Return, new List<string>{ ""Name"" });

"
                );
        }

        [Fact]
        public void LambdaDSLTest2_9()
        {
            LambdaQuery(@"MAG
  .StartFrom(@""{
    type: """"Author"""",
    match:
    {
        Name: """"bin shao""""
    }
}"", new List<string>{ ""Name"" })
  .FollowEdge(""AffiliationIDs"")
  .VisitNode(Action.Return, new List<string>{ ""Name"" });

"
                );
        }

        [Fact]
        public void LambdaDSLTest2_10()
        {
            LambdaQuery(@"MAG
  .StartFrom(@""{
    type: """"Author"""",
    match:
    {
        Name: """"bin shao""""
    }
}"", new List<string>{ ""DisplayAuthorName"" })
  .FollowEdge(""PaperIDs"")
  .VisitNode(v => v.return_if(v.has(""SomeNonsenseField"")),
             new List<string>{ ""OriginalTitle"", ""ConferenceSeriesID"" });

"
                );
        }

        [Fact]
        public void LambdaDSLTest2_11()
        {
            LambdaQuery(@"MAG
  .StartFrom(@""{
    type: """"Author"""",
    match:
    {
        Name: """"daniel""""
    }
}"", new List<string>{ ""DisplayAuthorName"" })
  .FollowEdge(""PaperIDs"")
  .VisitNode(v => v.return_if(v.has(""ConferenceSeriesID"")),
             new List<string>{ ""OriginalTitle"", ""ConferenceSeriesID"" });

"
                );
        }

        [Fact]
        public void LambdaDSLTest2_12()
        {
            LambdaQuery(@"MAG
  .StartFrom(@""{
    type: """"ConferenceSeries"""",
    match:
    {
        FullName: """"graph""""
    }
}"", new List<string>{ ""FullName"", ""ShortName"" })
  .FollowEdge(""ConferenceInstanceIDs"")
  .VisitNode(Action.Return,
             new List<string>{ ""FullName"" });

"
                );
        }

        [Fact]
        public void LambdaDSLTest2_13()
        {
            LambdaQuery(@"MAG
  .StartFrom(@""{
    type: """"ConferenceSeries"""",
    match:
    {
        FullName: """"graph""""
    }
}"", new List<string>{ ""FullName"", ""ShortName"" })
  .FollowEdge(""ConferenceInstanceIDs"")
  .VisitNode(Action.Continue,
             new List<string>{ ""FullName"" })
  .VisitNode(v => v.return_if(v.get(""Name"").Contains(""World Wide Web"")),
             new List<string>{ ""Name"" });

"
                );
        }

        [Fact]
        public void LambdaDSLTest2_14()
        {
            LambdaQuery(@"MAG
  .StartFrom(@""{
    type: """"ConferenceSeries"""",
    match:
    {
        FullName: """"graph""""
    }
}"", new List<string>{ ""FullName"", ""ShortName"" })
  .FollowEdge(""ConferenceInstanceIDs"")
  .VisitNode(v => v.return_if(v.GetField<DateTime>(""StartDate"").ToString().Contains(""2014"")),
             new List<string>{ ""FullName"", ""StartDate"" });

"
                );
        }

        [Fact]
        public void LambdaDSLTest2_15()
        {
            LambdaQuery(@"MAG
  .StartFrom(@""{
    type: """"Author"""",
    match:
    {
        Name: """"bin shao""""
    }
}"", new List<string>{ ""DisplayAuthorName"" })
  .FollowEdge(""PaperIDs"")
  .VisitNode(v => v.return_if(v.has(""ConferenceSeriesID"")),
             new List<string>{ ""OriginalTitle"", ""ConferenceSeriesID"" });

"
                );
        }

        [Fact]
        public void LambdaDSLTest2_16()
        {
            LambdaQuery(@"MAG
  .StartFrom(@""{
    type: """"Author"""",
    match:
    {
        Name: """"bin shao""""
    }
}"", new List<string>{ ""DisplayAuthorName"" })
  .FollowEdge(""PaperIDs"")
  .VisitNode(v => v.continue_if(v.GetField<uint>(""JournalID"") > 0),
             new List<string>{ ""OriginalTitle"", ""JournalID"" })
  .VisitNode(Action.Return, new List<string>{ ""name"" });

"
                );
        }

        [Fact]
        public void LambdaDSLTest2_17()
        {
            LambdaQuery(@"MAG
  .StartFrom(@""{
    type: """"Author"""",
    match:
    {
        Name: """"bin shao""""
    }
}"")
  .FollowEdge(""PaperIDs"")
  .VisitNode(v => v.return_if(v.GetField<int>(""CitationCount"") > 0),
             new List<string>{ ""OriginalTitle"", ""CitationCount"" });

"
                );
        }

        [Fact]
        public void LambdaDSLTest2_18()
        {
            LambdaQuery(@"MAG
  .StartFrom(@""{
    type: """"Affiliation"""",
    match:
    {
        Name: """"microsoft""""
    }
}"")
  .FollowEdge(""AuthorIDs"")
  .VisitNode(v => v.return_if(v.has(""Aliases"", ""b shao"")),
             new List<string>{ ""DisplayAuthorName"", ""Aliases"" });

"
                );
        }

        [Fact]
        public void LambdaDSLTest2_19()
        {
            LambdaQuery(@"MAG
  .StartFrom(@""{
    type: """"Affiliation"""",
    match:
    {
        Name: """"microsoft""""
    }
}"")
  .FollowEdge(""PaperIDs"")
  .VisitNode(v => v.return_if(v.get(""NormalizedTitle"").Contains(""graph"")),
             new List<string>{ ""OriginalTitle"" });

"
                );
        }

        [Fact]
        public void LambdaDSLTest2_20()
        {
            LambdaQuery(@"MAG
  .StartFrom(@""{
            type: """"Affiliation"""",
    match:
            {
                Name: """"microsoft""""
    }
        }"")
  .FollowEdge(""PaperIDs"")
  .VisitNode(v => v.return_if(v.get(""NormalizedTitle"").Contains(""graph"") || v.GetField<int>(""CitationCount"") > 100),
             new List<string>{ ""OriginalTitle"", ""CitationCount"" });

");

        }

        [Fact]
        public void LambdaDSLTest2_21()
        {
            LambdaQuery(@"
MAG.StartFrom(new[]{1,2,3}).VisitNode(v => v.return_if(v.has_cell_id(new long[]{1,2,3})));
");
        }

        [Fact]
        public void LambdaDSLTest2_22()
        {
            LambdaQuery(@"
MAG.StartFrom(new[]{1,2,3}).VisitNode(v => v.return_if(new List<long>(){1,2,3}.Contains(v.CellId)));
");
        }
    }
}
