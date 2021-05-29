using System;
using System.Collections.Generic;
using System.Linq;
using WorkApp.Common.Enums;
using WorkApp.Common.Interfaces;

namespace WorkApp.Common.DTOs
{
    public class Result<T> : IResult<T>
    {
        public Result()
        {
            Errors = new List<string>();
        }

        public Result(T entity)
        {
            Errors = new List<string>();
            Data = entity;
        }

        public Result(Exception ex, ExceptionLocations location)
        {
            Errors = new List<string>();
            Errors.Add(ex.Message);
            ErrorLocation = location.ToString();
        }

        public Result(Exception ex, ExceptionLocations location, T entity)
        {
            Errors = new List<string>();
            Errors.Add(ex.Message);
            Data = entity;
            ErrorLocation = location.ToString();
        }

        public bool HasError => Errors.Any();


        public List<string> Errors { get; set; }

        public string ErrorLocation { get; set; }


        public T Data { get; set; }

        private void Log()
        {
            // log the error
        }

    }
}
