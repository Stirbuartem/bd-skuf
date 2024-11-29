using System;
using System.Collections.Generic;

namespace bd_skuf.Models;

public partial class Music
{
    public int Musicid { get; set; }

    public int Executorid { get; set; }

    public int Userid { get; set; }

    public virtual Executor? Executor { get; set; }

    public virtual User? User { get; set; }
}
