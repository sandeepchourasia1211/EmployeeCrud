using EmployeeManagement.Model;

namespace EmployeeManagement.Repositories
{
    public interface IEmployeeRepository
    {
        public List<Employee> GetAll();
        public Employee GetById(int id);
        public void Add(Employee employee);
        public void Update(int id, Employee employee);
        public void Delete(int id);
    }
}
