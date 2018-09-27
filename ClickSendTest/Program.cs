using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClickSend;
using ClickSend.Models;

namespace ClickSendTest
{
	class Program
	{
		static void Main(string[] args)
		{
			ClickSendClient client = new ClickSendClient("hoppy1977", "674B779D-3AD8-5AC6-9568-28C8922E6790");

			// POST https://rest.clicksend.com/v3/sms/send

			// Create the SMS object and specify the SMS details
			SmsMessage sms = new SmsMessage();

			sms.Source = "c#"; //Your method of sending

			sms.To = "+610402583189"; // Recipient phone number in E.164 format.
			//sms.ListId = 428;   Your list ID if sending to a whole list. Can be used instead of 'to'.

			sms.Body = DateTime.Now.ToString() + ":\r\n Please note: I am officially declaring today a public holiday, effective now. All staff to go home on full pay immediately.";

			//sms.From = "+610487316033"; //Your sender id - more info: https://help.clicksend.com/SMS/what-is-a-sender-id-or-sender-number.
			sms.From = "John Cullity"; //Your sender id - more info: https://help.clicksend.com/SMS/what-is-a-sender-id-or-sender-number.
			
			//sms.Schedule = 1477476000; //Leave blank for immediate delivery. Your schedule time in unix format 
			sms.CustomString = "Custom kn0ChLhwn6"; //Your reference. Will be passed back with all replies and delivery reports.

			SmsMessageCollection SMSs = new SmsMessageCollection();

			SMSs.Messages = new List<SmsMessage>();
			SMSs.Messages.Add(sms);

			string SMSresult = client.SMS.SendSms(SMSs);

			Console.WriteLine("SMS Result " + SMSresult);
		}
	}
}

