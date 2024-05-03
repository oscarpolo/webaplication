using Newtonsoft.Json;
using WebApplication3.Models.Employees;

namespace WebApplication3.Services.Employees
{
    public class EmployeeServices
    {
        private readonly HttpClient _httpClient;

        public EmployeeServices() { 
            _httpClient = new HttpClient();
        }

        public async Task<List<EmployeeViewModel>> AllEmployees()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("https://localhost:7202/Employees/AllEmployess");
            response.EnsureSuccessStatusCode();
            string responseJson = await response.Content.ReadAsStringAsync();
            List<EmployeeViewModel> employeeList = JsonConvert.DeserializeObject< List<EmployeeViewModel>>(responseJson);
            return employeeList;
        }

        public async Task<List<EmployeeViewModel>> EmployeeById(string id)
        {
            HttpResponseMessage resposeMessage = await _httpClient.GetAsync("https://localhost:7202/Employees/EmployessById?id="+id);
            resposeMessage.EnsureSuccessStatusCode();
            string responseJson = await resposeMessage.Content.ReadAsStringAsync();
            List<EmployeeViewModel> employee = JsonConvert.DeserializeObject<List<EmployeeViewModel>>(responseJson);
            return employee;
        }
    }
}
