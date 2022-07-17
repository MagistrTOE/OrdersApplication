﻿namespace MyOrders.Domain
{
    public class Order
    {
        public Guid Id { get; set; }
        public string SenderCity { get; set; }
        public string SenderAddress { get; set; }
        public string RecipientCity { get; set; }
        public string RecipientAddress { get; set; }
        public double Weight { get; set; }
        public DateTime RecivedDate { get; set; }
    }
}