using PIISTECHLTD.SharedKernel.Common;

namespace PIISTECHLTD.SharedKernel.Entities;

public class Status: AuditableEntity
{
    public string Name { get; set; } = string.Empty;
}
