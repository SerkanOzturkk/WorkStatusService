﻿using Core.Abstract;
using Core.Entities;

namespace Entities.Concrete;

public class Report : BaseEntity
{
    public string ReportType { get; set; }
    public DateTime ReportDate { get; set; }
    public int TeamId { get; set; }
    public int TotalTasksCompleted { get; set; }
    public int TotalTasksPending { get; set; }

    public Team Team { get; set; }
}