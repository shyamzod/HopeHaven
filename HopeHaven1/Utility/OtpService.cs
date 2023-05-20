using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace HopeHaven1.Utility
{
    public class OtpService
    {
        private readonly string accountSid = "AC082371c61133f7b7fe7c69aecbdfd949";
        private readonly string authToken = "1ef40701600c36e6e9c31bcc15e1586d";
        private readonly string twilioPhoneNumber = "+12543293620";

        public void SendOtp(string phoneNumber,string otp)
        {
            TwilioClient.Init(accountSid, authToken);
            MessageResource.Create(
                from: new PhoneNumber(twilioPhoneNumber),
                to: new PhoneNumber(phoneNumber),
                body: $"Your OTP is: {otp}"
            );
        }

        public string GenerateOtp()
        {
            // Implement your OTP generation logic here
            // It can be a random number or a combination of alphanumeric characters
            return "456";
        }
    }
}