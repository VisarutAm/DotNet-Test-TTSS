using NRedisStack;
using StackExchange.Redis;
using System;

namespace DotNet_Test_TTSS.Data
{
    public class RedisDbContext
    {
        private readonly ConnectionMultiplexer _redis;
        public IDatabase Db { get; }

        public RedisDbContext(IConfiguration configuration)
        {
            var redisConnectionString = configuration.GetConnectionString("Redis") ?? "localhost";
            _redis = ConnectionMultiplexer.Connect(redisConnectionString);
            Db = _redis.GetDatabase();
        }
    }
}
