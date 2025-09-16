using CommunityToolkit.Mvvm.Messaging.Messages;

namespace CondoSphere.Mobile.Messages
{
    public class LoginSuccessMessage : ValueChangedMessage<bool>
    {
        public LoginSuccessMessage() : base(true) { }
    }
}