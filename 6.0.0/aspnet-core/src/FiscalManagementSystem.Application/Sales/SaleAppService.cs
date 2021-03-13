using Abp.Domain.Repositories;
using FiscalManagementSystem.OrderProducts;
using FiscalManagementSystem.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiscalManagementSystem.Sales
{
    public class SaleAppService:FiscalManagementSystemAppServiceBase,ISaleAppService
    {
        public readonly IRepository<Sale> _saleRepository;
        public readonly IRepository<OrderProduct> _orderProductRepository;
        public readonly IRepository<Order> _orderRepository;
        public SaleAppService(IRepository<Sale> saleRepository,
            IRepository<OrderProduct> orderProductRepository,
            IRepository<Order> orderRepository)
        {
            _saleRepository = saleRepository;
            _orderProductRepository = orderProductRepository;
            _orderRepository = orderRepository;
        }

    }
}
