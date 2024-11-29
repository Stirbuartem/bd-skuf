using System;
using System.Collections.Generic;

namespace bd_skuf.Models;

public partial class User
{
    public int Userid { get; set; }

    public string Name { get; set; } = null!;

    public string? Surename { get; set; }

    public string Nickname { get; set; } = null!;

    public virtual Executor User1 { get; set; } = null!;

    public virtual Music UserNavigation { get; set; } = null!;
}
