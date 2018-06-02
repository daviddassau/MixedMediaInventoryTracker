using MixedMediaInventoryTracker.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;

namespace MixedMediaInventoryTracker.Services
{
    public class MediaModifier
    {
        public SqlConnection CreateConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["MixedMediaInventoryTracker"].ConnectionString);
        }

        public bool EditMediaItem(int id, MediaDto media)
        {
            using (var db = CreateConnection())
            {
                db.Open();

                var editMediaItem = db.Execute(@"UPDATE [dbo].[Media]
                                                   SET Title = @Title,
                                                       DatePurchased = @DatePurchased,
                                                       DateAdded = @DateAdded,
                                                       IsLentOut = @IsLentOut,
                                                       IsSold = @IsSold,
                                                       Notes = @Notes
                                                 WHERE id = @id", new
                                                 {
                                                    media.Title,
                                                    media.DatePurchased,
                                                    media.DateAdded,
                                                    media.IsLentOut,
                                                    media.IsSold,
                                                    media.Notes,
                                                    id
                                                });

                return editMediaItem == 1;
            }
        }

        public bool DeleteMediaItem(int id)
        {
            using (var db = CreateConnection())
            {
                db.Open();

                var deleteMediaItem = db.Execute(@"DELETE FROM Media
                                                    WHERE Id = @id", new { id });

                return deleteMediaItem == 1;
            }
        }
    }
}