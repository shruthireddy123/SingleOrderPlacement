using System;
using System.Collections.Generic;
using System.Text;

namespace OrderPlacement
{
    public interface IService
    {
        bool ChargePayment(string creditCardNumber, decimal amount);
        bool SendEmail();
    }

    public class Service : IService
    {
        public bool ChargePayment(string creditCardNumber, decimal amount)
        {
            return true;
        }

        public bool SendEmail()
        {
            return true;
        }
    }
}
