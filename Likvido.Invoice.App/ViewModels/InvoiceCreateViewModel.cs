using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Likvido.Invoice.App.ViewModels
{
    public class InvoiceCreateViewModel
    {
        public DateTime Date { get; set; } 
        public DateTime DueDate { get; set; }
        public Debtor Debtor { get; set; } 
        public string Currency { get; set; }
        public string Comments { get; set; }
        public CampaignType CampaignInitialRequest { get; set; }
        public DateTime? DebtCollectionWarningDate { get; set; }
        public DateTime? DebtRegisterWarningDate { get; set; }
        public List<Line> Lines { get; set; } 
        public string ReferenceId { get; set; }
        public string CreditorReference { get; set; }

    }

    public class Debtor
    {
        public string CompanyName { get; set; }
        public string CompanyRegistrationNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AccountingDebtorId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DebtorType DebtorType { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string PersonBirthday { get; set; }
    }

    public class Line
    {
        public double UnitNetPrice { get; set; }
        public string Description { get; set; }
        public double Quantity { get; set; }
        public double VatRate { get; set; }
        public DiscountType DiscountType { get; set; }
        public double DiscountValue { get; set; }

    }

    public enum DebtorType
    {
        Private = 0,
        Company = 1
    }
    public enum CampaignType
    {
        DebtCollection = 1,
        Reminders = 5,
        Invoice = 6, 
        InternationalDebtCollection = 7
    }

    public enum DiscountType
    {
        Percent = 0,
        Cash = 1
    }

}
