using System;
using System.Collections.Generic;
using System.Text;

namespace ConsumoX.Model
{
    public class ListaUsuarios
    {
        public int page { get; set; }
        public int per_page { get; set; }
        public int total { get; set; }
        public int total_pages { get; set; }
        public Usuario[] data { get; set; }
    }

    public class Usuario
    {
        public int id { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string avatar { get; set; }
    }

}
