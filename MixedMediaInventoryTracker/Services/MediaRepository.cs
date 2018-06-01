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

        //public MediaDto GetSingleItem(int id)
        //{
        //    using (var db = CreateConnection())
        //    {
        //        db.Open();

        //        var singleItem = db.QueryFirstOrDefault<MediaDto>(@"SELECT m.Id, m.Title, m.DatePurchased, m.DateAdded, m.IsLentOut, m.IsSold, m.Notes, t.MediaType, c.MediaCondition
        //                                                            FROM Media m
        //                                                            JOIN MediaType t on t.Id = m.MediaTypeId
        //                                                            JOIN MediaCondition c on c.Id = m.MediaConditionId
        //                                                            WHERE m.Id = @id", new { id });

        //        return singleItem;
        //    }
        //}

        public MediaModel GetSingleItem(int id)
        {
            using (var db = CreateConnection())
            {
                db.Open();

                var query = @"SELECT * FROM Media WHERE Id = @id
                              SELECT t.* FROM MediaType t
                              SELECT c.* FROM MediaCondition c";

                MediaModel media;
                using (var multi = db.QueryMultiple(query, new { id }))
                {
                    media = multi.Read<MediaModel>().First();
                    media.MediaTypes = multi.Read<MediaTypeModel>().ToList();
                }

                return media;
            }
        }
    }
}