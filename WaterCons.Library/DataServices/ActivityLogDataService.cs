﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WaterCons.Library.Models;
using WaterCons.Library.Interfaces;

namespace WaterCons.Library.DataServices
{
    public class ActivityLogDataService : EntityFrameworkDataService, IActivityLogDataService
    {
        /// <summary>
        /// Create ActivityLog
        /// </summary>
        public void AddActivityLog(activitylog objActivityLog)
        {
            dbConnection.activitylogs.Add(objActivityLog);
        }

        public activitylog GetActivityLog(int ID)
        {
            activitylog objActivityLog = dbConnection.activitylogs.SingleOrDefault(u => u.ID == ID);
            return objActivityLog;
        }
        
        public void UpdateActivityLog(activitylog objActivityLog)
        {
            dbConnection.activitylogs.Add(objActivityLog);
        }
    }
}
