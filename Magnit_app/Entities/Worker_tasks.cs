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
    
    public partial class Worker_tasks
    {
        public int Id { get; set; }
        public int Id_worker { get; set; }
        public string Task_text { get; set; }
        public bool Is_comleted { get; set; }
        public System.DateTime DateOfTask { get; set; }
    
        public virtual Workers Workers { get; set; }
    }
}
