using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailService
{
    public class MessageTemplateMaker
    {
        public static string InfoHeader;
        public static string VenueAddres;
        public static string PersonEmail;
        public static string TicketID;

       public static string template()
        {
          
          return  @"< div id = ""invoice-POS"" >" +
                        @"< center id =""top"" >" +
                         @"< div class=""logo""></div>" +
                 @"<div class=""info"+">" +
                      @"<h2>" + InfoHeader + "</ h2 >" +
                    "</ div >< !--End Info-- >" +

                  @"< div id = ""mid"" >" +
                    @"< div class=""info"">" +
                      @"<h2>Contact Info</h2>" +
                      @"<p> 
                     Venue Address : " + VenueAddres + "</br>" +
                         "Email:" + PersonEmail + "</ br >" +
                          "TicketID   :" + TicketID + "</ br >" +

                   "</ p > " +
              "</div>" +
              "</body>"+
              "</ html >";



        }
    }
}
