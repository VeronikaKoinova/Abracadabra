//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WPFFlowerShop.ApplicationData
{
    using System;
    using System.Collections.Generic;
    
    public partial class SaleProduct
    {
        public int ID_SaleProduct { get; set; }
        public int ID_Product { get; set; }
        public int ID_Sale { get; set; }
        public int Quantity { get; set; }
    
        public virtual Products Products { get; set; }
        public virtual Sales Sales { get; set; }
    }
}
