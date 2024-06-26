﻿namespace ChallengeN5Now.Services.Interfaces
{
    public interface IElasticsearchService
    {
        Task IndexDocument<T>(T document, string id) where T : class;
    }

}
