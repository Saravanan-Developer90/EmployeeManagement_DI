using System;
using System.Collections.Generic;

namespace EmployeeManagement.Models.EF;

public partial class DeptInfo
{
    public int DeptNo { get; set; }

    public string? DeptName { get; set; }

    public string? DeptLocation { get; set; }

    public virtual ICollection<JobOpening> JobOpenings { get; set; } = new List<JobOpening>();
}
