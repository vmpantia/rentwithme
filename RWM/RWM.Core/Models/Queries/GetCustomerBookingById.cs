﻿using MediatR;
using RWM.Domain.Models.Views;

namespace RWM.Core.Models.Queries
{
    public record GetCustomerBookingById(Guid CustomerId, Guid BookingId) : IRequest<BookingView> { }
}
