using System;
using System.Collections.Generic;

namespace EStoreAPI.Models;

public partial class TbCode
{
    public int Id { get; set; }

    public string? Codeno { get; set; }

    public bool? Isredeem { get; set; }
}
