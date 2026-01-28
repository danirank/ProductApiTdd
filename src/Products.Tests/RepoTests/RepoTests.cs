using Entities;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace Products.Tests.RepoTests
{
    public class RepoTests
    {
        private static TestContext CreateContext()
        {
            var options = new DbContextOptionsBuilder<TestContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            return new TestContext(options);
        }

        #region GetTests


        [Fact]
        public async Task GetProduct_WhenProductExist_ReturnsProduct()
        {
            //Given/Arrange
            using var context = CreateContext();

            await context.Products.AddAsync(new Product("Iphone", 199));
            await context.SaveChangesAsync();

            var repo = new ProductRepo(context);

            //act 
            var result = await repo.GetByIdAsync(1);


            //Assert 

            result.Name.Should().Be("Iphone");




        }

        [Fact]
        public async Task GetProduct_WhenProductMissing_ReturnNull()
        {
            //Given/Arrange
            using var context = CreateContext();
            var product = new Product("Iphone", 199);
            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();

            var repo = new ProductRepo(context);

            //act 
            var result = await repo.GetByIdAsync(product.ProductId + 1);


            //Assert 

            result.Should().BeNull();



        }


        [Fact]
        public async Task GetProducts_ReturnsAllProducts()
        {
            //Given
            using var context = CreateContext();

            var list = new List<Product>()
            {
                new Product("Iphone",199),
                new Product("Samsung",299),
                new Product("Toblerone",199)
            };

            await context.AddRangeAsync(list);
            await context.SaveChangesAsync();

            var repo = new ProductRepo(context);

            //Act 

            var result = await repo.GetAllAsync();

            //Assert 

            result.Count.Should().Be(3);
            result.Should().Contain(p => p.Name == "Samsung");
        }


        [Fact]
        public async Task AddProduct_ShouldReturn_CreatedProduct()
        {
            //Given 
            using var context = CreateContext();
            var entity = new Product("Iphone", 122);

            var repo = new ProductRepo(context);

            //Act


            var created = await repo.AddAsync(entity);
            //Assert 

            created.ProductId.Should().BeGreaterThan(0);
            created.Name.Should().Be("Iphone");

        }

        [Fact]
        public async Task AddProduct_InvalidEntiity_ShouldBeNull()
        {
            using var context = CreateContext();
            Product? entity = null;

            var repo = new ProductRepo(context);

            //Act

            var result = await repo.AddAsync(entity);


            //Assert 


            result.Should().BeNull();


        }

        #endregion
    }

    public class ProductRepo
    {

        private readonly TestContext _context;

        public ProductRepo(TestContext context)
        {
            _context = context;
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            var result = await _context.Products.FindAsync(id);

            return result;

        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> AddAsync(Product product)
        {
            if (product is null)
                return null;


            await _context.Products.AddAsync(product);
            var res = await _context.SaveChangesAsync();

            return product;

        }
    }
}
