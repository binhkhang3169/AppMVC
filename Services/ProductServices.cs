using App.Models;

namespace App.Services
{
    public class ProductServices : List<ProductModel>
    {
        public ProductServices()
        {
            this.AddRange(new ProductModel[]{
                new ProductModel(){Id= 1,Name="Apple",Price = 123},
                new ProductModel() {Id=2,Name = "Samsung",Price =456}
            });
        }
    }
}