//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EnitityFreamworkInDepth
{
    using System;
    using System.Collections.Generic;
    
    public partial class library_card_master
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public library_card_master()
        {
            this.customer_card_details = new HashSet<customer_card_details>();
        }
    
        public string card_id { get; set; }
        public string description { get; set; }
        public Nullable<int> amount { get; set; }
        public Nullable<int> number_of_years { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<customer_card_details> customer_card_details { get; set; }
    }
}
