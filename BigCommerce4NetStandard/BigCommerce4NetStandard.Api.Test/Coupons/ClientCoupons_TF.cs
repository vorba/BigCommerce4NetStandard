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
using BigCommerce4NetStandard.Domain;
using Newtonsoft.Json;

namespace BigCommerce4NetStandard.Api.Test.Customers
{
    [TestFixture]
    public class ClientCoupons_TF : FixtureBase
    {

        [Test]
        public void Can_Get_All_Coupons_Default_Paging() {

            var response = Client.Coupons.Get();
            Assert.AreEqual(response.RestResponse.StatusCode, System.Net.HttpStatusCode.OK);
            Assert.Greater(response.Data.Count, 0);
        }
        [Test]
        public void Can_Get_Coupons_With_Limit_Parameter_Paging() {
            var filter = new Api.FilterStates {
                Limit = 5
            };

            var response = Client.Coupons.Get(filter);
            Assert.AreEqual(response.RestResponse.StatusCode, System.Net.HttpStatusCode.OK);
            Assert.NotNull(response.Data);
            Assert.AreEqual(response.Data.Count, 5);
        }
        [Test]
        public void Can_Get_One_Coupon_By_Id() {

            var response = Client.Coupons.Get(TEST_COUPON_ID);
            Assert.AreEqual(response.RestResponse.StatusCode, System.Net.HttpStatusCode.OK);
            Assert.NotNull(response.Data);
            Assert.AreEqual(response.Data.Id, TEST_COUPON_ID);
        }
        [Test]
        public void Can_Get_Coupons_Options() {

            var response = Client.Coupons.GetHttpOptions();
            Assert.AreEqual(response.RestResponse.StatusCode, System.Net.HttpStatusCode.OK);
            Assert.NotNull(response.Data);
        }
    }
}
