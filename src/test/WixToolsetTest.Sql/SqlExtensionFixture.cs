// Copyright (c) .NET Foundation and contributors. All rights reserved. Licensed under the Microsoft Reciprocal License. See LICENSE.TXT file in the project root for full license information.

namespace WixToolsetTest.Sql
{
    using System.Linq;
    using WixBuildTools.TestSupport;
    using WixToolset.Core.TestPackage;
    using WixToolset.Sql;
    using Xunit;

    public class SqlExtensionFixture
    {
        [Fact]
        public void CanBuildUsingSqlString()
        {
            var folder = TestData.Get(@"TestData\UsingSql");
            var build = new Builder(folder, typeof(SqlExtensionFactory), new[] { folder });

            var results = build.BuildAndQuery(Build, "SqlString");
            Assert.Equal(new[]
            {
                "SqlString:TestString\tTestDB\tfilF5_pLhBuF5b4N9XEo52g_hUM5Lo\tCREATE TABLE TestTable1(name varchar(20), value varchar(20))\t\t1\t",
            }, results.ToArray());
        }

        private static void Build(string[] args)
        {
            var result = WixRunner.Execute(args)
                                  .AssertSuccess();
        }
    }
}
