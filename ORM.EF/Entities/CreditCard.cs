using System;
using System.ComponentModel.DataAnnotations;

namespace ORM.EF.Entities
{
  public partial class CreditCard
  {
    [Key]
    public int CardID { get; set; }

    [Required]
    [StringLength(19)]
    public string CardNo { get; set; }

    public int EmployeeID { get; set; }

    public DateTime ValidThrough { get; set; }

    [Required]
    [StringLength(31)]
    public string CardHolder { get; set; }

    public virtual Employee Employee { get; set; }
  }
}