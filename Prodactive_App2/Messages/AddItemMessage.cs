using CommunityToolkit.Mvvm.Messaging.Messages;

namespace Prodactive_App2.Messages;

public class ModifyItemMessage : ValueChangedMessage<string>
{
    public ModifyItemMessage(string value) : base(value)
    {

    }
}