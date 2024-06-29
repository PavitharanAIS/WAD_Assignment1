using SSR.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSR.DataAccess.Repository.IRepository
{
    public interface IOrderHeaderRepository : IRepository<OrderHeader>
    {
        void Update(OrderHeader obj);
        void UpdateStatus(int id, string orderStatus, string? paymentStatus = null); //updating only OrderStatus and PaymentStatus on OrderHeader Table instead of updating the entire table as in the above line of code.

        void UpdateStripePaymentID(int id, string sessionId, string paymentIntentId);
    }
}
