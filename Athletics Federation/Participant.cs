//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Athletics_Federation
{
    using System;
    using System.Collections.Generic;
    
    public partial class Participant
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Participant()
        {
            this.PersonCompetitions = new HashSet<PersonCompetition>();
        }
    
        public int ID { get; set; }
        public int IdActivity { get; set; }
        public string Suname { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public Nullable<System.DateTime> Birthday { get; set; }
        public int IdGender { get; set; }
        public int IdTeam { get; set; }
    
        public virtual Activity Activity { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual Team Team { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonCompetition> PersonCompetitions { get; set; }
    }
}
