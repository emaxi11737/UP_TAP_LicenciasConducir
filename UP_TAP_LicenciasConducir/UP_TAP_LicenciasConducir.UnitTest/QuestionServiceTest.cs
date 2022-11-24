using Microsoft.Extensions.Options;
using Moq;
using UP_TAP_LicenciasConducir.Core.CustomEntities;
using UP_TAP_LicenciasConducir.Core.Entities;
using UP_TAP_LicenciasConducir.Core.Interfaces;
using UP_TAP_LicenciasConducir.Core.Services;
using UP_TAP_LicenciasConducir.Core.Utilities;
using UP_TAP_LicenciasConducir.Core.Utilities.Interfaces;

namespace UP_TAP_LicenciasConducir.UnitTest
{
    [TestClass]
    public class QuestionServiceTest
    {
        private Mock<IUnitOfWork> _unitOfWork;
        private IUtilityService _utilityService;
        private IOptions<PaginationOptions> options;

        [TestInitialize]
        public void Inicializar()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _utilityService = new UtilityService();
            options = Options.Create<PaginationOptions>(new PaginationOptions());

            SetupRepositories();

        }

        public QuestionService GetService()
        {
            return new QuestionService(_unitOfWork.Object, options, _utilityService);
        }

        private void SetupRepositories()
        {
            var prueba = new Question
            {
                Id = 1,
                Description = "test"
            };
            _unitOfWork.Setup(x => x.QuestionRepository.GetById(It.IsAny<int>())).Returns(Task.FromResult(prueba));
        }

        [TestMethod]
        public void GetQuestion_Exito()
        {
            var service = GetService();

            try
            {
                var question = service.GetQuestion(1);
                Assert.AreEqual(question.Result.Description, "test");
                Assert.IsNotNull(question);
            }
            catch (Exception)
            {
                Assert.Fail();
            }



        }
    }
}