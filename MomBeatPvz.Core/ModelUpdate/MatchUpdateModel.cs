﻿using MomBeatPvz.Core.Model;
using MomBeatPvz.Core.ModelUpdate.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Core.ModelUpdate
{
    public class MatchUpdateModel : IUpdateModel<Match, long>
    {
        public long Id { get; set; }

        public Trackable<bool> IsCompleted { get; set; } = new();

        public Trackable<List<MatchResult>> Results { get; set; } = new();
    }
}
