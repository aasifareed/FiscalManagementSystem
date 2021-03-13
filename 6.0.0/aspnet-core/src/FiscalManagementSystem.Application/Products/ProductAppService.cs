using Abp.Application.Services.Dto;
using Abp.Auditing;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using FiscalManagementSystem.Vehicles.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;
using Abp.Authorization;
using FiscalManagementSystem.Authorization.Users;
using FiscalManagementSystem.Authorization.Roles;
using Abp.Domain.Entities;
using FiscalManagementSystem.ProductCatagories.Dto;
using FiscalManagementSystem.Products;
using FiscalManagementSystem.Products.Dto;
using FiscalManagementSystem.ProductPictures;
using System.IO;
using System.Drawing;
using Microsoft.AspNetCore.Http;

namespace FiscalManagementSystem.ProductCatagories
{
    public class ProductAppService : FiscalManagementSystemAppServiceBase, IProductAppService
    {
        public readonly IRepository<Product> _productRepository;
        public readonly IRepository<ProductCatagory> _productCatagoryRepository;
        public readonly IRepository<ProductPicture> _productPictureRepository;

        public ProductAppService(IRepository<Product> productRepository,
            IRepository<ProductCatagory> productCatagoryRepository,
            IRepository<ProductPicture> productPictureRepository)
        {
            _productRepository = productRepository;
            _productCatagoryRepository = productCatagoryRepository;
           _productPictureRepository= productPictureRepository;
        }


        public async Task<PagedResultDto<GetProductForViewDto>> GetAll(GetAllProductInput input)
        {
            var filteredProduct= _productRepository.GetAll().WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false ||
                                                                        e.Name.Contains(input.Filter) ||
                                                                        e.Brand.Contains(input.Filter) ||
                                                                        e.Color.Contains(input.Filter));


            IQueryable<Product> pagedAndFilteredProduct;

            if (!string.IsNullOrEmpty(input.Sorting))
                pagedAndFilteredProduct = filteredProduct
                    .OrderBy(input.Sorting)
                    .PageBy(input);
            else
                pagedAndFilteredProduct = filteredProduct
                    .OrderByDescending(t => t.Id)
                    .PageBy(input);

            var Products = pagedAndFilteredProduct.Select(o => new GetProductForViewDto
            {
                Id = o.Id,
                Name = o.Name,
                Brand = o.Brand,
                Quantity = o.Quantity,
                Color = o.Color,
                Price = o.Price,
                ProductCatagoryId = o.ProductCatagoryId,
                ProductCatagory = _productCatagoryRepository.GetAll().Where(x => x.Id == o.ProductCatagoryId).Select(y => y.Name).SingleOrDefault(),
                fileInByte = _productPictureRepository.GetAll().Where(x => x.ProductId == o.Id).Select(y =>y.file).SingleOrDefault(),
            });
      
            var totalCount = await filteredProduct.CountAsync();

            return new PagedResultDto<GetProductForViewDto>(
                totalCount,
                await Products.ToListAsync()
            );
        }

        public async Task<int> CreateAsync(CreateProductDto input)
        {
            var product = new Product();

                product = ObjectMapper.Map<Product>(input);

               await _productRepository.InsertAsync(product);
                CurrentUnitOfWork.SaveChanges();

            return product.Id;
        }

        public async Task<EditProductDto> GetEntityByIdAsync(int id)
        {
            var productCatagory = await _productRepository.FirstOrDefaultAsync(x => x.Id == id);

            if (productCatagory == null)
            {
                throw new EntityNotFoundException(typeof(User), id);
            }

            return ObjectMapper.Map<EditProductDto>(productCatagory);
        }


        public  async Task UpdateAsync(EditProductDto input)
        {
                    var product = await _productRepository.FirstOrDefaultAsync(x => x.Id == input.Id);
                    ObjectMapper.Map(input, product);
              await _productRepository.UpdateAsync(product);
            CurrentUnitOfWork.SaveChanges();
        }

        public  async Task DeleteAsync(EntityDto<int> input)
        {
            var product = await _productRepository.GetAsync(input.Id);
           await _productRepository.DeleteAsync(product);
        }

        public async Task<List<GetProductCatagoryForDropDownDto>> GetProdcutCatagories()
        {
            return await _productCatagoryRepository.GetAll()
                .Select(x=>new GetProductCatagoryForDropDownDto { 
                ProductCatagoryId=x.Id,
                Name=x.Name
                }).ToListAsync();
        }


        public async Task<List<GetAllProductForSaleDto>> GetAllProdcutsForSale()
        {
            try
            {
                return await _productRepository.GetAll()
                    .Select(x => new GetAllProductForSaleDto
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Category = _productCatagoryRepository.GetAll().Where(o => o.Id == x.ProductCatagoryId).Select(y => y.Name).SingleOrDefault(),
                        ImageInByte = _productPictureRepository.GetAll().Where(o => o.ProductId == x.Id).Select(y => y.file).SingleOrDefault(),
                        Quantity = x.Quantity,
                        Price = x.Price,
                        Size = x.size,
                        Brand = x.Brand,
                        Color = x.Color,
                        Date = x.date
                    }).ToListAsync();
            }
            catch (Exception ex)
            {

                throw;
            }

        }

    }
}
