using System.Collections.Generic;

namespace EShop.Core.DTOS
{
    public class FilterProductDTO
    {
        public List<int> CategoriesIds { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
