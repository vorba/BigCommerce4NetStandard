#region License
//   Copyright 2017
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License. 
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Api = BigCommerce4NetStandard.Api;
using Domain = BigCommerce4NetStandard.Domain;

namespace BigCommerce4NetStandard.Api.Test.Utilities
{
    [TestFixture]
    public class ClientRequestLogs_TF : FixtureBase
    {
        [Test]
        public void Can_Get_RequestLog_Data() {

            var response = Client.RequestLogs.Get();

            Assert.AreEqual(response.RestResponse.StatusCode, System.Net.HttpStatusCode.OK);
            Assert.Greater(response.Data.Count, 0);
        }
        [Test]
        public void Can_Get_GetHttpOptions() {

            var response = Client.RequestLogs.GetHttpOptions();
            Assert.AreEqual(response.RestResponse.StatusCode, System.Net.HttpStatusCode.OK);
            Assert.AreNotEqual(response.Data, null);
        }
    }
}