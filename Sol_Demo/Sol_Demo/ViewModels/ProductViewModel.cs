using Microsoft.AspNetCore.Mvc.Rendering;
using Sol_Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sol_Demo.ViewModels
{
    public class ProductViewModel
    {
        public IEnumerable<SelectListItem> ProductList { get; set; }

        public int[] SelectedProduct { get; set; } // Get Select Product

        public IEnumerable<ProductModel> DisplayProductList { get; set; }
    }
}
