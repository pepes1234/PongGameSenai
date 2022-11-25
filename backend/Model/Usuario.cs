using System;
using System.Collections.Generic;

namespace backend.Model;

public partial class Usuario
{
    public int Id { get; set; }

    public string? Nickname { get; set; }

    public int Value1R { get; set; }

    public int Value1G { get; set; }

    public int Value1B { get; set; }

    public int Value2R { get; set; }

    public int Value2G { get; set; }

    public int Value2B { get; set; }

    public int Value3R { get; set; }

    public int Value3G { get; set; }

    public int Value3B { get; set; }

    public int Value4R { get; set; }

    public int Value4G { get; set; }

    public int Value4B { get; set; }

    public int Value5R { get; set; }

    public int Value5G { get; set; }

    public int Value5B { get; set; }

    public virtual ICollection<Score> ScorePlayer1NicknameNavigations { get; } = new List<Score>();

    public virtual ICollection<Score> ScorePlayer2NicknameNavigations { get; } = new List<Score>();
}
