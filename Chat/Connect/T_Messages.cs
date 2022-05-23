using System;
using Supabase;
using Postgrest.Attributes;

namespace Chat.Connect
{
    public class T_Messages : SupabaseModel
    {
        [PrimaryKey("id", false)]
        public int Id { get; set; }

        [Column("Name")]
        public String Name { get; set; }

        [Column("Text")]
        public String Messsage { get; set; }
    }
}
