using CSharpVerbalExpressions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerbalExpressionsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var urlExp = new VerbalExpressions()
                                .StartOfLine()
                                .Then("http")
                                .Maybe("s")
                                .Then("://")
                                .AnythingBut(" ")
                                .EndOfLine();

            var emailExp = new VerbalExpressions()
                                .StartOfLine()
                                .Anything()
                                .Then("@")
                                .AnythingBut(" ")
                                .Then(".")
                                .AnythingBut(" ")
                                .EndOfLine();

            var phoneExp = new VerbalExpressions()
                                .StartOfLine()
                                .Maybe("(")
                                .Range('0', '9')
                                .RepeatPrevious(3)
                                .Maybe(")")
                                .Maybe(" ")
                                .Range('0', '9')
                                .RepeatPrevious(3)
                                .Maybe("-")
                                .Range('0', '9')
                                .RepeatPrevious(4)
                                .EndOfLine();


            var url = "http://www.exceptionnotfound.net";

            var email = "test@example.com";

            var invalidEmail = "test@example";

            var phone = "(123) 456-7890";

            Assert.IsTrue(urlExp.Test(url), "The URL is not valid!");
            Assert.IsTrue(emailExp.Test(email), "The email is not valid!");
            Assert.IsTrue(phoneExp.Test(phone), "The phone number is invalid.");

            Assert.IsTrue(emailExp.Test(invalidEmail), "The email is not valid!");
        }
    }
}
