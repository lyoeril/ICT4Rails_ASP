using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Web;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices;
using System.Data;
using System.Configuration;

namespace ICT4RAILS___ASP.NET.Csharp
{
    public class ActiveDirectory
    {
        private string sDomain = "192.168.19.217";
        private string sServiceUser = "Administrator";
        private string sDefaultOU = "DC=local";
        private string sServicePassword = "Welkom123";

        DirectoryEntry DE = new DirectoryEntry("LDAP://192.168.19.217", "Administrator", "Welkom123");
        public bool ValidateUser(string userName, string password)
        {
            PrincipalContext pc = new PrincipalContext(ContextType.Domain, sDomain);
            bool isValid = false;
            isValid = pc.ValidateCredentials(userName, password);
            return isValid;
        }
        public bool AddUser(string username, string firstname, string lastname, string password)
        {
            DirectoryEntry objADAM; // Binding object.
            DirectoryEntry objUser; // User object.

            string strDisplayName = firstname + " " + lastname;
            string strUser = username;
            string strUserPrincipalName = strUser + "@PTS17.local";
            string samacct;

            const long ADS_OPTION_PASSWORD_PORTNUMBER = 6;
            const long ADS_OPTION_PASSWORD_METHOD = 7;
            const int ADS_PASSWORD_ENCODE_CLEAR = 1;

            AuthenticationTypes AuthTypes;
            AuthTypes = AuthenticationTypes.Signing |
                            AuthenticationTypes.Sealing |
                            AuthenticationTypes.Secure;

            string strServer = sDomain; //ip van de server
            string strUserOu = sDefaultOU;
            string strPort = "389";
            int intPort = Int32.Parse(strPort);
            try
            {
                objADAM = new DirectoryEntry("LDAP://" + sDomain, sServiceUser, sServicePassword, AuthTypes);
                objADAM.RefreshCache();
            }
            catch (Exception e)
            {
                throw e;
            }

            try
            {
                //Zorgen dat het wachtwoord niet langer is dan 20 characters
                if (strUser.Length > 19)
                {
                    samacct = strUser.Substring(0, 19);
                }
                else
                {
                    samacct = strUser;
                }
                //NIeuwe gebruiker aanmaken
                objUser = objADAM.Children.Add("CN=" + strUser + ",ou=corp", "user");
                objUser.Properties["displayName"].Add(strDisplayName);
                objUser.Properties["userPrincipalName"].Add(strUserPrincipalName);
                objUser.Properties["mail"].Add(strUserPrincipalName);
                objUser.Properties["sAMAccountName"].Add(samacct);
                objUser.Properties["givenName"].Add(firstname);
                objUser.Properties["sn"].Add(lastname);
                objUser.CommitChanges();
                objUser.RefreshCache();

                //Het wachtwoord instellen van het account
                objUser.Properties["LockOutTime"].Value = 0; //unlock account
                objUser.Invoke("SetOption", new object[] { ADS_OPTION_PASSWORD_PORTNUMBER, intPort });
                objUser.Invoke("SetOption", new object[]
                    {ADS_OPTION_PASSWORD_METHOD,
                     ADS_PASSWORD_ENCODE_CLEAR});
                objUser.Invoke("SetPassword", new object[] { password });

                //Account enablen en zorgen dat het wachtwoord niet gereset hoeft te worden
                objUser.Properties["userAccountControl"].Value = 0x200;
                objUser.Properties["pwdLastSet"].Value = -1;
                objUser.CommitChanges();
                objUser.RefreshCache();

            }
            catch (Exception e)
            {
                Console.WriteLine("Error:   Set password failed.");
                Console.WriteLine("         {0}.", e.Message);
            }
            return true;
        }
    }
}
