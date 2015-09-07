using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PersonelKayitveRapor.Model
{
    class Node
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int ParentId { get; set; }

    }
}
