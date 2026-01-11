namespace Comparar_Cliente
{
    internal class Client
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public Client() { }

        public Client(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public override bool Equals(object obj)
        {
            if(!(obj is Client)) 
            {
                return false;
            }
            Client other = obj as Client;
            return Email.Equals(other.Email);
        }

        public override int GetHashCode()
        {
            return Email.GetHashCode();
        }
    }
}
