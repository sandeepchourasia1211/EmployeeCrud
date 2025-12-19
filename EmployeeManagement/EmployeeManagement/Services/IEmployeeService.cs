using EmployeeManagement.Model;

namespace EmployeeManagement.Services
{
    public interface IEmployeeService
    {
        public List<Employee> GetAll();
        public Employee GetById(int id);
        public void Add(Employee emp);
        public void Update(int id, Employee emp);
        public void Delete(int id);
    }
}
