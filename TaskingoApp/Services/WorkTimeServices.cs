﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Documents;
using Newtonsoft.Json;
using TaskingoApp.APICall;
using TaskingoApp.Model;

namespace TaskingoApp.Services
{
    public class WorkTimeServices : IWorkTimeServices
    {
        public async Task<List<WorkTimeModel>> GetWorkTimeByUserId(int id)
        {
            var jsonWorkTime = await BaseCall.MakeCall($"WorkTime/{id}", System.Net.Http.HttpMethod.Get, null);
            var workTask = JsonConvert.DeserializeObject<List<WorkTimeModel>>(jsonWorkTime);
            return workTask;
        }
    }
}
