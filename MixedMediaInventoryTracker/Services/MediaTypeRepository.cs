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
    public class MediaTypeRepository
    {
        public SqlConnection CreateConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["MixedMediaInventoryTracker"].ConnectionString);
        }

        public IEnumerable<MediaTypeDto> GetAllMediaTypes()
        {
            using (var db = CreateConnection())
            {
                db.Open();

                var allMediaTypes = db.Query<MediaTypeDto>("SELECT * FROM MediaType");

                return allMediaTypes;
            }
        }

        public MediaTypeDto SingleMediaType(int id)
        {
            using (var db = CreateConnection())
            {
                db.Open();

                var singleMediaType = db.QueryFirstOrDefault<MediaTypeDto>(@"SELECT * FROM MediaType WHERE Id = @Id", new { id });

                return singleMediaType;
            }
        }
        
    }
}