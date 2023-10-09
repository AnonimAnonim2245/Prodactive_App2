using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Prodactive_App2.Models;
using Prodactive_App2.Services;
using Prodactive_App2.View;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;

#if IOS
using UIKit;
using CoreGraphics;
#endif

namespace Prodactive_App2;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
			{
                fonts.AddFont("icomoon.ttf", "MOON");
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("OpenSans-Bold.ttf", "OpenSansBold");
                fonts.AddFont("OpenSans-BoldItalic.ttf", "OpenSansBoldItalic"); 
				fonts.AddFont("OpenSans-ExtraBold.ttf", "OpenSansExtraBold");
                fonts.AddFont("OpenSans-ExtraBoldItalic.ttf", "OpenSansExtraBoldItalic"); 
				fonts.AddFont("OpenSans-Italic.ttf", "OpenSansItalic");
                fonts.AddFont("OpenSans-Light.ttf", "OpenSansLight");
                fonts.AddFont("OpenSans-LightItalic.ttf", "OpenSansLightItalic");
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("OpenSans-SemiboldItalic.ttf", "OpenSansSemiboldItalic");
            })
           .CustomBehaviour();


#if DEBUG
        builder.Logging.AddDebug();
#endif

        builder.Services.AddSingleton<View.MainPage>();
        builder.Services.AddSingleton<View.ModifyItem>();
        builder.Services.AddSingleton<View.AddItem>();
        builder.Services.AddTransient<View.EditItem>();

        builder.Services.AddSingleton<ViewModel.MainViewModel>();

        builder.Services.AddSingleton<Services.DbConnection>();
        builder.Services.AddSingleton<ViewModel.AddViewModel>();
        builder.Services.AddTransient<ViewModel.EditViewModel>();

        builder.Services.AddSingleton<IValueConverter, Converter.StringToColorConverter>();
        return builder.Build();
       
       
	}
    private static MauiAppBuilder CustomBehaviour(this MauiAppBuilder builder)
    {


        Microsoft.Maui.Handlers.PickerHandler.Mapper.AppendToMapping("BorderlessTimePicker", (handler, view) =>
        {
#if ANDROID
            handler.PlatformView.SetBackgroundColor(Microsoft.Maui.Graphics.Colors.Transparent.ToPlatform());
#elif IOS
            handler.PlatformView.BackgroundColor = Microsoft.Maui.Graphics.Colors.Transparent.ToPlatform();
            handler.PlatformView.Layer.BackgroundColor = Microsoft.Maui.Graphics.Colors.Transparent.ToCGColor();
            handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#endif
        });
        return builder;

    }
}
