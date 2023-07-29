using System.ComponentModel.DataAnnotations;

namespace eCom_api.Model.Common;

public class BaseEntity
{
    public bool IsDeleted { get; set; }
    [MaxLength(100)]
    public string? CreatedBy { get; set; }
    public DateTime? CreatedDate { get; set; }
    [MaxLength(100)]
    public string? UpdatedBy { get; set; }
    public DateTime? UpdatedDate { get; set; }
}
