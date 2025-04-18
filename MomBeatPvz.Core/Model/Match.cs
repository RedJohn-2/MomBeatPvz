﻿using MomBeatPvz.Core.Model.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Core.Model
{
    public class Match : BaseLongModel
    {
        public Championship Championship { get; set; } = new();

        public bool IsCompleted { get; set; }

        public List<MatchResult> Results { get; set; } = new();
    }
}
