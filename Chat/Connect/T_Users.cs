using System;
using Supabase;
using Postgrest.Attributes;

namespace Chat.Connect
{
    public class T_Users : SupabaseModel
    {
        [PrimaryKey("id", false)]
        public int Id { get; set; }

        [Column("login")]
        public String Login { get; set; }

        [Column("password")]
        public String Password { get; set; }
    }
}
