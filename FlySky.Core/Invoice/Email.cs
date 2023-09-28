using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using Aspose.Pdf.Text;
using Aspose.Pdf;
//using Microsoft.AspNetCore.Mvc;
using System.IO;
//using FlySky.Infra.Repository;
//using Microsoft.AspNetCore.Http;

namespace FlySky.Infra.Invoice
{
    public class Email
    {
        public static void send(string userEmail, string pdf)
        {
            //SmtpClient smtp = new SmtpClient("smtp-mail.outlook.com", 587);
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            MailMessage mail = new MailMessage();
            //   SmtpClient SmtpServer = new SmtpClient("smtp-mail.outlook.com", 587);
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com", 587);
            //   mail.From = new MailAddress("smtp.service.asp@outlook.com"); // outlook email here
            mail.From = new MailAddress("storeran748@gmail.com"); // outlook email here
            mail.To.Add(userEmail);
            mail.Subject = "Purchase Invoice";
            mail.Body = "The Recipe that you Request is accepted, Please visit the website to complete";
           // smtp.Credentials = new NetworkCredential("smtp.service.asp@outlook.com", "shgh9999"); // authenticated
            smtp.Credentials = new NetworkCredential("storeran748@gmail.com", "ouwsljvfgxqyefpp"); // authenticated
            Attachment data = new Attachment(pdf);
            smtp.EnableSsl = true;
            mail.Attachments.Add(data);
            smtp.Send(mail);
        }


        public void GenerateFlightBookingPdf(BankData data)
        {
            //ReservedFlightRepository r = new ReservedFlightRepository();
            
            // Create a new PDF document
            Document pdfDocument = new Document();

            // Add a page to the PDF document
            Page page = pdfDocument.Pages.Add();

            // Create a text fragment for the title
            TextFragment titleFragment = new TextFragment("Flight Booking Confirmation");
            titleFragment.TextState.FontSize = 18;
            titleFragment.TextState.FontStyle = FontStyles.Bold;
            titleFragment.HorizontalAlignment = HorizontalAlignment.Center;
            page.Paragraphs.Add(titleFragment);

            // Create a text fragment for the flight details
            TextFragment flightDetails = new TextFragment("Flight Details:");
            flightDetails.TextState.FontSize = 14;
            flightDetails.TextState.FontStyle = FontStyles.Bold;
            page.Paragraphs.Add(flightDetails);
           string message = $"Departure Date : {data.DepartureDate} \n Arrival Date : {data.ArrivalDate} \n Number Of Ticket : {data.NumOfTicket} \n Reserved Date: {data.ReservedDate} \n Total Price: {data.TotalPrice}";
            // Create a text fragment for the flight information
           TextFragment flightInfo = new TextFragment(message);
           flightInfo.TextState.FontSize = 12;
            page.Paragraphs.Add(flightInfo);

            // Save the PDF document to a file
            string pdfFilePath = "FlightBookingConfirmation.pdf";
            pdfDocument.Save(pdfFilePath);
            send(data.UserEmail, pdfFilePath);


            // You can now use the pdfFilePath to send the PDF as an attachment in an email or provide a download link.

        }


    }
}
