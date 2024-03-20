using AutoMapper;
using ISB.Renting.Models;

namespace ISB.Renting.Business.AutoMapper.Resolvers;

public class IdResolver<TSource, TDestination> : IValueResolver<TSource, TDestination, Guid> where TSource : IEntity where TDestination : IEntity
{
    public Guid Resolve(TSource source, TDestination destination, Guid destMember, ResolutionContext context)=> source.Id == Guid.Empty ? Guid.NewGuid() : source.Id;
}
