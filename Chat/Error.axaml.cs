using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Chat
{
    public partial class Error : Window
    {
        public string ErrorText { set; get; } = string.Empty; 

        public Error()
        {
            InitializeComponent();
        }

        public void Update()
        {
            ErrorBlock.Text = ErrorText;
        }
        
    }
}