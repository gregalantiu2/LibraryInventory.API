using AutoMapper;
using LibraryInventory.API.Controllers;
using LibraryInventory.Model.PersonModels;
using LibraryInventory.Model.SharedModels;
using LibraryInventory.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace LibraryInventory.Test.Api
{
    public class EmployeeControllerTests
    {
        private Mock<IEmployeeService> _employeeService;
        private Mock<IMapper> _mapper;
        private EmployeeController _sut;

        public EmployeeControllerTests()
        {
            _employeeService = new Mock<IEmployeeService>();
            _mapper = new Mock<IMapper>();
            _sut = new EmployeeController(_employeeService.Object, _mapper.Object);
        }


        [Fact]
        public async Task GetEmployee_ReturnsOk()
        {
            // Arrange
            var employeeId = "123";

            var contactInfo = new ContactInfo(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>());
            var employeeType = new EmployeeType(It.IsAny<string>(), It.IsAny<int>());
            var employee = new Employee("Greg", "Tiu", contactInfo, "123", employeeType);

            _employeeService.Setup(x => x.GetEmployeeAsync(employeeId)).ReturnsAsync(employee);

            // Act
            var result = await _sut.GetEmployee(employeeId);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
