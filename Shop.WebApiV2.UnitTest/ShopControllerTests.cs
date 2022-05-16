using AutoFixture.NUnit3;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using Shop.Core.Handlers.Request;
using Shop.WebApiV2.Controllers;
using Shop.WebApiV2.IO.Requests;
using Shop.WebApiV2.IO.Responses;
using Shop.WebApiV2.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Shop.WebApiV2.UnitTests
{
    [TestFixture]
    internal class ShopControllerTests
    {
        private Mock<IMediator> _mediator = new Mock<IMediator>();
        private ShopController _controller;
        private Mock<ILogger<ShopController>> _logger = new Mock<ILogger<ShopController>>();

        [OneTimeSetUp]
        public void SetUp()
        {
            _mediator.Setup(t => t.Send(It.IsAny<GetArticleQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(default(GetArticleQueryResult));

            var mapperConfiguration = new MapperConfiguration(cfg =>
            {

                cfg.AddProfile(new ApiMappingProfile());


            });
            var _mapper = mapperConfiguration.CreateMapper();
            _controller = new ShopController(_logger.Object ,_mediator.Object, _mapper);
        }
        [Test, AutoData]
        public async Task When_GetArticleMethodIsCalled_If_ValidationPasses_And_Article_Exists_Then_ShouldReturn200_AND_CorrectlyMappedArticle(int articleId, string articleName, int articlePrice, string supplierName, int maxPrice, CancellationToken token)
        {

            var coreResponse = new GetArticleQueryResult { Id = articleId, Name = articleName, Price = articlePrice, SupplierName = supplierName };

            var expectedApiArticleResponse = new GetArticleResponse { Id = articleId, Name = articleName, Price = articlePrice, SupplierName = supplierName };

            _mediator.Setup(t => t.Send(It.Is<GetArticleQuery>(t => t.Id == articleId), It.IsAny<CancellationToken>())).ReturnsAsync(coreResponse);


            var response = await _controller.GetArticle(new GetArticleRequest { Id = articleId, MaxExpectedPrice = maxPrice }, token);



            var result = response as OkObjectResult;
            var apiResponseContent = result?.Value as GetArticleResponse;



            var apiResponseContentJson = JsonConvert.SerializeObject(apiResponseContent);
            var expectedApiResponseContentJson = JsonConvert.SerializeObject(expectedApiArticleResponse);

            Assert.AreEqual(apiResponseContentJson, expectedApiResponseContentJson);
        }
        [Test, AutoData]
        public void GetArticleRequest_Validation_Test()
        {
            var request = new GetArticleRequest
            {
                Id = 123,
                MaxExpectedPrice = null
            };
            Assert.IsTrue(Helpers.DataAnnotationValidationTestHelper.ValidateModel(request).Any(
                v => v.MemberNames.Contains("MaxExpectedPrice") &&
                     v.ErrorMessage.Contains("required")));
        }
    }
}

