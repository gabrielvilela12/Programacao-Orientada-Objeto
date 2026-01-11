using Sistema_Bancário_Simples.Presentation;
using Sistema_Bancário_Simples.Presentation.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema_Bancário_Simples.Application.ViewModel
{
    public class TransferenceViewModel
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public UserViewModel Sender { get; set; }
        public UserTransferenceViewModel Receiver { get; set; }
    }
}
