//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GamesCollection.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Games
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Games()
        {
            this.Platforms = new HashSet<Platforms>();
            this.Users = new HashSet<Users>();
        }
    
        public int ID { get; set; }
        public string Title { get; set; }
        public int YearOfIssue { get; set; }
        public int GenreID { get; set; }
        public double Rating { get; set; }
        public int PublisherID { get; set; }
        public int DeveloperID { get; set; }
        public string Description { get; set; }
    
        public virtual Developers Developers { get; set; }
        public virtual Genres Genres { get; set; }
        public virtual Publishers Publishers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Platforms> Platforms { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Users> Users { get; set; }
    }
}
