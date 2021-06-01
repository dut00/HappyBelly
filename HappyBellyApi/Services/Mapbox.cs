using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using HappyBellyApi.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace HappyBellyApi.Services
{
    public class Mapbox : IMap
    {
        private readonly string _mapboxToken;
        private readonly IConfiguration _config;
        private string mapboxURLPrefix = "https://api.mapbox.com/geocoding/v5/mapbox.places/";
        private string mapboxURLSuffix => $".json?access_token={_mapboxToken}&cachebuster=1615146602409&autocomplete=false&types=address&proximity=18.6238%2C54.3731&bbox=18.47%2C54.3%2C18.75%2C54.60";



        public string DataSourceName => "Mapbox - mapbox.com";

        public Mapbox(IConfiguration configuration)
        {
            _config = configuration;
            _mapboxToken = _config["Mapbox:Token"];
        }

        public Coordinates GetCoordinates(string query)
        {
            var response = GetResponse(query);
            dynamic json = JsonConvert.DeserializeObject(response);

            try
            {
                return new Coordinates
                {
                    Latitude = json.features[0].center[0],
                    Longitude = json.features[0].center[1]
                };
            }
            catch (Exception)
            {
                // Is it a good way? hmm..
                return new Coordinates
                {
                    Latitude = 0,
                    Longitude = 0
                };
            }


        }

        private string GetResponse(string query)
        {
            string encodedSearchText = HttpUtility.UrlEncode(query);
            
            string mapboxURL = mapboxURLPrefix + encodedSearchText + mapboxURLSuffix;

            WebRequest request = WebRequest.Create(mapboxURL);
            // Get the response.
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            // Cleanup the streams and the response.
            reader.Close();
            dataStream.Close();
            response.Close();

            return responseFromServer;
        }
    }
}
