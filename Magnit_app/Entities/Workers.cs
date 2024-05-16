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
    
    public partial class Workers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Workers()
        {
            this.Sales = new HashSet<Sales>();
            this.Worker_tasks = new HashSet<Worker_tasks>();
        }
    
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public string Patronimyc { get; set; }
        public string Adress { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int Id_store { get; set; }
        public int Id_role { get; set; }
        public bool IsDeleted { get; set; }
        public int Id { get; set; }
        public int Gender { get; set; }
        public byte[] Photo { get; set; }
        public string Phone { get; set; }
    
        public virtual Gender Gender1 { get; set; }
        public virtual Roles Roles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sales> Sales { get; set; }
        public virtual Store Store { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Worker_tasks> Worker_tasks { get; set; }
    }
}
