﻿namespace MomBeatPvz.Core.Model
{
    public class User
    {
        public long Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public bool IsAdmin { get; set; }
    }
}
