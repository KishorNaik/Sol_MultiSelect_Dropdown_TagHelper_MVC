using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sol_Demo.Models;
using Sol_Demo.ViewModels;

// https://riptutorial.com/asp-net-core/example/8900/select-tag-helper
// https://github.com/BerserkerDotNet/CaptureRenderTagHelper
// https://select2.org/getting-started/basic-usage

namespace Sol_Demo.Controllers
{
    public class DemoController : Controller
    {

        public DemoController()
        {
            ProductVM = new ProductViewModel();
        }

        [BindProperty]
        public ProductViewModel ProductVM { get; set; }

        private IEnumerable<ProductModel> GetProductData()
        {
            var productListObj = new List<ProductModel>();
            productListObj.Add(new ProductModel()
            {
                ProductId = 1,
                ProductName = "Director's Special"
            });
            productListObj.Add(new ProductModel()
            {
                ProductId = 2,
                ProductName = "Johnnie Walker Blue Label"
            });
            productListObj.Add(new ProductModel()
            {
                ProductId = 3,
                ProductName = "Black And White"
            });

            productListObj.Add(new ProductModel()
            {
                ProductId = 4,
                ProductName = "Imperial Blue"
            });

            productListObj.Add(new ProductModel()
            {
                ProductId = 5,
                ProductName = "Royal Stag"
            });

            productListObj.Add(new ProductModel()
            {
                ProductId = 6,
                ProductName = "Bagpiper"
            });

            productListObj.Add(new ProductModel()
            {
                ProductId = 7,
                ProductName = "Mc Dowell's No. 1"
            });

            productListObj.Add(new ProductModel()
            {
                ProductId = 8,
                ProductName = "Officer's Choice"
            });

            productListObj.Add(new ProductModel()
            {
                ProductId = 9,
                ProductName = "Blender's Pride"
            });

            productListObj.Add(new ProductModel()
            {
                ProductId = 10,
                ProductName = "Jack Daniel’s"
            });

            return productListObj;
        }

        private void BindProductDropDownList()
        {
            var selectProductList =
                    this.GetProductData()
                    ?.AsEnumerable()
                    ?.Select((leProductModel) => new SelectListItem()
                    {
                        Value = Convert.ToString(leProductModel?.ProductId),
                        Text = leProductModel?.ProductName
                    })
                    ?.OrderBy((leSelectListObj) => leSelectListObj.Text)
                    ?.ToList();

            ProductVM.ProductList = selectProductList;
        }

        public IActionResult Index()
        {
            BindProductDropDownList();

            return View(ProductVM);
        }

        [HttpPost]
        public IActionResult OnSubmit()
        {
            BindProductDropDownList(); // Bind again during PostBack

            // get Selected product data from ProductVM.SelectedProduct who selected by user
            // &
            // filter from list of Product
            var filterProductData =
                    this.GetProductData()
                    ?.AsEnumerable()
                    ?.Where((leProductModel) => Convert.ToBoolean(ProductVM?.SelectedProduct?.ToList().Select(x => x).Contains(leProductModel.ProductId))) // SQL in Operator
                    ?.ToList();

            ProductVM.DisplayProductList = filterProductData;

            return View("Index", ProductVM);
        }

    }
}