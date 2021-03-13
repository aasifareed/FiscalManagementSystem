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

namespace FiscalManagementSystem.Vehicles
{
    public class VehicleAppService : FiscalManagementSystemAppServiceBase, IVehicleAppService
    {

        public readonly IRepository<Vehicle> _vehicletRepository;

        public VehicleAppService(IRepository<Vehicle> vehicletRepository)
        {
            _vehicletRepository = vehicletRepository;
        }


        public async Task<PagedResultDto<GetVehicleForViewDto>> GetAll(GetAllVehicleInput input)
        {
            var filteredVehicle = _vehicletRepository.GetAll().WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false ||
                                                                        e.CarName
                                                                            .Contains(input.Filter) ||
                                                                        e.Brand.Contains(input.Filter) ||
                                                                        e.Model.Contains(input.Filter) ||
                                                                        e.Number.Contains(input.Filter) ||
                                                                        e.Plate.Contains(input.Filter) ||
                                                                        e.Registration.Contains(input.Filter));

            IQueryable<Vehicle> pagedAndFilteredVehicle;

            if (!string.IsNullOrEmpty(input.Sorting))
                pagedAndFilteredVehicle = filteredVehicle
                    .OrderBy(input.Sorting)
                    .PageBy(input);
            else
                pagedAndFilteredVehicle = filteredVehicle
                    .OrderByDescending(t => t.Id)
                    .PageBy(input);

            var Vehicles = pagedAndFilteredVehicle.Select(o => new GetVehicleForViewDto
            {
                Id = o.Id,
                CarName = o.CarName,
                Model = o.Model,
                Registration = o.Registration,
                Brand = o.Brand,
                Number = o.Number,
                Plate = o.Plate,
                IsActive = o.IsActive

            });

            var totalCount = await filteredVehicle.CountAsync();

            return new PagedResultDto<GetVehicleForViewDto>(
                totalCount,
                await Vehicles.ToListAsync()
            );
        }

        public async Task CreateAsync(CreateVehicleDto input)
        {
            var vehicle = new Vehicle();
            if (input != null)
            {
                vehicle = ObjectMapper.Map<Vehicle>(input);

               await _vehicletRepository.InsertAsync(vehicle);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public async Task<EditVehicleDto> GetEntityByIdAsync(int id)
        {
            var vehicle = await _vehicletRepository.FirstOrDefaultAsync(x => x.Id == id);

            if (vehicle == null)
            {
                throw new EntityNotFoundException(typeof(User), id);
            }

            return ObjectMapper.Map<EditVehicleDto>(vehicle);
        }


        public  async Task UpdateAsync(EditVehicleDto input)
        {
                    var vehicle = await _vehicletRepository.FirstOrDefaultAsync(x => x.Id == input.Id);
                    ObjectMapper.Map(input, vehicle);
              await _vehicletRepository.UpdateAsync(vehicle);
            CurrentUnitOfWork.SaveChanges();
        }

        public  async Task DeleteAsync(EntityDto<int> input)
        {
            var vehicle = await _vehicletRepository.GetAsync(input.Id);
           await _vehicletRepository.DeleteAsync(vehicle);
        }

    }
}
