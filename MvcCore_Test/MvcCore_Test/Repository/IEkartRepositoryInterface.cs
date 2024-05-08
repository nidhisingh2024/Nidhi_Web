using MvcCore_Test.Models;

namespace MvcCore_Test.Repository
{
    public interface IEkartRepositoryInterface
    {
        Order PlaceOrder(Order newOrder);
        Order GetOrderDetails(int orderId);
        string DisplayBill(int orderId);
        List<Customer> GetCustomersByOrderDate(DateTime orderDate);
        Customer GetCustomerWithHighestOrder();
    }
}
