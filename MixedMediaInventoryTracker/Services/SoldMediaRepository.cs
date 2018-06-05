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
    public class SoldMediaRepository
    {
        public SqlConnection CreateConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["MixedMediaInventoryTracker"].ConnectionString);
        }

        public IEnumerable<SoldMediaModel> GetAllSoldMedia()
        {
            using (var db = CreateConnection())
            {
                db.Open();

                var allSoldMedia = db.Query<SoldMediaModel>(@"SELECT s.Id, s.Buyer, s.Amount, s.SoldDate, s.Notes, m.Title, c.MediaCondition
                                                              FROM SoldMedia s
                                                              JOIN Media m on m.Id = s.MediaId
                                                              JOIN MediaCondition c on c.Id = m.MediaConditionId");

                return allSoldMedia;
            }
        }

        public bool SellMedia(SoldMediaDto soldMedia)
        {
            using (var db = CreateConnection())
            {
                db.Open();

                var sellMediaItem = db.Execute(@"INSERT INTO [dbo].[SoldMedia]
                                                       ([MediaId]
                                                       ,[Buyer]
                                                       ,[Amount]
                                                       ,[SoldDate]
                                                       ,[Notes]
                                                       ,[MediaConditionId])
                                                 VALUES
                                                       (@MediaId
                                                       ,@Buyer
                                                       ,@Amount
                                                       ,@SoldDate
                                                       ,@Notes
                                                       ,@MediaConditionId)", soldMedia);

                return sellMediaItem == 1;
            }
        }
    }
}