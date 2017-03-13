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
using System.Data.SqlTypes;
using System.Globalization;

namespace BigCommerce4NetStandard.Domain.ExtensionMethods
{
    public static class MyExtensions
    {
        public static DateTime? StringToDateTime(this string value) {

            DateTime? returnValue;
            DateTime tmpDate;
            bool wasParsed = DateTime.TryParse(value, CultureInfo.InvariantCulture.DateTimeFormat, DateTimeStyles.None, out tmpDate);
            if (wasParsed)
                returnValue = tmpDate;
            else
                returnValue = null;

            return returnValue;
        }

        public static string DateTimeToString(this DateTime? theDateTime) {
            if (theDateTime == (DateTime)SqlDateTime.MinValue || theDateTime == null)
                return String.Empty;
            else
                return ((DateTime)theDateTime).ToUniversalTime().ToString("r");
        }

        #region Extension attributes
        //
        //  [JsonIgnoreSerialization]
        //
        // http://stackoverflow.com/questions/11564091/making-a-property-deserialize-but-not-serialize-with-json-net
        public class JsonPropertiesResolver : Newtonsoft.Json.Serialization.DefaultContractResolver
        {
            protected override List<System.Reflection.MemberInfo> GetSerializableMembers(Type objectType)
            {
                //Return properties that do NOT have the JsonIgnoreSerializationAttribute
                return objectType.GetProperties()
                    .Where(pi => !Attribute.IsDefined(pi, typeof(JsonIgnoreSerializationAttribute)))
                    .ToList<System.Reflection.MemberInfo>();
            }
        }
    }
    public class JsonIgnoreSerializationAttribute : Attribute { }
    #endregion // Extension attributes
}
