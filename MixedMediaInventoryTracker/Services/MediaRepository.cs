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

        public bool Create(MediaDto media)
        {
            using (var db = CreateConnection())
            {
                db.Open();

                var createMediaItem = db.Execute(@"INSERT INTO [dbo].[Media]
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
                                               ,default
                                               ,@IsLentOut
                                               ,@IsSold
                                               ,@Notes)", media);

                return createMediaItem == 1;
            }
        }
        
        public IEnumerable<MediaDto> GetAllMedia()
        {
            using (var db = CreateConnection())
            {
                db.Open();

                var allMedia = db.Query<MediaDto>(@"SELECT m.Id, m.Title, m.DatePurchased, m.DateAdded, m.IsLentOut, m.IsSold, m.Notes, t.MediaType, c.MediaCondition
                                                    FROM Media m
                                                    JOIN MediaType t on t.Id = m.MediaTypeId
                                                    JOIN MediaCondition c on c.Id = m.MediaConditionId");

                return allMedia;
            }
        }

        public MediaSingle GetSingleItem(int id)
        {
            using (var db = CreateConnection())
            {
                db.Open();

                var singleItem = db.QueryFirstOrDefault<MediaSingle>(@"SELECT * FROM Media WHERE Id = @Id", new { id });

                return singleItem;
            }
        }

        public IEnumerable<MediaItemToLendDto> MediaItemToLend()
        {
            using (var db = CreateConnection())
            {
                db.Open();

                var itemToLend = db.Query<MediaItemToLendDto>(@"SELECT m.Id, m.Title, c.MediaCondition
                                                                FROM Media m
                                                                JOIN MediaCondition c on c.Id = m.MediaConditionId");

                return itemToLend;
            }
        }

        public IEnumerable<MediaItemToSellDto> MediaItemToSell()
        {
            using (var db = CreateConnection())
            {
                db.Open();

                var itemToSell = db.Query<MediaItemToSellDto>(@"SELECT m.Id, m.Title, c.MediaCondition
                                                                FROM Media m
                                                                JOIN MediaCondition c on c.Id = m.MediaConditionId");

                return itemToSell;
            }
        }

    }
}