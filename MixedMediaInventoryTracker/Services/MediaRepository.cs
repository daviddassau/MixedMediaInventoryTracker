using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using Dapper;
using MixedMediaInventoryTracker.Models;

namespace MixedMediaInventoryTracker
{
    public class MediaRepository
    {
        public SqlConnection CreateConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["MixedMediaInventoryTracker"].ConnectionString);
        }

        public bool Create(MediaModel media)
        {
            using (var db = CreateConnection())
            {
                db.Open();

                var createCustomer = db.Execute(@"INSERT INTO [dbo].[Media]
                                               ([MediaTypeId]
                                               ,[MediaConditionId]
                                               ,[Title]
                                               ,[DatePurchased]
                                               ,[DateAdded]
                                               ,[IsLentOut]
                                               ,[IsSold]
                                               ,[Notes])
                                         VALUES
                                               (@MediaTypeId
                                               ,@MediaConditionId
                                               ,@Title
                                               ,@DatePurchased
                                               ,@DateAdded
                                               ,@IsLentOut
                                               ,@IsSold
                                               ,@Notes)", media);

                return createCustomer == 1;
            }
        }

        public IEnumerable<MediaDto> GetAllMedia()
        {
            using (var db = CreateConnection())
            {
                db.Open();

                var allMedia = db.Query<MediaDto>("SELECT * FROM media");

                return allMedia;
            }
        }
    }
}