using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;
using MixedMediaInventoryTracker.Models;

namespace MixedMediaInventoryTracker.Services
{
    public class LentMediaRepository
    {
        public SqlConnection CreateConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["MixedMediaInventoryTracker"].ConnectionString);
        }

        public IEnumerable<LentMediaDto> GetAllLentMedia()
        {
            using (var db = CreateConnection())
            {
                db.Open();

                var allLentMedia = db.Query<LentMediaDto>("SELECT * FROM LentMedia");

                return allLentMedia;
            }
        }

        public bool LendMedia(LentMediaDto lentMedia)
        {
            using (var db = CreateConnection())
            {
                db.Open();

                var lendMediaItem = db.Execute(@"INSERT INTO [dbo].[LentMedia]
                                                       ([MediaId]
                                                       ,[LendeeName]
                                                       ,[MediaConditionId]
                                                       ,[DateLent]
                                                       ,[Notes])
                                                 VALUES
                                                       (@MediaId
                                                       ,@LendeeName
                                                       ,@MediaConditionId
                                                       ,@DateLent
                                                       ,@Notes)", lentMedia);

                return lendMediaItem == 1;
            }
        }
    }
}