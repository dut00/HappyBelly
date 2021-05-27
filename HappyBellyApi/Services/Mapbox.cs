using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using HappyBellyApi.Models;
using Microsoft.Extensions.Configuration;

namespace HappyBellyApi.Services
{
    public class Mapbox : IMap
    {
        private readonly string _mapboxToken;
        public readonly IConfiguration _config;

        public Mapbox(IConfiguration configuration)
        {
            _config = configuration;
            _mapboxToken = _config["Mapbox:Token"];
        }

        public Coordinates GetCoordinates(string query)
        {
            string encodedSearchText = HttpUtility.UrlEncode(query);

            string mapboxURLPrefix = "https://api.mapbox.com/geocoding/v5/mapbox.places/";
            string mapboxURLSuffix = $".json?access_token={_mapboxToken}&cachebuster=1615146602409&autocomplete=false&types=address&proximity=18.6238%2C54.3731&bbox=18.47%2C54.3%2C18.75%2C54.60";

            string mapboxURL = mapboxURLPrefix + encodedSearchText + mapboxURLSuffix;

            Debug.WriteLine(mapboxURL);

            //TODO

            return new Coordinates
            {
                Latitude = 1.1d,
                Longitude = 2.2d
            };
        }
    }
}
