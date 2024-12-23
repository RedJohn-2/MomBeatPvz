using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Persistence.Entities
{
    public class UserEntity
    {
        public long Id { get; set; }

        public long TelegramId { get; set; }

        public string Name { get; set; } = string.Empty;

        public bool IsAdmin { get; set; }

        public Guid Secret { get; set; }

        public DateTime Created { get; set; }
    }
}
