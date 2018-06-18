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
                                               ,[Notes]
                                               ,[artworkUrl100]
                                               ,[Artist]
                                               ,[Author])
                                         VALUES
                                               (@MediaTypeId
                                               ,@MediaConditionId
                                               ,@Title
                                               ,@DatePurchased
                                               ,default
                                               ,@IsLentOut
                                               ,@IsSold
                                               ,@Notes
                                               ,@artworkUrl100
                                               ,@Artist
                                               ,@Author)", media);

                return createMediaItem == 1;
            }
        }

        public IEnumerable<MediaDto> GetAllMedia()
        {
            using (var db = CreateConnection())
            {
                db.Open();

                var allMedia = db.Query<MediaDto>(@"SELECT m.Id, m.Title, m.MediaTypeId, m.DatePurchased, m.DateAdded, m.IsLentOut, m.IsSold, m.Notes, m.artworkUrl100, m.Artist, m.Author, t.MediaType, c.MediaCondition
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

                var itemToLend = db.Query<MediaItemToLendDto>(@"SELECT m.Id, m.Title, m.artworkUrl100, c.MediaCondition
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

                var itemToSell = db.Query<MediaItemToSellDto>(@"SELECT m.Id, m.Title, m.artworkUrl100, c.MediaCondition
                                                                FROM Media m
                                                                JOIN MediaCondition c on c.Id = m.MediaConditionId
                                                                WHERE IsSold = 0 or IsSold IS NULL");

                return itemToSell;
            }
        }

        public MediaItemDetailsDto ItemDetails(int id)
        {
            using (var db = CreateConnection())
            {
                db.Open();

                var singleItemDetails = db.QueryFirstOrDefault<MediaItemDetailsDto>(@"SELECT m.Id, m.Title, m.DatePurchased, m.DateAdded, m.IsLentOut, m.IsSold, m.Notes, m.artworkUrl100, m.Artist, m.MediaTypeId, m.Author, c.MediaCondition, t.MediaType, t.Image,
                                                                                        CASE WHEN m.IsLentOut = 1 THEN 'Yes' else 'No' END AS IsLentOut,
                                                                                        CASE WHEN m.IsSold = 1 THEN 'Yes' else 'No' END AS IsSold
                                                                                        FROM Media m
                                                                                        JOIN MediaCondition c on c.Id = m.MediaConditionId
                                                                                        JOIN MediaType t on t.Id = m.MediaTypeId
                                                                                        WHERE m.Id = @Id", new { id });

                return singleItemDetails;
            }
        }

        public IEnumerable<RecentMediaDto> RecentlyAddedItems()
        {
            using (var db = CreateConnection())
            {
                var recentItem = db.Query<RecentMediaDto>(@"SELECT TOP 3 m.Id, m.Title, m.DateAdded, m.DatePurchased, m.artworkUrl100, c.MediaCondition, t.MediaType
                                                            FROM Media m
                                                            JOIN MediaCondition c on c.Id = m.MediaConditionId
                                                            JOIN MediaType t on t.Id = m.MediaTypeId
                                                            order by DateAdded Desc");

                return recentItem;
            }
        }

        public ApiResultMovie SearchMediaItemMovie(string term)
        {
            var client = new RestClient("https://itunes.apple.com");

            var request = new RestRequest("search/", Method.GET);
            request.AddParameter("term", term, ParameterType.QueryString); // adds to POST or URL querystring based on Method
            request.AddParameter("entity", "movie", ParameterType.QueryString);
            request.AddParameter("limit", 6, ParameterType.QueryString);

            var response = client.Execute<ApiResultMovie>(request);
            foreach (var result in response.Data.results)
            {
                result.artworkUrl100 = result.artworkUrl100.Replace("100x100bb", "350x350bb");
            }
            return response.Data; // raw content as string

        }

        public ApiResultMusic SearchMediaItemMusic(string term)
        {
            var client = new RestClient("https://itunes.apple.com");

            var request = new RestRequest("search/", Method.GET);
            request.AddParameter("term", term, ParameterType.QueryString); // adds to POST or URL querystring based on Method
            request.AddParameter("entity", "album", ParameterType.QueryString);
            request.AddParameter("limit", 6, ParameterType.QueryString);

            var response = client.Execute<ApiResultMusic>(request);
            foreach (var result in response.Data.results)
            {
                result.artworkUrl100 = result.artworkUrl100.Replace("100x100bb", "350x350bb");
            }
            return response.Data; // raw content as string

        }

        public ApiResultBooks SearchMediaItemBooks(string term)
        {
            var client = new RestClient("https://itunes.apple.com");

            var request = new RestRequest("search/", Method.GET);
            request.AddParameter("term", term, ParameterType.QueryString); // adds to POST or URL querystring based on Method
            request.AddParameter("entity", "ebook", ParameterType.QueryString);
            request.AddParameter("limit", 6, ParameterType.QueryString);

            var response = client.Execute<ApiResultBooks>(request);
            foreach (var result in response.Data.results)
            {
                result.artworkUrl100 = result.artworkUrl100.Replace("100x100bb", "350x350bb");
            }
            return response.Data; // raw content as string
        }

    }
    
}