using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HappyBellyApi.Models;

namespace HappyBellyApi.Services
{
    public interface IMap
    {
        Coordinates GetCoordinates(string address);
    }
}
