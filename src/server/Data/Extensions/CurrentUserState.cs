using HotChocolate;

namespace Data.Extensions
{
    public class CurrentUserState : GlobalStateAttribute
    {
        public CurrentUserState() : base("currentUser") { }
    }
}