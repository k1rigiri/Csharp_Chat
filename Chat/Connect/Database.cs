using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Supabase;
using Supabase.Realtime;
using Client = Supabase.Client;

namespace Chat.Connect
{
    public class Database : INotifyPropertyChanged
    {
        private Client Client { get; }
        public IEnumerable<T_Messages> Messages { get; set; }
        public IEnumerable<T_Users> Users { get; set; }
        public event PropertyChangedEventHandler? PropertyChanged;

        public Database()
        {
            //Connect to Database
            var key = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6InJkeW5kYmZqeXNodHBzeWtqcmVzIiwicm9sZSI6ImFub24iLCJpYXQiOjE2NTI0NjMwMDEsImV4cCI6MTk2ODAzOTAwMX0.j8cxvjPTMxPyQ5P107ALHnrlWNqiAN52YFlZLZYpGRs";
            var url = "https://rdyndbfjyshtpsykjres.supabase.co";

            Messages = new List<T_Messages>();
            Users = new List<T_Users>();

            Client.InitializeAsync(url, key, new SupabaseOptions
            {
                AutoConnectRealtime = true,
                ShouldInitializeRealtime = true
            });
            Client = Client.Instance;
            Client.From<T_Users>().On(Client.ChannelEventType.All, UsersChanged);
            Client.From<T_Messages>().On(Client.ChannelEventType.All, MessagesChanged);
        }
        public async void LoadUsers()
        {
            var data = await Client.From<T_Users>().Get();
            Users = data.Models;
            OnPropertyChangedUsers(nameof(Users));
        }

        public async void InsertUsers(T_Users user)
        {
            await Client.From<T_Users>().Insert(user);
        }

        private void UsersChanged(object sender, SocketResponseEventArgs a)
        {
            LoadUsers();
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChangedUsers([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public async void LoadMessages()
        {
            var data = await Client.From<T_Messages>().Get();
            Messages = data.Models;
            OnPropertyChangedUsers(nameof(Messages));
        }

        public async void InsertMessages(T_Messages message)
        {
            await Client.From<T_Messages>().Insert(message);
        }

        private void MessagesChanged(object sender, SocketResponseEventArgs a)
        {
            LoadMessages();
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChangedMessages([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
