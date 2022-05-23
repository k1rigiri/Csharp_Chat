using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Chat.Connect;
using Avalonia.Styling;

namespace Chat
{
    public partial class ChatWindow : Window
    {
        public string UserName { get; set; } = string.Empty;
        public Database database;

        public ChatWindow()
        {
            InitializeComponent();
        }
        
        public void Update()
        {
            foreach (var message in database.Messages)
            {
                Chat.Text += message.Name + ": " + message.Messsage + "\n";
            }
        }
        
        public void SendButtonOnClick(object sender, RoutedEventArgs e)
        {
            Chat.Text += UserName + ": " + Message.Text + "\n";
            T_Messages message = new() { Name = UserName, Messsage = Message.Text };
            database.InsertMessages(message);
            Message.Clear();
        }
        
    }
}