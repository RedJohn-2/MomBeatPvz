﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Core.Model
{
    public class TierList
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
        public List<TierListSolution> Solutions { get; set; } = new();
        public TierListSolution Result { get; set; } = new();
        public DateTime Created { get; set; }
        public User Creator { get; set; } = new();
    }
}
