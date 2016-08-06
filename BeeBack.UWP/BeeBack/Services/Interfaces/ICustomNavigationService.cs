using System;

namespace BeeBack.Services.Interfaces
{
    public interface ICustomNavigationService
    {
        void NavigateTo(Type type);
        void Navigate(Type type);
    }
}