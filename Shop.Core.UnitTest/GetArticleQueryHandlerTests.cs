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
using Shop.Core.Providers;
using Shop.Core.Caching;
using Shop.Core.Mappers;

namespace Shop.Core.UnitTests
{
    [TestFixture]
    internal class GetArticleQueryHandlerTests
    {
        private Mock<IArticleProvider> _articleProviderMock = new Mock<IArticleProvider>();
        private GetArticleQueryHandler _handler;
        private Mock<ILogger<GetArticleQueryHandler>> _loggerMock = new Mock<ILogger<GetArticleQueryHandler>>();
        private Mock<ICacheService<GetArticleQueryResult>> _cacheServiceMock = new Mock<ICacheService<GetArticleQueryResult>>();

        [OneTimeSetUp]
        public void SetUp()
        {
            _articleProviderMock.Setup(t => t.GetArticle(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<CancellationToken>())).ReturnsAsync(default(GetArticleProviderResponse));

            var mapperConfiguration = new MapperConfiguration(cfg =>
            {

                cfg.AddProfile(new ArticleProviderProfile());


            });
            var _mapper = mapperConfiguration.CreateMapper();
            _handler = new GetArticleQueryHandler(_cacheServiceMock.Object,_articleProviderMock.Object, _mapper);
        }
        [Test, AutoData]
        public async Task When_GetArticleQueryHandlerIsCalled_If_Article_Exists_In_Cache_Should_ReturnCachedArticle(int articleId, string articleName, int articlePrice, string supplierName, int maxPrice, CancellationToken token)
        {
            GetArticleQueryResult cachedResult = new GetArticleQueryResult { Id = articleId, Name = articleName, Price = maxPrice, SupplierName = supplierName };
            string articleKey = $"{nameof(GetArticleQueryResult)}{articleId}";
            _cacheServiceMock.Setup(t=>t.Get(It.Is<string>( t=> t.Equals(articleKey)))).Returns(cachedResult);

            var result = await _handler.Handle(new GetArticleQuery { Id = articleId, MaxPrice = maxPrice }, token);

            var expectedCachedResult = JsonConvert.SerializeObject(cachedResult);
            var actualResult = JsonConvert.SerializeObject(result);

            Assert.AreEqual(actualResult, expectedCachedResult);
        }

    }

}

