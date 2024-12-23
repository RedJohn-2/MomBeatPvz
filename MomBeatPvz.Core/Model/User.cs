﻿namespace MomBeatPvz.Core.Model
{
    public class User
    {
        public long Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public bool IsAdmin { get; set; }

        public Guid Secret { get; set; }

        public DateTime Created { get; set; }

        public long TelegramId { get; set; }
    }
}
