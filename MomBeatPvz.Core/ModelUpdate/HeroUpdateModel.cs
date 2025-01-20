﻿using MomBeatPvz.Core.Model;
using MomBeatPvz.Core.ModelUpdate.Abstract;
using MomBeatPvz.Core.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Core.ModelUpdate
{
    public class HeroUpdateModel : IUpdateModel<Hero, int>
    {
        public int Id { get; set; }

        public Trackable<string> Name { get; set; } = new();

        public Trackable<string> Url { get; set; } = new();
    }
}
