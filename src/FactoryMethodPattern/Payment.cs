namespace FactoryMethodPattern
{
    public interface IPaymentGateway
    {
        bool ProcessPayment(decimal amount);
    }

    public class StripePaymentGateway : IPaymentGateway
    {
        public bool ProcessPayment(decimal amount)
        {
            // Logic to process payment
            Console.WriteLine($"Processed payment of ${amount} using stripe");
            return true;
        }
    }

    public class PaypalPaymentGateway : IPaymentGateway
    {
        public bool ProcessPayment(decimal amount)
        {
            // Logic to process payment
            Console.WriteLine($"Processed payment of ${amount} using paypal");
            return true;
        }
    }

    public class BankTransferPaymentGateway : IPaymentGateway
    {
        public bool ProcessPayment(decimal amount)
        {
            // Logic to process payment
            Console.WriteLine($"Processed payment of ${amount} using bank transfer");
            return true;
        }
    }

    public class CryptoPaymentGateway : IPaymentGateway
    {
        public bool ProcessPayment(decimal amount)
        {
            // Logic to process payment
            Console.WriteLine($"Processed payment of ${amount} using Crypto");
            return true;
        }
    }

    public static class PaymentGatewayFactory
    {
        public static IPaymentGateway CreatePaymentGateway(string type)
        {
            switch (type)
            {
                case "Stripe":
                    return new StripePaymentGateway();
                case "PayPal":
                    return new PaypalPaymentGateway();
                case "BankTransfer":
                    return new BankTransferPaymentGateway();
                case "Crypto":
                    return new CryptoPaymentGateway();
                default:
                    throw new ArgumentException("Invalid payment gateway type");
            }
        }
    }
}
