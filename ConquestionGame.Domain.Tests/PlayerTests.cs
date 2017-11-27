using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConquestionGame.Domain.Tests
{
    public class PlayerTests
    {
        [Test]
        public void Validate_Player_Model_Succeed()
        {
            //Assemble
            var player = new Player()
            {
                Id = 1,
                Name = "Thomas",
                Games = null
            };

            //Act
            var validationResults = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(player, new ValidationContext(player), validationResults, true);

            //Assert
            Assert.IsTrue(actual, "Expected Validation to Succeed");
            Assert.AreEqual(0, validationResults.Count, "Unexpected number of validation errors.");
        }

        [Test]
        public void Validate_Player_Model_NameExceedsMaxLength()
        {
            //Assemble
            var player = new Player()
            {
                Id = 1,
                Name = "ThomasTheGreatAndMightyConquererOfAllOthers",
                Games = null
            };

            //Act
            var validationResults = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(player, new ValidationContext(player), validationResults, true);

            //Assert
            Assert.IsFalse(actual, "Expected Validation to Fail");
            Assert.AreEqual(1, validationResults.Count, "Unexpected number of validation errors.");
            var msg = validationResults[0];
            Assert.AreEqual("Name must be between 1 and 20 characters", msg.ErrorMessage);
            Assert.AreEqual(1, msg.MemberNames.Count(), "Unexpected number of memeber names.");
            Assert.AreEqual("Name", msg.MemberNames.ElementAt(0));
        }

        [Test]
        public void Validate_Player_Model_NameIsNotEmpty()
        {
            //Assemble
            var player = new Player()
            {
                Id = 1,
                Name = "",
                Games = null
            };

            //Act
            var validationResults = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(player, new ValidationContext(player), validationResults, true);

            //Assert
            Assert.IsFalse(actual, "Expected Validation to Fail");
            Assert.AreEqual(1, validationResults.Count, "Unexpected number of validation errors.");
            var msg = validationResults[0];
            Assert.AreEqual("The Name field is required.", msg.ErrorMessage);
            Assert.AreEqual(1, msg.MemberNames.Count(), "Unexpected number of memeber names.");
            Assert.AreEqual("Name", msg.MemberNames.ElementAt(0));
        }


    }
}
