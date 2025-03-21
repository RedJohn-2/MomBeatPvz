﻿using MomBeatPvz.Core.Model;
using MomBeatPvz.Persistence.Entities.Abstract;

namespace MomBeatPvz.Persistence.Entities
{
    public class UserEntity : IEntity<User, long>
    {
        public long Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public bool IsAdmin { get; set; }
    }
}
