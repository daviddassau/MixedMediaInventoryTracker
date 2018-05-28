using System;
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

                var allSoldMedia = db.Query<SoldMediaModel>("SELECT * FROM SoldMedia");

                return allSoldMedia;
            }
        }

        internal object SellMedia()
        {
            throw new NotImplementedException();
        }
    }
}