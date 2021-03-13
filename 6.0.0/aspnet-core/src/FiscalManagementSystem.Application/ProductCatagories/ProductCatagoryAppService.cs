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
using FiscalManagementSystem.ProductCatagoriesPictures;

namespace FiscalManagementSystem.ProductCatagories
{
    public class ProductCatagoryAppService : FiscalManagementSystemAppServiceBase, IProductCatagoryAppService
    {

        public readonly IRepository<ProductCatagory> _productCatagoryRepository;

        public readonly IRepository<ProductCatagoryPictures> _productCatagoryPicturesRepository;
        public ProductCatagoryAppService(IRepository<ProductCatagory> productCatagoryRepository,
            IRepository<ProductCatagoryPictures> productCatagoryPicturesRepository)
        {
            _productCatagoryRepository = productCatagoryRepository;
            _productCatagoryPicturesRepository = productCatagoryPicturesRepository;
        }


        public async Task<PagedResultDto<GetProductCatagoryForViewDto>> GetAll(GetAllProductCatagoryInput input)
        {
            var filteredProductCatagory= _productCatagoryRepository.GetAll().WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false ||
                                                                        e.Name
                                                                            .Contains(input.Filter) ||
                                                                        e.Description.Contains(input.Filter));

            IQueryable<ProductCatagory> pagedAndFilteredProductCatagory;

            if (!string.IsNullOrEmpty(input.Sorting))
                pagedAndFilteredProductCatagory = filteredProductCatagory
                    .OrderBy(input.Sorting)
                    .PageBy(input);
            else
                pagedAndFilteredProductCatagory = filteredProductCatagory
                    .OrderByDescending(t => t.Id)
                    .PageBy(input);

            var ProductCatagory = pagedAndFilteredProductCatagory.Select(o => new GetProductCatagoryForViewDto
            {
                Id = o.Id,
                Name = o.Name,
                Description = o.Description,
                CatagoryNumber=o.CatagoryNumber,
                IsActive=o.IsActive,
                fileInByte = _productCatagoryPicturesRepository.GetAll().Where(x => x.ProductCatagoryId == o.Id).Select(y => y.file).SingleOrDefault(),
            });

            var totalCount = await filteredProductCatagory.CountAsync();

            return new PagedResultDto<GetProductCatagoryForViewDto>(
                totalCount,
                await ProductCatagory.ToListAsync()
            );
        }

        public async Task<int> CreateAsync(CreateProductCatagoryDto input)
        {
            var ProductCatagory = new ProductCatagory();
            if (input != null)
            {
                ProductCatagory = ObjectMapper.Map<ProductCatagory>(input);

               await _productCatagoryRepository.InsertAsync(ProductCatagory);
                CurrentUnitOfWork.SaveChanges();
            }

            return ProductCatagory.Id;
        }

        public async Task<EditProductCatagoryDto> GetEntityByIdAsync(int id)
        {
            var productCatagory = await _productCatagoryRepository.FirstOrDefaultAsync(x => x.Id == id);

            if (productCatagory == null)
            {
                throw new EntityNotFoundException(typeof(User), id);
            }

            return ObjectMapper.Map<EditProductCatagoryDto>(productCatagory);
        }


        public  async Task UpdateAsync(EditProductCatagoryDto input)
        {
                    var productCatagory = await _productCatagoryRepository.FirstOrDefaultAsync(x => x.Id == input.Id);
                    ObjectMapper.Map(input, productCatagory);
              await _productCatagoryRepository.UpdateAsync(productCatagory);
            CurrentUnitOfWork.SaveChanges();
        }

        public  async Task DeleteAsync(EntityDto<int> input)
        {
            var vehicle = await _productCatagoryRepository.GetAsync(input.Id);
           await _productCatagoryRepository.DeleteAsync(vehicle);
        }

    }
}
