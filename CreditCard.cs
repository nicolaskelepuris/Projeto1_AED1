namespace Projeto1AED1
{
    public class CreditCard
    {
        public string Number { get; private set; }
        public string OwnerName { get; private set; }
        public string SecurityCode { get; private set; }

        public CreditCard(string number, string ownerName, string securityCode)
        {
            Number = number;
            OwnerName = ownerName;
            SecurityCode = securityCode;
        }
    }
}