using System;
using System.Collections.Generic;

namespace MyStore.NewFolder;

public partial class Test
{
    public string Testid { get; set; } = null!;

    public virtual ICollection<Score> Scores { get; set; } = new List<Score>();
}
