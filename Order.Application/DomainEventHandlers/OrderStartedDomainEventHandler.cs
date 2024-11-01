using MediatR;
using Order.Application.Repository;
using Order.Domain.AggregateModels.BuyerModels;
using Order.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Order.Application.DomainEventHandlers
{
    public class OrderStartedDomainEventHandler : INotificationHandler<OrderStartedDomainEvent>
    {
        // Repository to manage Buyer entities in the data store
        private readonly IBuyerRepository buyerRepository;

        // Constructor injection for buyerRepository; throws an exception if null
        public OrderStartedDomainEventHandler(IBuyerRepository buyerRepository)
        {
            this.buyerRepository = buyerRepository ?? throw new ArgumentNullException(nameof(buyerRepository));
        }

        // Handles the event when a new order starts
        public Task Handle(OrderStartedDomainEvent notification, CancellationToken cancellationToken)
        {
            // Check if the order's user name is empty
            if (notification.Order.UserName == "")
            {
                // Create a new Buyer entity using the order's user name
                var buyer = new Buyer(notification.Order.UserName);

                // Add the new buyer to the repository and retrieve the new ID (uncomment to enable this functionality)
                // buyerRepository.Add(buyer); // create buyer and get new id

                // Set the order's buyerId with the new Buyer's ID
            }

            // Return a completed task since no asynchronous work is currently done
            return Task.CompletedTask;
        }
    }

}
