public static bool sendMailToMenti(MailProps props)
    {
        bool res = true;
        string mailBody = "";
        try
        {
            string UserName = System.Configuration.ConfigurationManager.AppSettings["MailAuthUsername"].ToString();
            string Password = System.Configuration.ConfigurationManager.AppSettings["MailAuthPassword"].ToString();
            System.IO.StreamReader streamReader = new System.IO.StreamReader("../Mail_Template.html");
            mailBody = streamReader.ReadToEnd();
            mailBody = mailBody.Replace("{MENTI_OR_MENTOR}", props.MENTOR_AD_SOYAD);
            mailBody = mailBody.Replace("{TALEPTARIHI}", props.TALEP_TARIHI.ToString());
            mailBody = mailBody.Replace("{NAME}", props.MENTI_AD_SOYAD);
            if (props.RED_NEDENI == "")
            {
                mailBody = mailBody.Replace("{RED_NEDENI_OR_MESAJ}", props.MAIL_ICERIK);       
            }
            else
            {
                mailBody = mailBody.Replace("{RED_NEDENI_OR_MESAJ}", props.RED_NEDENI);
            }
            //props.MAIL_ICERIK + props.BUSINESS_PARTNER_ID.ToString() + props.NOTUNUZ + props.RED_NEDENI;
            //string mailBody = string.Format(sablon.MAIL_ICERIK, Plaka, MuayeneTarihi, DorseMuayeneTarihi, Kullanici);
            MailService service = new MailService();
            service.MailSendWihoutAuth("smtprelay.gmail.com.tr", props.MENTI_MAIL, props.MAIL_BASLIK, mailBody, UserName, Password);
        }
        catch (Exception exc)
        {
            res = false;
        }
        return res;
    }
