using AutoMapper;

namespace StoreSystem.Application.Common.Mappings
{
    public interface IMapWith<T>
    {
        public void Mapping(Profile profile);
    }
}
