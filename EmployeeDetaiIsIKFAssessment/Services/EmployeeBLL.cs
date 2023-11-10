using EmployeeDetaiIsIKFAssessment.DalLayer;
using WebApplication1.Models;

namespace EmployeeDetaiIsIKFAssessment.Services
{
    public class EmployeeBLL
    {
        private readonly EmployeeDAL employeeDAL;

        public EmployeeBLL(EmployeeDAL employeeDAL)
        {
            this.employeeDAL = employeeDAL;
        }
        

        public List<Employee> GetEmployees()
        {
            return employeeDAL.GetEmployees();
        }

        public Employee GetEmployees(int id)
        {
            return employeeDAL.GetEmployees(id);
        }


        public void AddEmployee(Employee employee)
        {
            // Additional business logic/validation can be added here
            employeeDAL.AddEmployee(employee);
        }

        // Similarly, implement Update and Delete methods
        public void UpdateEmployee(Employee employee)
        {
            // Additional business logic/validation can be added here
            employeeDAL.UpdateEmployee(employee);
        }

        public void DeleteEmployee(int employeeId)
        {
            // Additional business logic/validation can be added here
            employeeDAL.DeleteEmployee(employeeId);
        }
    }

}
