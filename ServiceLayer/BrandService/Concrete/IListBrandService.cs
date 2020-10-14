using DataLayer.Entities;
using System.Linq;

namespace ServiceLayer.BrandService.Concrete
{
	public interface IListBrandService
	{
		void Add(Brand brand);
		IQueryable<BrandListDto> FilterSortPage(BrandFilterSortPageOptions options);
	}
}