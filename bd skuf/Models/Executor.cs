using System;
using System.Collections.Generic;

namespace bd_skuf.Models;

public partial class Executor
{
    public int Executorid { get; set; }

    public string Name { get; set; } = null!;

    public string Surename { get; set; } = null!;

    public string Nickname { get; set; } = null!;

    public int Usersid { get; set; }

    public virtual Music ExecutorNavigation { get; set; } = null!;

    public virtual User? User { get; set; }
}
