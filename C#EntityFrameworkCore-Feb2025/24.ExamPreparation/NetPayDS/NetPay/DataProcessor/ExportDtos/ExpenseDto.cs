using System;
using System.Xml.Serialization;

namespace NetPay.DataProcessor.ExportDtos
{
    public class ExpenseDto
    {
        [XmlElement("ExpenseName")]
        public string ExpenseName { get; set; }

        [XmlElement("Amount")]
        public string Amount { get; set; }

        [XmlElement("PaymentDate")]
        public string PaymentDate { get; set; }

        [XmlElement("ServiceName")]
        public string ServiceName { get; set; }
    }
}

