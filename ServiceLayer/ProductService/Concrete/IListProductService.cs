using DataLayer.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceLayer.ProductService.Concrete
{
	public interface IListProductService
	{
		Task<int> AddAsync(Product product);
		Task DeleteByIdAsync(int id);
		IQueryable<ProductListDto> FilterSortPage(ProductFilterSortPageOptions options);
		Task<Product> FindById(int id);
		Task UpdateAsync(Product product);
	}
}