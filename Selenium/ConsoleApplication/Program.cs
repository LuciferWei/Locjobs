using System;
using System.Collections.Generic;
using Selenium.BrowserMatrix;
using OpenQA.Selenium;
using System.Threading;
using Selenium.Extensions;
using System.Collections.ObjectModel;
using System.IO;

namespace ConsoleApplication
{
    class Program
    {
        /*
         * param:
         * agrs[0]: Destination URL
         * args[1]: Verify code
         * args[2]: username
         * args[3]: password
         **/
        static void Main(string[] args)
        {
            IWebDriver driver = Chrome.ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(args[0]);

            Thread.Sleep(500);
            driver.FindElement(By.CssSelector("input[name='login']")).SendKeys(args[2]);
            driver.FindElement(By.CssSelector("input[name='password']")).SendKeys(args[3]);

            Thread.Sleep(500);
            driver.WaitForURLChange(() => driver.FindElement(By.CssSelector("input[name='commit']")).Click());


            driver.FindElement(By.CssSelector("input[name='otp']")).SendKeys(args[1]);
            driver.WaitForURLChange(() => driver.FindElement(By.CssSelector("div button")).Click());
            IWebElement LocaljobID = driver.FindElement(By.CssSelector("a[title*='loc job 341']"));
            driver.WaitForURLChange(() => LocaljobID.Click());

            List<string> localPages = new List<string>();
            ReadOnlyCollection<IWebElement> parsedAllPages;
            parsedAllPages = driver.FindElements(By.CssSelector("span[class='js-selectable-text']"));

            for (int i = 0; i < parsedAllPages.Count; i++)
            {
                localPages.Add(parsedAllPages[i].GetAttribute("title"));
                // System.Console.WriteLine(localPages[i]);
            }

            FileStream aFile = new FileStream("Local drop pages.txt", FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(aFile);
            for (int i = 0; i < localPages.Count; i++)
            {
                sw.WriteLine(localPages[i]);
            }
            sw.Close();
            driver.Close();
        }
    }
}
