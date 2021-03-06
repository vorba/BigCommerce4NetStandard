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
using Newtonsoft.Json;


namespace BigCommerce4NetStandard.Domain
{
    public class ServerDateTime 
    {
        private double? _Time;
        /// <summary>
        /// The current UNIX 32-bit time stamp.
        /// </summary>
        [JsonProperty("time")]
        public double? UnixTimeStamp
        {
            get
            {
                return _Time;
            }
            set
            {
                _Time = value;
                if (_Time != null)
                    CurrentDateTime = ConvertFromUnixTimestamp((double)_Time);
            }
        }
        /// <summary>
        /// .Net DateTime of UnixTimeStamp
        /// </summary>
        [JsonIgnore]
        public DateTime? CurrentDateTime { get; private set; }

        static DateTime ConvertFromUnixTimestamp(double timestamp)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return origin.AddSeconds(timestamp);
        }
    }
}
