namespace EasyWeather.Service.Mapper
{
    public interface IMapper<O, D>
    {
        public O ToObject(D dto);

        public D ToDto(O obj);
    }
}
