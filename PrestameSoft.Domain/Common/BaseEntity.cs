using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestameSoft.Domain.Common;

public abstract class BaseEntity
{
    public int Id { get; set; }
    public bool IsDeleted { get; set; }
    public string UserId { get; set; } = string.Empty;
    public DateTime? DateCreated { get; set; }
    public DateTime? DateModified { get; set; }
}
