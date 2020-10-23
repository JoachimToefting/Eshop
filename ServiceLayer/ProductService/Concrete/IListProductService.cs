using System.Linq;
using System.Threading.Tasks;

namespace ServiceLayer.ProductService.Concrete
{
	public interface IListProductService
	{
		Task<int> AddAsync(ProductEditDto product);
		Task DeleteByIdAsync(int id);
		IQueryable<ProductListDto> FilterSortPage(ProductFilterSortPageOptions options);
		Task<ProductEditDto> FindEditByIdAsync(int id);
		Task<ProductListDto> FindListByIdAsync(int id);
		Task UpdateAsync(ProductEditDto product);
	}
}