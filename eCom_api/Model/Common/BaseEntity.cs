namespace eCom_api.Model.Common;

public class BaseEntity
{
    bool IsDeleted { get; set; }
    string? CreatedBy { get; set; }
    DateTime? CreatedDate { get; set; }
    string? UpdatedBy { get; set; }
    DateTime? UpdatedDate { get; set; }
}
