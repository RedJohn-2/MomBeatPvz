using MomBeatPvz.Core.Model;
using MomBeatPvz.Core.Model.Abstract;
using MomBeatPvz.Core.ModelCreate.Abstract;

namespace MomBeatPvz.Core.ModelCreate
{
    public class UserCreateModel : ICreateModel<User>
    {
        public long Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public bool IsAdmin { get; set; }
    }
}
