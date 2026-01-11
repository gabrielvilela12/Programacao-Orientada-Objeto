using Microsoft.AspNetCore.Mvc;
using PrimeiraAPI.Model;
using PrimeiraAPI.ViewModal;

namespace PrimeiraAPI.Controllers
{
    [ApiController]
    [Route("api/v1/employee")]
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpPost]
        public IActionResult Add([FromForm] EmployeeViewModel employeeView)
        {

            var filePath = Path.Combine("Storage", employeeView.Photo.FileName);

            using Stream fileStream = new FileStream(filePath, FileMode.Create);
            employeeView.Photo.CopyTo(fileStream);

            var employee = new Employee(employeeView.Name, employeeView.Age, filePath);

            _employeeRepository.Add(employee);
            return Ok();
        }

        [HttpPost]
        [Route("{id}/dowload")]
        public IActionResult DowloadPhoto(int id)
        {
            var employee = _employeeRepository.GetId(id);

            var dataBytes = System.IO.File.ReadAllBytes(employee.photo);

            return File(dataBytes, "image/png");
        }






        [HttpGet]
        public IActionResult Get()
        {
            var employess = _employeeRepository.Get();
            return Ok(employess);
        }
    }
}
