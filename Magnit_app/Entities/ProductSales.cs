//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Magnit_app.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductSales
    {
        public int Id_sale { get; set; }
        public int Id_product { get; set; }
        public int Count { get; set; }
    
        public virtual Product_items Product_items { get; set; }
        public virtual Sales Sales { get; set; }
    }
}
