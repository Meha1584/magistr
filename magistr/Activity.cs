//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace magistr
{
    using System;
    using System.Collections.Generic;
    
    public partial class Activity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Activity()
        {
            this.StudentActivity = new HashSet<StudentActivity>();
        }
    
        public int idActivty { get; set; }
        public int idSubject { get; set; }
        public System.DateTime data { get; set; }
        public System.TimeSpan time { get; set; }
        public string description { get; set; }
        public string dayOfWeek { get; set; }
    
        public virtual SubjectOfWell SubjectOfWell { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentActivity> StudentActivity { get; set; }
    }
}
