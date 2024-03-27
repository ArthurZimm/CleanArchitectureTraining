using Todo.Application.DTOs;

namespace Todo.API.ViewModels
{
    public class ViewModelUser
    {

        public ViewModelUser(bool created, UserDTO? user)
        {
            Created = created;
            User = user;
        }


        public bool Created { get; set; }
        public UserDTO? User { get; set; }

    }
}
