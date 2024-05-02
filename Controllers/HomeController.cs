using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using NetflixClone.Models;
using static System.Net.WebRequestMethods;

namespace NetflixClone.Controllers
{
    public class HomeController : Controller
    {
        //private Model1 db = new Model1();
        public ActionResult Index()
        {
            // Kết nối với cơ sở dữ liệu SQL Server
            string connectionString = "data source=DESKTOP-2NFPMCV;initial catalog=movieweb;integrated security=True;trustservercertificate=True;MultipleActiveResultSets=True;App=EntityFramework";
            string genreQuery = "SELECT \r\n    [genres_series].[serieID],\r\n    STRING_AGG([genreName], ',') AS genres\r\nFROM \r\n    [movieweb].[genres_series] join [movieweb].[genre] on [movieweb].[genre].[genreID] = [movieweb].[genres_series].[genreID]\r\nGROUP BY \r\n    [genres_series].[serieID]\r\nunion\r\nSELECT \r\n    [genres_movies].[movieID],\r\n    STRING_AGG([genreName], ',') AS genres\r\nFROM \r\n    [movieweb].[genres_movies] join [movieweb].[genre] on [movieweb].[genre].[genreID] = [movieweb].[genres_movies].[genreID]\r\nGROUP BY \r\n    [genres_movies].[movieID];";
            string query = "SELECT [serieID] as 'id',[serieName] as 'serieName'   \r\n,[status],[tagline],[popularity],[posterPath],[backdropPath],[trailer],[tags] ,[adult],[numberOfSeasons],[overview] \r\nFROM [movieweb].[series]  where serieID > 0  UNION \r\nSELECT  [movieID] as 'id',[movieName] as 'serieName'\r\n,[status],[tagline],[popularity],[posterPath],[backdropPath],[trailer],[tags],[adult],1,[overview]\r\nFROM [movieweb].[movie] where movieID > 0";
            string topquery = "select  top (1)  * from [movieweb].series\r\nwhere serieID>0";

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            // Truy vấn SQL để lấy dữ liệu string query =
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            List<series> serie = new List<series>();
            SqlCommand genreCommand = new SqlCommand(genreQuery, connection);
            //SqlDataReader reader2 = command.ExecuteReader();

            while (reader.Read())
            {
                series serieAdd = new series();
                // movie.Id = Convert.ToInt32(reader["Id"]);
                serieAdd.serieID = int.Parse(reader["id"].ToString());
                serieAdd.serieName = reader["serieName"].ToString();
                serieAdd.posterPath = "https://image.tmdb.org/t/p/w500" + reader["posterPath"].ToString();
                
                if (reader["adult"].ToString() == "0") serieAdd.adult = "18+";
                if (int.TryParse(reader["numberOfSeasons"].ToString(), out int z)) serieAdd.numberOfSeasons = int.Parse(reader["numberOfSeasons"].ToString());
                else serieAdd.numberOfSeasons = 0;
                //serieAdd.Description = reader["Description"].ToString();
                //'https://image.tmdb.org/t/p/w500'${movie.poster_path}

                // Đọc và gán các thuộc tính khác của phim nếu cần
                serie.Add(serieAdd);
            }
            
            SqlDataReader reader2 = genreCommand.ExecuteReader();
            while (reader2.Read())
            {
                foreach(var p in serie)
                {
                    if (p.serieID == int.Parse(reader2["serieID"].ToString())) p.genreID = reader2["genres"].ToString();
                }
            }
            ViewBag.Entries = serie;
            reader.Close(); 
            reader2.Close();
            command = new SqlCommand(topquery, connection);
            connection.Close();
            return View(serie);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}