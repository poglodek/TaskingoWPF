using AutoMapper;
using TaskingoApp.Model.User;
using TaskingoApp.Model.WorkTask;

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
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<UserModel, UserCreateModel>().ReverseMap();
                    cfg.CreateMap<WorkTaskModel, WorkTaskCreate>().ReverseMap();
                });
                iMapper = config.CreateMapper();
                _isInitialized = true;
            }
        }
    }
}
