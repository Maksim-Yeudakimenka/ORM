using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ORM.EF.Context;

namespace TestApp
{
  [TestClass]
  public class SelectionTests
  {
    [TestMethod]
    public void GetOrdersHavingProductsOfSpecificCategory()
    {
      using (var db = new NorthwindContext())
      {
        var categoryId = db.Categories.First().CategoryID;
        var orders = db.Orders.Where(o => o.Order_Details.Any(d => d.Product.Category.CategoryID == categoryId));

        foreach (var order in orders)
        {
          Console.WriteLine($"Order id: {order.OrderID} | Customer: {order.Customer.CompanyName}");

          foreach (var orderDetail in order.Order_Details)
          {
            Console.WriteLine($"Product: {orderDetail.Product.ProductName}");
          }

          Console.WriteLine();
        }
      }
    }
  }
}