using MomBeatPvz.Core.Model.Abstract;

namespace MomBeatPvz.Core.Model
{
    public class User : BaseLongModel
    {
        public string Name { get; set; } = string.Empty;

        public bool IsAdmin { get; set; }
    }
}
