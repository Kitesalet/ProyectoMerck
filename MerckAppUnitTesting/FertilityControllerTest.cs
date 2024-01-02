using Castle.Core.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Logging;
using Moq;
using ProyectoMerck.Controllers;
using ProyectoMerck.Models;
using ProyectoMerck.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerckAppUnitTesting
{

    [TestClass]
    public class FertilityControllerTest
    {

        [TestMethod]

        public async Task Presentation_Valid()
        {
            //Arrange

            string viewString = "Presentation";

            var loggerMock = new Mock<ILogger<FertilityController>>();

            Mock<IFertilityService> mockService = new Mock<IFertilityService>();

            var controller = new FertilityController(mockService.Object, loggerMock.Object);

            //Act

            var result = controller.Presentation();

            //Assert

            ViewResult actualResult = (ViewResult)result;

            //Checks if the result if ot type ViewResult
            Assert.IsInstanceOfType(result, typeof(ViewResult));

            //Checks if the ViewResult name is the same as the actual result name
            Assert.AreEqual(viewString, actualResult.ViewName);

        }

        [TestMethod]
        public async Task Index_Valid()
        {

            //Arrange

            string viewName = "Index";

            Mock<IFertilityService> mockService = new Mock<IFertilityService>();

            var loggerMock = new Mock<ILogger<FertilityController>>();


            FertilityController controller = new FertilityController(mockService.Object, loggerMock.Object);

            //Act

            var result = controller.Index();

            //Assert

            ViewResult newResult = (ViewResult)result;

            Assert.IsInstanceOfType(newResult, typeof(ViewResult));
            Assert.AreEqual(viewName, newResult.ViewName);

        }

        [TestMethod]
        public async Task Indicator_Valid()
        {

            //Arrange

            string viewName = "Indicator";

            Mock<IFertilityService> mockService = new Mock<IFertilityService>();
            var loggerMock = new Mock<ILogger<FertilityController>>();


            FertilityController controller = new FertilityController(mockService.Object, loggerMock.Object);
            Mock<FertilityVM> mockVM = new Mock<FertilityVM>();

            //Act

            var result = controller.Indicator(mockVM.Object);

            //Assert

            ViewResult newResult = (ViewResult)result;

            Assert.IsInstanceOfType(newResult, typeof(ViewResult));
            Assert.AreEqual(viewName, newResult.ViewName);

        }

        [TestMethod]
        public async Task Information_Valid()
        {

            //Arrange

            string viewName = "Information";

            Mock<IFertilityService> mockService = new Mock<IFertilityService>();
            var loggerMock = new Mock<ILogger<FertilityController>>();

            FertilityController controller = new FertilityController(mockService.Object, loggerMock.Object);
            Mock<FertilityVM> mockVM = new Mock<FertilityVM>();

            //Act

            var result = controller.Information();

            //Assert

            ViewResult newResult = (ViewResult)result;

            Assert.IsInstanceOfType(newResult, typeof(ViewResult));
            Assert.AreEqual(viewName, newResult.ViewName);

        }

        [TestMethod]
        public async Task CalculateFertility_InvalidModelActualAge_ReturnsViewResult()
        {
            // Arrange
            FertilityVM model = new FertilityVM()
            {
                ActualAge = 0,
                FirstAge = 20
            };


            var mockService = new Mock<IFertilityService>();
            var httpContext = new DefaultHttpContext();
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
            tempData["FertError"] = "Hubo un error inesperado!";

            var loggerMock = new Mock<ILogger<FertilityController>>();


            var controller = new FertilityController(mockService.Object, loggerMock.Object)
            {
                TempData = tempData
            };



            controller.ModelState.AddModelError("ActualAge", "Invalid Age");


            // Act
            var result = await controller.CalculateFertility(model);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.AreEqual("Index", ((ViewResult)result).ViewName);
            Assert.AreEqual("Hubo un error inesperado!", controller.TempData["FertError"]);
        }

        [TestMethod]
        public async Task CalculateFertility_InvalidModelFirstAge_ReturnsViewResult()
        {
            // Arrange
            FertilityVM model = new FertilityVM()
            {
                ActualAge = 20,
                FirstAge = 13
            };


            var loggerMock = new Mock<ILogger<FertilityController>>();
            var mockService = new Mock<IFertilityService>();
            var httpContext = new DefaultHttpContext();
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
            tempData["FertError"] = "Hubo un error inesperado!";
            var controller = new FertilityController(mockService.Object, loggerMock.Object)
            {
                TempData = tempData
            };
            controller.ModelState.AddModelError("error", "rror");

            // Act
            var result = await controller.CalculateFertility(model);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.AreEqual("Index", ((ViewResult)result).ViewName);
            Assert.AreEqual("Hubo un error inesperado!", controller.TempData["FertError"]);
        }

        [TestMethod]
        public async Task CalculateFertility_InvalidModel_ReturnsViewResult()
        {
            // Arrange
            FertilityVM model = new FertilityVM()
            {
                ActualAge = 20,
                FirstAge = 0
            };


            var loggerMock = new Mock<ILogger<FertilityController>>();
            var mockService = new Mock<IFertilityService>();
            var httpContext = new DefaultHttpContext();
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
            tempData["FertError"] = "Hubo un error inesperado!";
            var controller = new FertilityController(mockService.Object, loggerMock.Object)
            {
                TempData = tempData
            };
            controller.ModelState.AddModelError("error", "rror");


            // Act
            var result = await controller.CalculateFertility(model);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.AreEqual("Index", ((ViewResult)result).ViewName);
            Assert.AreEqual("Hubo un error inesperado!", controller.TempData["FertError"]);
        }

        [TestMethod]
        public async Task CalculateFertility_InvalidFertCalculation_ReturnAction()
        {
            // Arrange

            var model = new FertilityVM()
            {
                FirstAge = 20,
                ActualAge = 13
            };


            var loggerMock = new Mock<ILogger<FertilityController>>();
            var mockService = new Mock<IFertilityService>();
            var httpContext = new DefaultHttpContext();
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
            tempData["FertError"] = "Las edades ingresadas son invalidas!";
            var controller = new FertilityController(mockService.Object, loggerMock.Object)
            {
                TempData = tempData
            };

            mockService.Setup(service => service.CalculateFertility(model)).Returns(model);

            // Act
            var result = await controller.CalculateFertility(model);

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            Assert.AreEqual("Index", ((RedirectToActionResult)result).ActionName);
        }

        [TestMethod]
        public async Task CalculateFertility_ValidModelState_CalculateFertilityAndRedirectToAction()
        {
            // Arrange

            var model = new FertilityVM()
            {

                FirstAge = 12,
                ActualAge = 30

            };


            var loggerMock = new Mock<ILogger<FertilityController>>();
            var mockService = new Mock<IFertilityService>();
            var httpContext = new DefaultHttpContext();
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
            tempData["FertError"] = "Hubo un error inesperado!";
            var controller = new FertilityController(mockService.Object, loggerMock.Object)
            {
                TempData = tempData
            };

            mockService.Setup(method => method.CalculateFertility(model)).Returns(model);

            // Act
            var result = await controller.CalculateFertility(model);

            // Assert
            Assert.IsNotInstanceOfType(result, typeof(ViewResult));
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            Assert.AreEqual("Indicator", ((RedirectToActionResult)result).ActionName);

        }

        [TestMethod]
        public async Task ConsultFinish_Valid()
        {

            //Arrange

            string viewName = "ConsultFinish";

            Mock<IFertilityService> mockService = new Mock<IFertilityService>();
            var loggerMock = new Mock<ILogger<FertilityController>>();

            FertilityController controller = new FertilityController(mockService.Object, loggerMock.Object);
            Mock<FertilityVM> mockVM = new Mock<FertilityVM>();

            //Act

            var result = controller.ConsultFinish();

            //Assert

            ViewResult newResult = (ViewResult)result;

            Assert.IsInstanceOfType(newResult, typeof(ViewResult));
            Assert.AreEqual(viewName, newResult.ViewName);

        }

        [TestMethod]

        public async Task FertilityController_InvalidMail_ReturnView()
        {

            //Arrange

            var model = new FertilitySubmitVM()
            {

                UserEmail = "",


            };

            var httpContext = new DefaultHttpContext();
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
            tempData["FertError"] = "Ha ocurrido un error!";


            var mockService = new Mock<IFertilityService>();
            var loggerMock = new Mock<ILogger<FertilityController>>();

            mockService.Setup(method => method.GetLists(model)).ReturnsAsync(model);


            var controller = new FertilityController(mockService.Object, loggerMock.Object)
            {
                TempData = tempData
            };

            controller.ModelState.AddModelError("UserEmail", "El email ingresado tiene un formato incorrecto!");
            controller.ModelState.AddModelError("SelectedCountry", "x");
            controller.ModelState.AddModelError("ConsultMotiveMessage", "x");



            //Act

            var result = await controller.Consult(model);
            var newResult = (ViewResult)result;

            //Assert

            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.AreEqual("Clinics", newResult.ViewName);


        }


        [TestMethod]

        public async Task FertilityController_NotSentMail_ReturnView()
        {

            //Arrange

            var model = new FertilitySubmitVM()
            {

                UserEmail = "",


            };

            var httpContext = new DefaultHttpContext();
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
            tempData["FertError"] = "Hubo un error, el email no pudo ser enviado";


            var mockService = new Mock<IFertilityService>();
            var loggerMock = new Mock<ILogger<FertilityController>>();


            mockService.Setup(method => method.GetLists(model)).ReturnsAsync(model);
            mockService.Setup(method => method.ConsultMailAsync(model)).ReturnsAsync(false);

            var controller = new FertilityController(mockService.Object, loggerMock.Object)
            {
                TempData = tempData
            };

            controller.ModelState.AddModelError("UserEmail", "El email ingresado tiene un formato incorrecto!");
            controller.ModelState.AddModelError("SelectedCountry", "x");
            controller.ModelState.AddModelError("ConsultMotiveMessage", "x");



            //Act

            var result = await controller.Consult(model);
            var newResult = (ViewResult)result;

            //Assert

            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.AreEqual("Clinics", newResult.ViewName);


        }

        [TestMethod]

        public async Task FertilityController_Valid_ReturnAction()
        {

            //Arrange

            var model = new FertilitySubmitVM()
            {

                UserEmail = "valid@email.com",               


            };

            var httpContext = new DefaultHttpContext();
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
            tempData["FertError"] = "Hubo un error, el email no pudo ser enviado";


            var mockService = new Mock<IFertilityService>();
            var loggerMock = new Mock<ILogger<FertilityController>>();

            mockService.Setup(method => method.GetLists(model)).ReturnsAsync(model);
            mockService.Setup(method => method.ConsultMailAsync(model)).ReturnsAsync(true);

            var controller = new FertilityController(mockService.Object, loggerMock.Object)
            {
                TempData = tempData
            };




            //Act

            var result = await controller.Consult(model);
            var newResult = (RedirectToActionResult)result;

            //Assert

            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            Assert.AreEqual("ConsultFinish", newResult.ActionName);


        }


        [TestMethod]

        public async Task FertilityController_ClinicsVald_ReturnView()
        {

            //Arrange

            var model = new FertilitySubmitVM();

            var mockService = new Mock<IFertilityService>();
            var loggerMock = new Mock<ILogger<FertilityController>>();

            mockService.Setup(method => method.GetLists(model)).ReturnsAsync(model);

            var controller = new FertilityController(mockService.Object, loggerMock.Object);

            //Act

            var result = await controller.Clinics();
            var newResult = (ViewResult)result;

            //Assert

            Assert.IsTrue(result is ViewResult);
            Assert.AreEqual("Clinics", newResult.ViewName);

        }

    }
}
