using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using Dapper;
using MixedMediaInventoryTracker.Models;
using RestSharp;

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
                                                                JOIN MediaCondition c on c.Id = m.MediaConditionId
                                                                WHERE m.IsLentOut = 0");

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
                                                                JOIN MediaCondition c on c.Id = m.MediaConditionId
                                                                WHERE m.IsSold = 0");

                return itemToSell;
            }
        }

        public MediaItemDetailsModel ItemDetails(int id)
        {
            using (var db = CreateConnection())
            {
                db.Open();

                var singleItemDetails = db.QueryFirstOrDefault<MediaItemDetailsModel>(@"SELECT m.Id, m.Title, m.DatePurchased, m.DateAdded, m.IsLentOut, m.IsSold, m.Notes, c.MediaCondition, t.MediaType
                                                                                        FROM Media m
                                                                                        JOIN MediaCondition c on c.Id = m.MediaConditionId
                                                                                        JOIN MediaType t on t.Id = m.MediaTypeId
                                                                                        WHERE m.Id = @Id", new { id });

                return singleItemDetails;
            }
        }

        public ApiResult SearchMediaItem(string term)
        {
            var client = new RestClient("https://itunes.apple.com");

            var request = new RestRequest("search/", Method.GET);
            request.AddParameter("term", term, ParameterType.QueryString); // adds to POST or URL querystring based on Method
            request.AddParameter("entity", "movie", ParameterType.QueryString);
            request.AddParameter("limit", 25, ParameterType.QueryString);

            var response = client.Execute<ApiResult>(request);
            foreach (var result in response.Data.results)
            {
                result.artworkUrl100 = result.artworkUrl100.Replace("100x100bb", "500x500bb");
            }
            return response.Data; // raw content as string

        }

    }

    public class SearchResult
    {
        public string trackName { get; set; }
        public string artworkUrl100 { get; set; }
    }

    public class ApiResult
    {
        public int resultCount { get; set; }
        public List<SearchResult> results { get; set; }
    }
}