using AutoMapper;
using Invoice_Api.Repo;
using Invoice_Api.Repo.Modal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using System;

namespace Invoice_Api.Service
{
    public class InvoiceService
    {
        InvoiceDbContext _db;
        // IMapper _mapper;

        private static readonly Random random = new Random();
        public InvoiceService(InvoiceDbContext invoiceDbContext)
        {
            _db = invoiceDbContext;
            // _mapper = mapper;

        }
        public string GenerateRandomText(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        //public async Task<bool> Create1(InvoiceDetail invoiceDetails)
        //{
        //    DateTime now = DateTime.Now;

        //    string randomText = GenerateRandomText(8);

        //    invoiceDetails.InvoiceNo = $"{now:yyMMddHHmmss}-{randomText}";
        //    invoiceDetails.InvoiceDateTime = System.DateTime.Now;


        //    List<InvoiceItem> invoiceItem = new List<InvoiceItem>();
        //    foreach (InvoiceItemsModal i in invoiceDetails.InvoiceItems)
        //    {
        //        InvoiceItem modal = new InvoiceItem();

        //        modal.InvoiceNo = i.InvoiceNo;
        //        modal.ItemCode = i.ItemCode;
        //        modal.ItemQty = i.ItemQty;
        //        modal.ItemDiscount = i.ItemDiscount;
        //        modal.ItemUnitPrice = i.ItemUnitPrice;
        //        modal.ItemAmount = i.ItemAmount;
        //        modal.ItemAmountPaid = i.ItemAmountPaid;

        //        invoiceItem.Add(modal);
        //    }

        //    Invoice invoice = new Invoice();
        //    invoice.InvoiceNo = invoiceDetails.InvoiceNo;
        //    invoice.InvoiceCustomerMno = invoiceDetails.InvoiceCustomerMno;
        //    invoice.InvoiceCustomerName = invoiceDetails.InvoiceCustomerName;
        //    invoice.PaymentMode = invoiceDetails.PaymentMode;
        //    invoice.InvoiceItems = invoiceItem;

        //    try
        //    {
        //        await _db.Invoices.AddAsync(invoice);
        //        await _db.SaveChangesAsync();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }

        //}
        public async Task<bool> Create(Invoice invoice)
        {
            DateTime now = DateTime.Now;

            string randomText = GenerateRandomText(8);

            invoice.InvoiceNo = $"{now:yyMMddHHmmss}-{randomText}";
            invoice.InvoiceDateTime = System.DateTime.Now;



            try
            {
                await _db.Invoices.AddAsync(invoice);
                await _db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<Invoice> Get(string InvoiceNo = "1")
        {

            // Invoice invoice  = await _db.Invoices.FindAsync(InvoiceNo);

            Invoice invoice = await _db.Invoices.FindAsync(InvoiceNo);

            List<InvoiceItem> invItem = await _db.InvoiceItems.Where(i => i.InvoiceNo == InvoiceNo).ToListAsync<InvoiceItem>();

            invoice.InvoiceItems = invItem;


            if (invoice != null)
            {

            }

            return invoice;
        }

        public async Task<bool> Delete(string InvoiceNo)
        {
            try
            {
                Invoice invoice = await _db.Invoices.FindAsync(InvoiceNo);
                if (invoice != null)
                {
                    _db.Invoices.Remove(invoice);
                    await _db.SaveChangesAsync();
                    return true;
                }

            }
            catch
            {
                return false;
            }
            return false;
        }
        public async Task<bool> Update(Invoice invoice)
        {
            if (invoice.InvoiceNo != null)
            {
                Invoice invDbData = await _db.Invoices.FindAsync(invoice.InvoiceNo);


                if (invDbData != null)
                {

                    invDbData.InvoiceCustomerMno = invoice.InvoiceCustomerMno;
                    invDbData.InvoiceCustomerName = invoice.InvoiceCustomerName;
                    invDbData.InvoiceItems = invoice.InvoiceItems;
                    invDbData.PaymentMode = invoice.PaymentMode;
                    invDbData.InvoiceDateTime = invoice.InvoiceDateTime;
                    await _db.SaveChangesAsync();
                }
                else
                {
                    return false;
                }
            }
            return false;

        }

    }
}
