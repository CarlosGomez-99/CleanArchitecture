﻿using Dapper;
using StreamCasa.Entities;
using StreamCasa.Entities.Abstractions.Repositories.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamCasa.Repository.Dapper
{
    public class QueryVideosRepository : IQueryVideosRepository
    {
        private readonly Connection connection;

        public QueryVideosRepository(Connection connection)
        {
            this.connection = connection;
        }

        public async Task<List<Videos>> GetAllVideosByTitle(string Title)
        {
            var dictionary = new Dictionary<string, object>()
            {
                {
                    "@Title", Title
                }
            };
            string Query = "select * from videos where title = @Title";
            var parameters = new DynamicParameters(dictionary);
            var response = await connection.SqlConnection.QueryAsync<Videos>(Query, parameters);
            return response.ToList();
        }
    }
}
