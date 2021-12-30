using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataFilter
{
    public class DataFilter
    {
        public static void Main(string[] args)
        {
            string projectDir = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Errorscreenshot\\"));
            string driverpath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Driver");

            if (!Directory.Exists(projectDir))
            {
                Directory.CreateDirectory(projectDir);
            }
            IWebDriver driver = new ChromeDriver(driverpath);
            driver.Manage().Window.Maximize();
            Thread.Sleep(5000);

            for (int i = 0; i <= 30; i++)
            {
                switch (i)
                {
                    case 1:
                        try
                        {
                            driver.Navigate().GoToUrl("http://practice.automationtesting.in/shop/");
                            Thread.Sleep(5000);
                            Console.WriteLine("1.Url is open successfully");
                        }
                        catch (Exception ex)
                        {
                            Screenshot ErrorElementScreenshot = ((ITakesScreenshot)driver).GetScreenshot();
                            ErrorElementScreenshot.SaveAsFile(projectDir + "UrlError.png", ScreenshotImageFormat.Png);
                            Thread.Sleep(2000);
                            Console.WriteLine("Error: Url is not open successfully");
                        }
                        break;
                    case 2:
                        try
                        {
                            Actions builder = new Actions(driver);
                            driver.FindElement(By.XPath("//button")).Click();
                            IWebElement fromelement = driver.FindElement(By.XPath("//button"));
                            ////        IWebElement to = driver.FindElement(By.XPath("//div[@id='woocommerce_price_filter-2']/form/div/div/span"));
                            builder.DragAndDropToOffset(fromelement, 450,500).Build();
                            builder.Perform();
                            Thread.Sleep(5000);
                            Console.WriteLine("Drag and dropped successfully");

                        }
                        catch (Exception ex)
                        {
                            Screenshot ErrorElementScreenshot = ((ITakesScreenshot)driver).GetScreenshot();
                            ErrorElementScreenshot.SaveAsFile(projectDir + "UrlError.png", ScreenshotImageFormat.Png);
                            Thread.Sleep(2000);
                            Console.WriteLine("Error: Url is not open successfully");
                        }
                        break;
                }
            }
        }
    }
}