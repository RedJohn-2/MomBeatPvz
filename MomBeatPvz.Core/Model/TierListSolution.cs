﻿using MomBeatPvz.Core.Model.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Core.Model
{
    public class TierListSolution : BaseLongModel
    {
        public TierList TierList { get; set; } = new();

        public User Owner { get; set; } = new();

        public List<HeroPrice> Prices { get; set; } = new();
    }
}
