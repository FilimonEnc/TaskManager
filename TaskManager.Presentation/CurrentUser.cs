using TaskManager.ApplicationLayer.Models;

namespace TaskManager.Presentation
{
    public class CurrentUser : UserModel
    {
        public void LogIn(UserModel userModel)
        {
            Name = userModel.Name;
            Login = userModel.Login;
            IconPath = userModel.IconPath;
        }
    }
}
