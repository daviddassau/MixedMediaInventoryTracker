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

        public IEnumerable<LentMediaModel> GetAllLentMedia()
        {
            using (var db = CreateConnection())
            {
                db.Open();

                var allLentMedia = db.Query<LentMediaModel>(@"SELECT l.Id, l.LendeeName, l.DateLent, l.Notes, m.Title, c.MediaCondition
                                                            FROM LentMedia l
                                                            JOIN Media m on m.Id = l.MediaId
                                                            JOIN MediaCondition c on c.Id = m.MediaConditionId");

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