using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudHRMS.Models.DataModels;
using CloudHRMS.Models.ViewModels;
using CloudHRMS.Repositories.Domain;
using CloudHRMS.Services;
using CloudHRMS.UnitOfWorks;
using Moq;

namespace CloudHRMS.UnitTests.Domains
{
    public class PositionServiceUnitTest
    {
        //create all of the mock projects
        private Mock<IPositionService> positionServiceMock = new Mock<IPositionService>();
        private Mock<IUnitOfWork> unitOfWorkMock = new Mock<IUnitOfWork>();
        private Mock<IPositionRepository> positionRepositoryMock = new Mock<IPositionRepository>();
        [Fact]
        public void ShouldCreateSuccess()
        {
            //1 Arrange
            var expectedPositionViewModel = new PositionViewModel
            {
                Code = "HR",
                Description = "Description",
                Level = 1
            };
            var positionEntity = new PositionEntity()
            {
                Id = "1",
                Code = expectedPositionViewModel.Code,
                Description = expectedPositionViewModel.Description,
                Level = expectedPositionViewModel.Level,
                CreatedAt = DateTime.Now,
                CreatedBy = "Test",
                Ip="127.0.0.1",
                IsActive = true,
            };
            positionRepositoryMock.Setup(r => r.Create(positionEntity));
            unitOfWorkMock.Setup(u => u.PositionRepository.Create(positionEntity));

            //2 Action
            var positionService = new PositionService(unitOfWorkMock.Object);

            //3 Assert
            var actualResult = positionService.Create(expectedPositionViewModel);
            Assert.Equal(expectedPositionViewModel, actualResult);

        }
        [Fact]
        public void ShouldCreateFail()
        {
            //1 Arrange
            var expectedPositionViewModel = new PositionViewModel
            {
                Code = "HR",
                Description = "Description",
                Level = 1
            };
            var positionEntity = new PositionEntity()
            {
                Id = "1",
                Code = "Cloud",
                Description = expectedPositionViewModel.Description,
                Level = expectedPositionViewModel.Level,
                CreatedAt = DateTime.Now,
                CreatedBy = "Test",
                Ip = "127.0.0.1",
                IsActive = true,
            };
            positionRepositoryMock.Setup(r => r.Create(It.IsAny<PositionEntity>())).Throws(new Exception("CReation Fails!!"));
            unitOfWorkMock.Setup(u => u.PositionRepository).Returns(positionRepositoryMock.Object);

            //2 Action
            var positionService = new PositionService(unitOfWorkMock.Object);
            //3 Assert
            Assert.Throws<Exception>(() => positionService.Create(expectedPositionViewModel));

        }
    }
}
