using System.ComponentModel.DataAnnotations;

namespace CrudWithModal.Models;

public class Person
{
    [Key]
    [Display(Name = "#")]
    public long ID { get; set; }

    [Display(Name = "نام")]
    public string FirstName { get; set; } = default!;

    [Display(Name = "نام خانوادگی")]
    public string LastName { get; set; } = default!;
}
