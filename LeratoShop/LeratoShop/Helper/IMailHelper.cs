using LeratoShop.Common;

namespace LeratoShop.Helper
{
    public interface IMailHelper
    {
        Response SendMail(string toName, string toEmail, string subject, string body);

    }
}
