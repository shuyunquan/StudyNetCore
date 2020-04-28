using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IService;
using Microsoft.AspNetCore.Mvc;
using Web.Helper;

namespace Web.Controllers
{
    public class HtmlToPDFController : Controller
    {

        private IPDFService _PDFService;
        public HtmlToPDFController(IPDFService pDFService)
        {
            _PDFService = pDFService;
        }


        public FileResult GetPDF()
        {
            //获取html模板
            var htmlContent = TemplateGenerator.GetPDFHTMLString();

            //生成PDF
            var pdfBytes = _PDFService.CreatePDF(htmlContent);

            return File(pdfBytes, "application/pdf");
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}