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
            string genreQuery = 
                "SELECT [genres_series].[serieID], " +
                "STRING_AGG([genreName], ',') AS genres " +
                "FROM [movieweb].[genres_series] join [movieweb].[genre] on [movieweb].[genre].[genreID] = [movieweb].[genres_series].[genreID] " +
                "GROUP BY [genres_series].[serieID] " +
                "union SELECT [genres_movies].[movieID], " +
                "STRING_AGG([genreName], ',') AS genres " +
                "FROM [movieweb].[genres_movies] join [movieweb].[genre] on [movieweb].[genre].[genreID] = [movieweb].[genres_movies].[genreID] " +
                "GROUP BY [genres_movies].[movieID];";
            string query = 
                "SELECT [serieID] as 'id',[serieName] as 'serieName' ,[status],[tagline],[popularity],[posterPath],[backdropPath],[trailer],[tags] ,[adult],[numberOfSeasons],[overview] " +
                "FROM [movieweb].[series]  where serieID > 0  " +
                "UNION " +
                "SELECT [movieID] as 'id',[movieName] as 'serieName',[status],[tagline],[popularity],[posterPath],[backdropPath],[trailer],[tags],[adult],1,[overview] " +
                "FROM [movieweb].[movie] where movieID > 0";
            
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            // Truy vấn SQL để lấy dữ liệu string query =
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            List<series> serie = new List<series>();
            
            //SqlDataReader reader2 = command.ExecuteReader();

            while (reader.Read())
            {
                series serieAdd = new series();
                serieAdd.serieID = int.Parse(reader["id"].ToString());
                serieAdd.serieName = reader["serieName"].ToString();
                serieAdd.posterPath = "https://image.tmdb.org/t/p/w500" + reader["posterPath"].ToString();
                
                if (reader["adult"].ToString() == "0") serieAdd.adult = "18+";
                else serieAdd.adult = "All age";
                if (int.TryParse(reader["numberOfSeasons"].ToString(), out int z)) serieAdd.numberOfSeasons = int.Parse(reader["numberOfSeasons"].ToString());
                else serieAdd.numberOfSeasons = 0;
                // Đọc và gán các thuộc tính khác của phim nếu cần
                serie.Add(serieAdd);
            }
            reader.Close();
            command = new SqlCommand(genreQuery, connection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                foreach(var p in serie)
                {
                    if (p.serieID == int.Parse(reader["serieID"].ToString())) p.genreID = reader["genres"].ToString();
                }
            }

            reader.Close();
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