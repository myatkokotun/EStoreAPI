using System;
using System.Collections.Generic;

namespace EStoreAPI.Models;

public partial class TbPromoCode
{
    public int Id { get; set; }

    public int? Evoucherid { get; set; }

    public string? Phoneno { get; set; }

    public string? Promocode { get; set; }

    public DateTime? Accesstime { get; set; }
}
