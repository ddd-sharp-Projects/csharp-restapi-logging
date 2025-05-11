

using FileSample.Models;

public class CustomerService : ICustomerService
{
    private readonly List<Customer> _customers = new List<Customer>();
    private int _nextId = 1;

    public ResponseCustomerDto CreateCustomer(CreateCustomerDto customer)
    {
        var newCustomer = new Customer
        {
            Id = _nextId++,
            Name = customer.Name,
            Email = customer.Email,
            Phone = customer.Phone
        };

        _customers.Add(newCustomer);

        return new ResponseCustomerDto
        {
            Name = newCustomer.Name,
            Email = newCustomer.Email,
            Phone = newCustomer.Phone
        };
    }

    // public void DeleteCustomer(int id)
    // {
    //     throw new NotImplementedException();
    // }

    // public Customer GetCustomerById(int id)
    // {
    //     throw new NotImplementedException();
    // }

    // public IEnumerable<Customer> GetCustomers()
    // {
    //     throw new NotImplementedException();
    // }

    // public void UpdateCustomer(Customer customer)
    // {
    //     throw new NotImplementedException();
    // }
}