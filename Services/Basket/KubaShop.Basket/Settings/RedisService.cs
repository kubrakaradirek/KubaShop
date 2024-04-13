﻿using StackExchange.Redis;

namespace KubaShop.Basket.Settings
{
    public class RedisService
    {
        //Redis tarafındaki konfigürasyonları
        public string _host { get; set; }
        public int _port { get; set; }
        private ConnectionMultiplexer _connectionMultiplexer;//Redise ulaşmak için
        public RedisService(string host, int port)
        {
            _host = host;
            _port = port;
        }
        public void Connect() => _connectionMultiplexer = ConnectionMultiplexer.Connect($"{_host}:{_port}");
        public IDatabase GetDb(int db = 1)=>_connectionMultiplexer.GetDatabase(0);//IDatabase=>Redis paketinden gelir.int db = 1 ilk connection yaptığımızda bir olarak getiriyor.karşılığında 0 olarak getir denir.


    }
}
