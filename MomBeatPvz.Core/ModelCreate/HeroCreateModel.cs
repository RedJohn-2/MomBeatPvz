﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Core.ModelCreate
{
    public record HeroCreateModel
    {
        public string Name { get; set; } = string.Empty;

        public string Url {  get; set; } = string.Empty;

    }
}
