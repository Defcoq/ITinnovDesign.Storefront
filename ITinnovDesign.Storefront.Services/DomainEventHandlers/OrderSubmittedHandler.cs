using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ITinnovDesign.Storefront.Infrastructure.Domain.Events;
using ITinnovDesign.Storefront.Infrastructure.Email;
using ITinnovDesign.Storefront.Model.Orders.Events;

namespace ITinnovDesign.Storefront.Services.DomainEventHandlers
{
    public class OrderSubmittedHandler : IDomainEventHandler<OrderSubmittedEvent>
    {
        public void Handle(OrderSubmittedEvent domainEvent)
        {
            StringBuilder emailBody = new StringBuilder();
            string emailAddress = domainEvent.Order.Customer.Email;
            string emailSubject = String.Format("Agatha Order #{0}",
                                                 domainEvent.Order.Id);

            emailBody.AppendLine(String.Format("Hello {0},",
                                 domainEvent.Order.Customer.FirstName));
            emailBody.AppendLine();
            emailBody.AppendLine(
             "The following order will be packed and dispatched as soon as possible.");
            emailBody.AppendLine(domainEvent.Order.ToString());
            emailBody.AppendLine();
            emailBody.AppendLine("Thank you for your custom.");
            emailBody.AppendLine("Agatha's");

            EmailServiceFactory.GetEmailService()
             .SendMail("orders@Agatha.com", emailAddress,
                       emailSubject, emailBody.ToString());
        }
    }

}
