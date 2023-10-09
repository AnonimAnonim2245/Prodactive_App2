using Android.Content;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Controls.PlatformConfiguration.AndroidSpecific;
using Microsoft.Maui.Handlers;
using Prodactive_App2;
using Prodactive_App2.View;

namespace Prodactive_App2.View
{
    public class CustomPickerHandler : PickerHandler
    {

        public CustomPickerHandler()
        {
        }

        protected override void ConnectHandler(Android.Widget.EditText nativeView)
        {
            base.ConnectHandler(nativeView);

            if (nativeView != null)
            {
                nativeView.Click += OnPickerClick;
            }
        }

        protected override void DisconnectHandler(Android.Widget.EditText nativeView)
        {
            if (nativeView != null)
            {
                nativeView.Click -= OnPickerClick;
            }

            base.DisconnectHandler(nativeView);
        }
        private void OnPickerClick(object sender, System.EventArgs e)
        {
            // Custom logic to check if the cancel button is pressed
        }
    }
}
