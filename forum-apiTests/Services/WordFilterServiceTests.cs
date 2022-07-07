using Microsoft.VisualStudio.TestTools.UnitTesting;
using forum_api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace forum_api.Services.Tests
{
    [TestClass()]
    public class WordFilterServiceTests
    {
        private string expectedText;

        private IWordFilterService _wordFilterService;

        [TestInitialize]
        public void Initialize()
        {
            this._wordFilterService = new WordFilterService();

            this.expectedText = "Je te déteste tu n'es qu'une grosse m***e. Va te faire f****e !!!";
        }

        [TestMethod()]
        [DataRow("Je te déteste tu n'es qu'une grosse merde. Va te faire foutre !!!")]
        public void ReplaceInsults_ParamsOk_ShouldReturnCensuredWord(string textATester)
        {
            // Arrange
            

            // Act
            string actualText = _wordFilterService.ReplaceInsults(textATester);

            // Assert
            Assert.IsInstanceOfType(actualText, typeof(string));
            Assert.AreEqual(actualText, this.expectedText);
        }

        [TestMethod()]
        [DataRow(null)]
        public void ReplaceInsults_ParamsNull_ShouldReturnNull(string textATester)
        {
            // Arrange


            // Act
            string actualText = _wordFilterService.ReplaceInsults(textATester);

            // Assert
            Assert.AreEqual(actualText, null);
        }
    }
}