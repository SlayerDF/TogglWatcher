using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using MonoMac.AppKit;
using System.Runtime.InteropServices;
using AvaloniaNotifyIcon.Models;
using System;
using AvaloniaNotifyIcon.Platform;
using Avalonia.Controls;
using System.Collections.Generic;
using ReactiveUI;
using TogglWatcher.Views;
using TogglWatcher.ViewModels;
using TogglWatcher.Services.Database;

namespace TogglWatcher
{
    public class App : Application
    {
        public MainWindow MainWindow { get; set; }
        public INotifyIcon NotifyIcon { get; set; }

        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);

            var db = new FakeDatabase();

            MainWindow = new MainWindow
            {
                DataContext = new MainWindowViewModel(db),
            };
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                //if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                //{
                //    NSApplication.Init();
                //    NSApplication.SharedApplication.Delegate = new AvaloniaNotifyIcon.Platform.OSX.AppDelegate();
                //}

                //Type type = Implementation.ForType<INotifyIcon>();
                //if (type != null)
                //{
                //    // If we have one, create an instance for it
                //    NotifyIcon = (INotifyIcon)Activator.CreateInstance(type);

                //    NotifyIcon.ToolTipText = Current.Name;

                //    NotifyIcon.IconPath = RuntimeInformation.IsOSPlatform(OSPlatform.OSX)
                //        ? @"C:\Users\Slaye\Desktop\TogglWatcherRework\TogglWatcher\Assets\toggl.png"
                //        : @"C:\Users\Slaye\Desktop\TogglWatcherRework\TogglWatcher\Assets\toggl.ico";

                //    NotifyIcon.DoubleClick += (s, e) => RestoreMainWindow();
                //    NotifyIcon.ContextMenu = new ContextMenu()
                //    {
                //        Items = new List<ItemsControl>()
                //        {
                //            new MenuItem() { Header = "Open TogglWatcher", Command = ReactiveCommand.Create(RestoreMainWindow) },
                //            new MenuItem() { Header = "Quit TogglWatcher", Command = ReactiveCommand.Create(Exit) }
                //        }
                //    };
                //    NotifyIcon.Visible = true;
                //}

                if (NotifyIcon == null)
                {
                    desktop.MainWindow = MainWindow;
                }
            }

            base.OnFrameworkInitializationCompleted();
        }

        public void RestoreMainWindow()
        {
            var mainWindow = (Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)
                .MainWindow;

            if (mainWindow == null) mainWindow = MainWindow;

            mainWindow.Show();
            // mainWindow.WindowState = WindowState.Normal;
            // mainWindow.BringIntoView();
            // mainWindow.ActivateWorkaround(); // Extension method hack because of https://github.com/AvaloniaUI/Avalonia/issues/2975
            // mainWindow.Focus();

            // Again, ugly hack because of https://github.com/AvaloniaUI/Avalonia/issues/2994
            // mainWindow.Width += 0.1;
            // mainWindow.Width -= 0.1;
        }

        public void Exit()
        {
            (Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)
                .Shutdown(0);
        }
    }
}
