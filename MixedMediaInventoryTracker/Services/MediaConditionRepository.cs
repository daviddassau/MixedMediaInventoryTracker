﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MixedMediaInventoryTracker.Models;
using Dapper;
using System.Data.SqlClient;
using System.Configuration;

namespace MixedMediaInventoryTracker.Services
{
    public class MediaConditionRepository
    {
        public SqlConnection CreateConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["MixedMediaInventoryTracker"].ConnectionString);
        }

        public IEnumerable<MediaConditionDto> GetAllMediaConditions()
        {
            using (var db = CreateConnection())
            {
                db.Open();

                var allMediaConditions = db.Query<MediaConditionDto>("SELECT * FROM MediaCondition");

                return allMediaConditions;
            }
        }
    }
}