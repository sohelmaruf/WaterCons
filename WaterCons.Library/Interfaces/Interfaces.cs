﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterCons.Library.Models;

namespace WaterCons.Library.Interfaces
{
  
    /// <summary>
    /// IDataService
    /// </summary>
    public interface IDataService
    {
        void CreateSession();
        void BeginTransaction();
        void CommitTransaction(Boolean closeSession);
        void RollbackTransaction(Boolean closeSession);
        void CloseSession();
    }
    

    ///// <summary>
    ///// ICustomers DataService
    ///// </summary>
    //public interface ICustomersDataService : IDataService, IDisposable
    //{       
    //    void CreateCustomer(customer customer);
    //    void UpdateCustomer(customer customer);
    //    Boolean ValidateDuplicateCustomer(string customerCode);
    //    Boolean ValidateDuplicateCustomer(Guid customerID, string customerCode);
    //    List<Customer> CustomerInquiry(string customerCode, string companyName, DataGridPagingInformation paging, out TransactionalInformation transaction);
    //    Customer GetCustomer(Guid customerID);
    //}

    ///// <summary>
    ///// IProducts DataService
    ///// </summary>
    //public interface IProductsDataService : IDataService, IDisposable
    //{
    //    void CreateProduct(Product product);
    //    void UpdateProduct(Product product);
    //    Boolean ValidateDuplicateProduct(string productCode);
    //    Boolean ValidateDuplicateProduct(Guid productID, string productCode);
    //    List<Product> ProductInquiry(string productCode, string description, DataGridPagingInformation paging, out TransactionalInformation transaction);
    //    Product GetProduct(Guid productID);
    //}

    ///// <summary>
    ///// IOrders Data Service
    ///// </summary>
    //public interface IOrdersDataService : IDataService, IDisposable
    //{
    //    void CreateOrder(Order order);
    //    void UpdateOrder(Order order);
    //    List<Shipper> GetShippers();
    //    Order GetOrder(int orderID);
    //    List<OrderInquiry> OrderInquiry(string customerCode, string companyName, DataGridPagingInformation paging, out TransactionalInformation transaction);   
    //    void CreateOrderDetailLineItem(OrderDetail orderDetail);
    //    void UpdateOrderDetailLineItem(OrderDetail orderDetail);
    //    List<OrderDetails> GetOrderDetails(long orderID);
    //    void DeleteOrderDetailLineItem(Guid orderDetailID);
    //}


}
