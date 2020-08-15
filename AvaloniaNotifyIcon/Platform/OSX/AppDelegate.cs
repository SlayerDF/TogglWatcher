using Avalonia;
using Avalonia.Controls;
using MonoMac.AppKit;
using MonoMac.Foundation;
using System;
using System.Runtime.InteropServices;
using Serilog;

namespace AvaloniaNotifyIcon.Platform.OSX
{
    /// <summary>
    /// This class is an AppDelegate helper specifically for Mac OSX
    /// Int it's infinite wisdom and unlike Linux and or Windows Mac does not pass in the URL from a sqrl:// invokation 
    /// directly as a startup app paramter, instead it uses a System Event to do this which has to be registered
    /// and listed to.
    /// This requires us to use MonoMac to make it work with .net core
    /// </summary>
    [Register("AppDelegate")]
    public class AppDelegate : NSApplicationDelegate
    {
        public bool IsFinishedLaunching = false;
        [DllImport("/System/Library/Frameworks/IOKit.framework/IOKit")]
        static extern int IOServiceGetMatchingServices(uint masterPort, IntPtr matching, ref int existing);

        [DllImport("/System/Library/Frameworks/IOKit.framework/IOKit")]
        static extern uint IOServiceGetMatchingService(uint masterPort, IntPtr matching);

#pragma warning disable CA2101 // Specify marshaling for P/Invoke string arguments
        [DllImport("/System/Library/Frameworks/IOKit.framework/IOKit")]
#pragma warning restore CA2101 // Specify marshaling for P/Invoke string arguments
        static extern IntPtr IOServiceMatching(string s);

        [DllImport("/System/Library/Frameworks/IOKit.framework/IOKit")]
        static extern IntPtr IORegistryEntryCreateCFProperty(uint entry, IntPtr key, IntPtr allocator, uint options);

        [DllImport("/System/Library/Frameworks/IOKit.framework/IOKit")]
        static extern int IOObjectRelease(int o);

        [DllImport("/System/Library/Frameworks/IOKit.framework/IOKit")]
        static extern int IOIteratorNext(int o);

        [DllImport("/System/Library/Frameworks/IOKit.framework/IOKit")]
        static extern int IORegistryEntryCreateCFProperties(int entry, out IntPtr eproperties, IntPtr allocator, uint options);

        [DllImport("/System/Library/Frameworks/CoreFoundation.framework/CoreFoundation")]
        static extern bool CFNumberGetValue(IntPtr number, int theType, out long value);

        // Instance Window of our App
        Window mainWindow = null;



        public AppDelegate(Window mainWindow)
        {
            this.mainWindow = mainWindow;
            Init();
        }
        public AppDelegate()
        {
            Init();
        }

        /// <summary>
        /// Registers an event for handling URL Invokation
        /// </summary>
        private void Init()
        {
            Log.Information("Initializing Mac App Delegate");
            //Register this Apple Delegate globablly with Avalonia for Later Use
            AvaloniaLocator.CurrentMutable.Bind<AppDelegate>().ToConstant(this);
            NSAppleEventManager.SharedAppleEventManager.SetEventHandler(this, new MonoMac.ObjCRuntime.Selector("handleGetURLEvent:withReplyEvent:"), AEEventClass.Internet, AEEventID.GetUrl);
        }

        /// <summary>
        /// Because we are creating our own mac application delegate we are removing / overriding 
        /// the one that Avalonia creates. This causes the application to not be handled as it should.
        /// This is the Avalonia Implementation: https://github.com/AvaloniaUI/Avalonia/blob/5a2ef35dacbce0438b66d9f012e5f629045beb3d/native/Avalonia.Native/src/OSX/app.mm
        /// So what we are doing here is re-creating this implementation to mimick their behavior.
        /// </summary>
        /// <param name="notification"></param>
        public override void WillFinishLaunching(NSNotification notification)
        {

            if (NSApplication.SharedApplication.ActivationPolicy != NSApplicationActivationPolicy.Regular)
            {
                foreach (var x in NSRunningApplication.GetRunningApplications(@"com.apple.dock"))
                {
                    x.Activate(NSApplicationActivationOptions.ActivateIgnoringOtherWindows);
                    break;
                }
                NSApplication.SharedApplication.ActivationPolicy = NSApplicationActivationPolicy.Regular;
            }
        }

        /// <summary>
        /// Because we are creating our own mac application delegate we are removing / overriding 
        /// the one that Avalonia creates. This causes the application to not be handled as it should.
        /// This is the Avalonia Implementation: https://github.com/AvaloniaUI/Avalonia/blob/5a2ef35dacbce0438b66d9f012e5f629045beb3d/native/Avalonia.Native/src/OSX/app.mm
        /// So what we are doing here is re-creating this implementation to mimick their behavior.
        /// </summary>
        /// <param name="notification"></param>
        public override void DidFinishLaunching(NSNotification notification)
        {

            NSRunningApplication.CurrentApplication.Activate(NSApplicationActivationOptions.ActivateIgnoringOtherWindows);
        }


        /// <summary>
        /// Checks the System's Environment Variable HIDIdleTime which is maintained by apple to register last Keyboard or Mouse Input
        /// </summary>
        /// <returns></returns>
        public static TimeSpan CheckIdleTime()
        {
            long idlesecs = 0;
            int iter = 0;
            TimeSpan idleTime = TimeSpan.Zero;
            if (IOServiceGetMatchingServices(0, IOServiceMatching("IOHIDSystem"), ref iter) == 0)
            {
                int entry = IOIteratorNext(iter);
                if (entry != 0)
                {
                    IntPtr dictHandle;
                    if (IORegistryEntryCreateCFProperties(entry, out dictHandle, IntPtr.Zero, 0) == 0)
                    {
                        NSDictionary dict = (NSDictionary)MonoMac.ObjCRuntime.Runtime.GetNSObject(dictHandle);
                        NSObject value;
                        dict.TryGetValue((NSString)"HIDIdleTime", out value);
                        if (value != null)
                        {
                            long nanoseconds = 0;
                            if (CFNumberGetValue(value.Handle, 4, out nanoseconds))
                            {
                                idlesecs = nanoseconds >> 30; // Shift To Convert from nanoseconds to seconds.
                                idleTime = DateTime.Now - DateTime.Now.AddSeconds(-idlesecs);
                            }
                        }
                    }
                    IOObjectRelease(entry);
                }
                IOObjectRelease(iter);
            }

            return idleTime;
        }
    }
}
