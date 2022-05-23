using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Chat.Connect;
using Avalonia.Styling;

namespace Chat
{
    public partial class Authorization : Window
    {
        Database database = new();
        public Authorization()
        {
            database.LoadUsers();
            database.LoadMessages();
            InitializeComponent();
        }

        public void LoginButtonOnClick(object sender, RoutedEventArgs e)
        {
            if(!(Empty()))
            {
                Error ErrorWindow = new() { ErrorText = "Fields are empty!" };
                ErrorWindow.Update();
                ErrorWindow.Show();
            }
            else
            {
                bool err = false;
                foreach (var user in database.Users)
                {
                    if (user.Login == Login.Text && user.Password == Password.Text )
                    {
                        err= true;
                        ChatWindow cw = new()
                        {
                            UserName = Login.Text,
                            database = database
                        };
                        cw.Update();
                        cw.Show();
                    }
                }
                if (!err)
                {
                    Error ErrorWindow = new() { ErrorText = "You have entered a wrong login or password!" };
                    ErrorWindow.Update();
                    ErrorWindow.Show();
                }
            }
        }
        public void SignupButtonOnClick(object sender, RoutedEventArgs e)
        {
            if (!(Empty()))
            {
                Error ErrorWindow = new() { ErrorText = "Fields are empty!" };
                ErrorWindow.Update();
                ErrorWindow.Show();
            }
            else
            {
                bool Er = false;
                foreach (var User in database.Users)
                {
                    if (User.Login == Login.Text)
                    {
                        Error ErrorWindow = new() { ErrorText = "This user already exist!" };
                        ErrorWindow.Update();
                        ErrorWindow.Show();
                        break;
                    }
                }
                if (!Er)
                {
                    T_Users TableUser = new()
                    {
                        Login = Login.Text,
                        Password = Password.Text
                    };
                    database.InsertUsers(TableUser);
                }
            }
        }

        public bool Empty()
        {
            if(Login.Text == null || Password.Text == null)
                return false;
            return true;
        }
    }
}