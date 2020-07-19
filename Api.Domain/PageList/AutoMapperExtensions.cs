using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace Domain.PageList
{
    public static class AutoMapperExtensions
    {
        public static PagedList<TDestination> MapList<TSource, TDestination>(this IMapper mapper, PagedList<TSource> source)
        {
            return new PagedList<TDestination>(mapper.Map<List<TDestination>>(source),source.Count,source.CurrentPage,source.PageSize);;
        }
    }
}