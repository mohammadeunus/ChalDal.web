using eCom_api.Model.Common;
using System.ComponentModel.DataAnnotations;

namespace eCom_api.Model;

public class AdminModel : UserBase
{
    [Key]
    public int AdminId { get; set; }
}
