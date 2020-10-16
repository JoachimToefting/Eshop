using System.Linq;
using System.Threading.Tasks;

namespace ServiceLayer.BrandService.Concrete
{
	public interface IListBrandService
	{
		Task<int> AddAsync(BrandEditDto brandEditDto);
		Task<int> DeleteByIDAsync(int id);
		IQueryable<BrandListDto> FilterSortPage(BrandFilterSortPageOptions options);
		Task<BrandEditDto> FindEditDtoByIDAsync(int id);
		Task<int> UpdateAsync(BrandEditDto brandEditDto);
	}
}