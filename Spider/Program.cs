using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Parser;
using DB;
using DomainModels;
using Newtonsoft.Json;
using PuppeteerSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spider
{
    internal class Program
    {
        //private const string Url = "https://store.mall.autohome.com.cn/83106681.html";
        private const int ChromiumRevision = BrowserFetcher.DefaultRevision;
        private static string[] urllist = {
           //该16了.....一堆html
        };

        private static async Task Main(string[] args)
        {
            await new BrowserFetcher().DownloadAsync(ChromiumRevision);
            //await father();
            await detial();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("全部爬取完成,请关闭");
            Console.ReadKey();
        }

        private static async Task father()
        {
            foreach (var url in urllist)
            {
                await TestAngleSharp(url);
            }
        }

        private static async Task detial()
        {
            //using (var dbcontext = new MyContext())
            //{
                //暂时注释,我不想写
                //var digchips = dbcontext.Digchips.Where(b => string.IsNullOrWhiteSpace(b.Category) && !string.IsNullOrWhiteSpace(b.PartNumber)).ToList();
                //foreach (var digchip in digchips)
                //{
                //    await SaveDetial(digchip);
                //}
            //}
        }

        private static async Task TestAngleSharp(string url)
        {
            try
            {
                //Used PuppeteerSharp loading of HTML document
                var htmlString = await TestPuppeteerSharp(url);

                /*
                 * Parsing of HTML document string
                 */
                var context = BrowsingContext.New(Configuration.Default);
                var parser = context.GetService<IHtmlParser>();
                var document = parser.ParseDocument(htmlString);

                //Selector carbox element list
                IParentNode tablfvge = document.QuerySelector("table");

                var trList = document.QuerySelectorAll(".table-condensed tr");

                var carModelList = new List<Digchip>();
                foreach (var carbox in trList)
                {
                    //Parsing and converting to the car model object.
                    var model = CreateModelWithAngleSharp(carbox);
                    model.Address = url;
                    carModelList.Add(model);

                    //using (var dbcontext = new MyContext())
                    //{
                    //    var blogs = dbcontext.Digchips.Add(model);
                    //    dbcontext.SaveChanges();
                    //}
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("本页爬虫完毕  Total count:" + carModelList.Count + "本页面是:" + url);
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("这个网址超时了: " + url);
            }

        }

        private static async Task SaveDetial(Digchip digchip)
        {
            try
            {
                var htmlString = await TestPuppeteerSharp(digchip.Url);
                var context = BrowsingContext.New(Configuration.Default);
                var parser = context.GetService<IHtmlParser>();
                var document = parser.ParseDocument(htmlString);

                string PartNumber = "";
                string Category = "";
                string Title = "";
                string Description = "";
                string Company = "";
                Dictionary<string, string> Specifications = new Dictionary<string, string>();
                string Features = "";
                string Applications = "";


                var tableList = document.QuerySelectorAll(".table-striped");
                var trlist = tableList[0].QuerySelectorAll("tr");
                foreach (var tr in trlist)
                {
                    if (tr.QuerySelector("td").TextContent == "Part")
                    {
                        PartNumber = tr.QuerySelectorAll("td")[1].TextContent;
                    }
                    else if (tr.QuerySelector("td").TextContent == "Category")
                    {
                        Category = tr.QuerySelectorAll("td")[1].TextContent;
                    }
                    else if (tr.QuerySelector("td").TextContent == "Title")
                    {
                        Title = tr.QuerySelectorAll("td")[1].TextContent;
                    }
                    else if (tr.QuerySelector("td").TextContent == "Description")
                    {
                        Description = tr.QuerySelectorAll("td")[1].TextContent;
                    }
                    else if (tr.QuerySelector("td").TextContent == "Company")
                    {
                        Company = tr.QuerySelectorAll("td")[1].TextContent;
                    }

                }
                if (tableList.Count() > 1)
                {
                    var jsonlist = tableList[1].QuerySelectorAll("tr");
                    foreach (var item in jsonlist)
                    {
                        if ("Specifications" == item.QuerySelectorAll("td")[0].TextContent)
                        {
                            continue;
                        }
                        Specifications.Add(item.QuerySelectorAll("td")[0].TextContent, item.QuerySelectorAll("td")[1].TextContent);

                    }
                }

                string json = JsonConvert.SerializeObject(Specifications, Formatting.Indented);

                var FeaturesInfo = document.QuerySelector("div.container_centre  table.table-sans-bordure");
                if (FeaturesInfo.QuerySelectorAll("tr")[0].QuerySelector("td").TextContent == "Features, Applications")
                {
                    string Info = FeaturesInfo.QuerySelectorAll("tr")[1].QuerySelector("td").InnerHtml.ToString();
                    int num = Info.IndexOf("APPLICATIONS");
                    if (num == -1)
                    {
                        Features = Info;
                    }
                    else
                    {
                        Features = Info.Substring(0, num);
                        Applications = Info.Substring(num);
                    }
                }
                //using (var dbcontext = new MyContext())
                //{
                //    var blog = dbcontext.Digchips.Single(b => b.Id == digchip.Id);
                //    blog.Category = Category;
                //    blog.Title = Title;
                //    blog.Description = Description;
                //    blog.Company = Company;
                //    blog.Specifications = json;
                //    blog.Features = Features;
                //    blog.Applications = Applications;
                //    dbcontext.SaveChanges();
                //}
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("成功!");
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message + digchip.Url);
            }
        }


        private static async Task<string> TestPuppeteerSharp(string url)
        {
            //Enabled headless option
            var launchOptions = new LaunchOptions { Headless = true };
            //Starting headless browser
            var browser = await Puppeteer.LaunchAsync(launchOptions);

            //New tab page
            var page = await browser.NewPageAsync();
            //Request URL to get the page
            await page.GoToAsync(url);

            //Get and return the HTML content of the page
            var htmlString = await page.GetContentAsync();

            #region Dispose resources
            //Close tab page
            await page.CloseAsync();

            //Close headless browser, all pages will be closed here.
            await browser.CloseAsync();
            #endregion

            return htmlString;
        }

        private static Digchip CreateModelWithAngleSharp(IParentNode node)
        {
            try
            {
                var model = new Digchip
                {
                    PartNumber = node.QuerySelector("a strong").TextContent,
                    Url = "https://www.digchip.com" + node.QuerySelectorAll("a")[1].GetAttribute("href")
                    //如果是多个class的话,例如 class="a b",可以这样选择node.QuerySelectorAll("div.a.b")
                    //node.QuerySelectorAll("a")[1].OuterHtml = "<a><p></p>asdasdasdasd</a>"
                    //node.QuerySelectorAll("a")[1].InnerHtml = "<p></p>asdasdasdasd"
                };

                //var asd = node.QuerySelectorAll("a").ToList().Where(x => x.LocalName != "").ToList();

                return model;
            }
            catch (Exception)
            {
                var model = new Digchip() { };
                return model;
            }

        }


    }
}
