using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace X.ComponentModel.Tests
{
    [TestClass]
    public class String_Should
    {
        [TestMethod]
        [ExpectedException(typeof(TextException))]
        public void Validate()
        {
            var name = new ProductName("  ");
        }

        [TestMethod]
        public void Format()
        {
            var name = new ProductName(" Best Pasta ");
            Assert.AreEqual("Best Pasta", name.Text);
            
            var slug = new Slug(" Best Pasta ");
            Assert.AreEqual("best-pasta", slug.Text);
        }

        [TestMethod]
        public void Serialize()
        {
            var json = "{\"name\":\"abc\"}";
            var dto = Dto.FromJson(json);
            Assert.AreEqual(json, dto.ToJson());
        }
    }

    public class ProductName : String<ProductName>
    {
        public ProductName(string text)
            : base(text, NotNullOrWhitespace, Trim)
        {
        }
    }

    public class Slug : String<Slug>
    {
        protected static string Dash(string text) => text.Replace(" ", "-");
        public Slug(string text) 
            : base(text, NotNullOrWhitespace, Trim, Lower, Dash)
        {
        }
    }

    public class Dto : JsonObject<Dto>
    {
        public Dto(ProductName name)
        {
            Name = name ?? throw new System.ArgumentNullException(nameof(name));
        }

        public ProductName Name { get; }

        protected override IEnumerable<object> EqualityCheckAttributes =>
            new object[] { Name };
    }
}
