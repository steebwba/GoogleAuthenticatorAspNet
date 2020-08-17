using Google.Authenticator;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Steven.GoogleAuthenticator.WebForms.Account
{
    public partial class GoogleAuthenticator : Page
    {
        private string SecretKey { get => ViewState["GoogleAuthenticatorSecret"].ToString(); set => ViewState["GoogleAuthenticatorSecret"] = value; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var secretKey = Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 12);

                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var user = manager.FindById(User.Identity.GetUserId());
                TwoFactorAuthenticator tfa = new TwoFactorAuthenticator();

                var setupInfo = tfa.GenerateSetupCode("Google Authenticator WebForms", user.Email, secretKey, false, 3);

                SecretKey = secretKey;

                imgAuthenticatorQRCode.ImageUrl = setupInfo.QrCodeSetupImageUrl;
                litManualKey.Text = setupInfo.ManualEntryKey;
            }
        }

        protected void btnValidate_Click(object sender, EventArgs e)
        {
            TwoFactorAuthenticator tfa = new TwoFactorAuthenticator();
            bool isCorrectPIN = tfa.ValidateTwoFactorPIN(SecretKey, txtValidationCode.Text);

            if (isCorrectPIN)
            {
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var user = manager.FindById(User.Identity.GetUserId());
                manager.SetTwoFactorEnabled(user.Id, true);
                user.IsGoogleAuthenticatorEnabled = true;
                user.GoogleAuthenticatorSecretKey = SecretKey;

                manager.Update(user);

                Response.Redirect("Manage.aspx");
            }

        }
    }
}