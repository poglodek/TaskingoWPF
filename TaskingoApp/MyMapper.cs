using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TaskingoApp.Model.User;

namespace TaskingoApp
{
    public static class MyMapper
    {
        private static bool _isInitialized;
        public static IMapper iMapper { get; set; }
        public static void Initialize()
        {
            if (!_isInitialized)
            {
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<UserModel, UserCreateModel>().ReverseMap();
                });
                iMapper = config.CreateMapper();
                _isInitialized = true;
            }
        }
    }
}
