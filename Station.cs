//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace exam_8
{
    using System;
    using System.Collections.Generic;
    
    public partial class Station
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Station()
        {
            this.Transitions = new HashSet<Transition>();
            this.Transitions1 = new HashSet<Transition>();
        }
    
        public int Id { get; set; }
        public int LineId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public Nullable<System.TimeSpan> WorkdaysOpenTime { get; set; }
        public Nullable<System.TimeSpan> WeekendOpenTime { get; set; }
        public Nullable<int> CountOfExits { get; set; }
    
        public virtual MetroLine MetroLine { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transition> Transitions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transition> Transitions1 { get; set; }
    }
}
