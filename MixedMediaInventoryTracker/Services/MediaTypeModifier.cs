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
    public class MediaTypeModifier
    {
        public SqlConnection CreateConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["MixedMediaInventoryTracker"].ConnectionString);
        }

        public bool Edit(int id, MediaTypeModel mediaType)
        {
            using (var db = CreateConnection())
            {
                db.Open();

                var editMediaType = db.Execute(@"UPDATE MediaType
                                                    SET MediaType = @MediaType,
                                                    WHERE id = @id", new
                                                    {
                                                        mediaType.MediaType,
                                                        id
                                                    });

                return editMediaType == 1;
            }
        }
    }
}