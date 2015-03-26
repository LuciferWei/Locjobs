using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Selenium.Extensions;

namespace ConsoleApplication
{
    public static class CommonMethod
    {
        public static List<String> getLocalPages(IWebDriver driver)
        {
            List<string> localPages = new List<string>();
            ReadOnlyCollection<IWebElement> parsedAllPages;
            parsedAllPages = driver.FindElements(By.CssSelector("span[class='js-selectable-text']"));

            for (int i = 0; i < parsedAllPages.Count; i++)
            {
                localPages.Add(parsedAllPages[i].GetAttribute("title"));
                // System.Console.WriteLine(localPages[i]);
            }

            return localPages;
        }

        public static void logIn(String []args, IWebDriver driver)
        {
            Thread.Sleep(500);
            driver.FindElement(By.CssSelector("input[name='login']")).SendKeys(args[2]);
            driver.FindElement(By.CssSelector("input[name='password']")).SendKeys(args[3]);

            Thread.Sleep(500);
            driver.WaitForURLChange(() => driver.FindElement(By.CssSelector("input[name='commit']")).Click());


            driver.FindElement(By.CssSelector("input[name='otp']")).SendKeys(args[1]);
            driver.WaitForURLChange(() => driver.FindElement(By.CssSelector("div button")).Click());
        }

        public static void getLocalJobs()
        {
            
        }
    }
}
