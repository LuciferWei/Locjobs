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
         * agrs[0]: Destination URL New version can be anything but null
         * args[1]: Verify code
         * args[2]: username
         * args[3]: password
         **/
        static void Main(string[] args)
        {
            List<string> allURLs = FileOperation.readFile();
            IWebDriver driver = Chrome.ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(allURLs[0].Split('+')[0]);

            CommonMethod.logIn(args, driver);
            StreamWriter sw = null;

            foreach (string url in allURLs)
            {
                driver.Navigate().GoToUrl(url.Split('+')[0]);
                IWebElement LocaljobID = driver.FindElement(By.CssSelector("a[title*='loc job "+url.Split('+')[1]+"']"));
                driver.WaitForURLChange(() => LocaljobID.Click());
                List<string> localPages = CommonMethod.getLocalPages(driver);

                sw = FileOperation.WriteToFile(localPages);
            }

            sw.Close();
            driver.Close();
        }
    }
}
