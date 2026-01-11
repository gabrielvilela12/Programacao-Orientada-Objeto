using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registrar_Log
{
    internal class Client
    {
        public string Name { get; set; }
        public DateTime DateTime { get; set; }

        public Client()
        {

        }

        public Client(string name, DateTime dateTime)
        {
            Name = name;
            DateTime = dateTime;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Client))
            {
                return false;
            }
            Client other = obj as Client;
            return Name.Equals(other.Name);
        }

        public override string ToString()
        {
            return Name + " " + DateTime;
        }
    }
}
