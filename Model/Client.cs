namespace DB
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Client")]
    public partial class Client
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Client()
        {
            Compte = new HashSet<Compte>();
        }

        [Key]
        public int IdClient { get; set; }

        [Required]
        [StringLength(50)]
        public string Nom { get; set; }

        [Required]
        [StringLength(50)]
        public string Prenom { get; set; }

        [Required]
        [StringLength(50)]
        public string Adresse { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Compte> Compte { get; set; }
    }
}
