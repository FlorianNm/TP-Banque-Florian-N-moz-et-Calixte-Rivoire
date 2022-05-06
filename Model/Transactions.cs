namespace DB
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class Transactions
    {
        [Key]
        public int IdTransactions { get; set; }

        [Required]
        [StringLength(50)]
        public string Type { get; set; }

        public DateTime Date { get; set; }

        public double Montant { get; set; }

        public int IdCompte { get; set; }

        public virtual Compte Compte { get; set; }
    }
}
