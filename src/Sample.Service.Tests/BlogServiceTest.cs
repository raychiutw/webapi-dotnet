using System;
using ExpectedObjects;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Sample.Common.Dto;
using Sample.Repository.Interface;
using Sample.Repository.Models;
using Sample.Service.Implement;
using Sample.Service.Interface;

namespace Sample.Service.Test
{
    [TestClass]
    public class BlogServerTest
    {
        private IBologRepository _blogRepository;
        private ILog _log;

        [TestInitialize]
        public void TestInitialize()
        {
            this._blogRepository = Substitute.For<IBologRepository>();
            this._log = Substitute.For<ILog>();
        }

        [TestMethod]
        [Owner("F4497")]
        [TestCategory("BlogService")]
        [TestProperty("BlogService", "Get")]
        public void Get_傳入BlogId_4_應該要為raychiu_url()
        {
            // arrange
            var blogId = 4;

            //var dataSource = TestData.GetDataFromCsv<Blog>("Blogs.csv");
            var blog = new Blog() { BlogId = 4, Url = "https://raychiutw.github.io/" };

            this._blogRepository.Get(blogId).Returns(blog);
            var sut = new BlogService(
                this._blogRepository,
                this._log);

            var expected = new BlogDto()
            {
                BlogId = 4,
                Url = "https://raychiutw.github.io/"
            };

            // act
            var actual = sut.Get(blogId);

            // assert
            actual.Should().NotBeNull();
            expected.ToExpectedObject().ShouldEqual(actual);
        }

        [TestMethod()]
        public void Remove_傳入id_0_應回傳參數錯誤()
        {
            // arrange
            var blogId = 0;
            var expectedMessage = "參數錯誤";

            this._blogRepository.Remove(blogId);
            var sut = new BlogService(
                this._blogRepository,
                this._log);

            // act
            Action act = () => sut.Remove(blogId);

            // assert
            act.Should().Throw<ArgumentException>()
                .WithMessage(expectedMessage);
        }
    }
}