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
using System.Threading.Tasks;

namespace BigCommerce4NetStandard.Api.Test.Products
{
    [TestFixture]
    public class ClientProducts_TF : FixtureBase
    {
        [Test]
        public void Can_Get_GetHttpOptions() {

            var response = Client.Products.GetHttpOptions();
            Assert.AreEqual(response.RestResponse.StatusCode, System.Net.HttpStatusCode.OK);
            Assert.AreNotEqual(response.Data, null);
        }

        [Test]
        public void Can_Get_Count()
        {

            var response = Client.Products.Count();
            Assert.AreEqual(response.RestResponse.StatusCode, System.Net.HttpStatusCode.OK);
            Assert.AreNotEqual(response.Data, null);
            Assert.Greater(response.Data.Count, 0);
        }

        [Test]
        public void Can_Get_Filtered()
        {
            var response = Client.Products.Get(
                new FilterOrders
                {
                    Limit = 10,
                });
            Assert.AreEqual(response.RestResponse.StatusCode, System.Net.HttpStatusCode.OK);
            Assert.AreNotEqual(response.Data, null);
            Assert.AreEqual(response.Data.Count, 10);
        }

        [Test]
        public async Task Can_Get_Filtered_Async()
        {
            var response = await Client.Products.GetAsync(
                new FilterOrders
                {
                    Limit = 10,
                });
            Assert.AreEqual(response.RestResponse.StatusCode, System.Net.HttpStatusCode.OK);
            Assert.AreNotEqual(response.Data, null);
            Assert.AreEqual(response.Data.Count, 10);
        }

        [Test]
        public void Can_Create()
        {
            var sku = Guid.NewGuid().ToString();
            var response = Client.Products.Create(
                new Domain.Product
                {
                    Name = "Test",
                    Categories = new List<int>() { 22 },
                    Sku = sku,
                    Description = $"Test Product (sku: {sku})",
                    
                });
            Assert.AreEqual(response.RestResponse.StatusCode, System.Net.HttpStatusCode.Created);
            Assert.AreEqual(response.Data.Sku, sku);
        }
    }
}
