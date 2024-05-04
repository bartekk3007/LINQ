using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Collections
{
    internal class Transaction
    {
        public int TransactionID { get; set; }
        public string Item {  get; set; }
        public double Price { get; set; }
        public int ClientID {  get; set; }

        public Transaction(int transactionID, string item, double price, int clientID)
        {
            TransactionID = transactionID;
            Item = item;
            Price = price;
            ClientID = clientID;
        }
        public override string ToString()
        {
            return $"{TransactionID.ToString()}.\t{Item} {Price} {ClientID}";
        }
    }
}
