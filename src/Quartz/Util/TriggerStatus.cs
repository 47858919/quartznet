/* 
* Copyright 2004-2005 OpenSymphony 
* 
* Licensed under the Apache License, Version 2.0 (the "License"); you may not 
* use this file except in compliance with the License. You may obtain a copy 
* of the License at 
* 
*   http://www.apache.org/licenses/LICENSE-2.0 
*   
* Unless required by applicable law or agreed to in writing, software 
* distributed under the License is distributed on an "AS IS" BASIS, WITHOUT 
* WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the 
* License for the specific language governing permissions and limitations 
* under the License.
* 
*/

/*
* Previously Copyright (c) 2001-2004 James House
*/

using System;
#if !NET_20
using Nullables;
#endif

namespace Quartz.Util
{
    /// <summary> 
    /// Object representing a job or trigger key.
    /// </summary>
    /// <author>James House</author>
    public class TriggerStatus : Pair
    {
        private Key jobKey;
        private Key key;

        /// <summary> 
        /// Construct a new TriggerStatus with the status name and nextFireTime.
        /// </summary>
        /// <param name="status">The trigger's status</param>
        /// <param name="nextFireTime">The next time the trigger will fire</param>
#if !NET_20
        public TriggerStatus(string status, NullableDateTime nextFireTime)
#else
        public TriggerStatus(string status, DateTime? nextFireTime)
#endif
        {
            base.First = status;
            base.Second = nextFireTime;
        }

        /// <summary>
        /// Gets or sets the job key.
        /// </summary>
        /// <value>The job key.</value>
        public virtual Key JobKey
        {
            get { return jobKey; }
            set { jobKey = value; }
        }


        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        /// <value>The key.</value>
        public virtual Key Key
        {
            get { return key; }
            set { key = value; }
        }

        /// <summary>
        /// Get the name portion of the key.
        /// </summary>
        /// <returns> the name </returns>
        public virtual string Status
        {
            get { return (string) First; }
        }

        /// <summary>
        /// Get the group portion of the key.
        /// </summary>
        /// <returns> the group </returns>
#if !NET_20
        public virtual NullableDateTime NextFireTime
        {
            get { return (NullableDateTime) Second; }
        }
#else
        public virtual DateTime? NextFireTime
        {
            get { return (DateTime?) Second; }
        }
#endif

        // TODO: Repackage under spi or root pkg ?, put status constants here.

        /// <summary>
        /// Return the string representation of the TriggerStatus.
        /// </summary>
        public override string ToString()
        {
            return string.Format("status: {0}, next fire = {1}", Status, NextFireTime.Value.ToString("r"));
        }
    }
}