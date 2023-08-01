using AutoMapper;
using MediatR;


namespace Project1.Application.Features
{
    public abstract class BaseNotificationHandler<TEvent> : INotificationHandler<TEvent> where TEvent : INotification
    {

        protected abstract Task HandleNotificationAsync(TEvent input, CancellationToken cancellationToken);

        public async Task Handle(TEvent notification, CancellationToken cancellationToken)
        {
            await HandleNotificationAsync(notification, cancellationToken);
        }
    }
}