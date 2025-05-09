﻿using System;
using System.Collections.Generic;

namespace NewRestApi.Models;

public partial class Student
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public int? Age { get; set; }

    public string? Course { get; set; }

    public decimal? Fee { get; set; }
}
