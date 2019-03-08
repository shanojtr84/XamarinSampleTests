using System;
using System.Linq;
using CrossPlatformUITests.Base;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using UIElement = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;
namespace CrossPlatformUITests.Support
{
    public class XamarinUITestWrapper : BaseScreen
    {
        public XamarinUITestWrapper(IApp app, Platform platform)
            : base(app, platform)
        {

        }

        public void TapOn(UIElement element)
        {
            app.Tap(element);
        }

        public void TypeText(UIElement element, string text)
        {
            app.EnterText(element, text);
        }

        public void DismissDeviceKeyboard()
        {
            app.DismissKeyboard();
        }

        public void WaitForUIElement(UIElement element, string msg, params int[] args)
        {
            int paramslength = args.Length;

            if (paramslength == 1)
            {
                TimeSpan? timeout = TimeSpan.FromSeconds(args[0]);
                app.WaitForElement(element, msg, timeout);
            }
            else
            {
                app.WaitForElement(element,msg);
            }
        }

        public void WaitForUIElementToDisappear(UIElement element, string msg, params int[] args)
        {
            int paramslength = args.Length;

            if (paramslength == 1)
            {
                TimeSpan? timeout = TimeSpan.FromSeconds(args[0]);
                app.WaitForNoElement(element, msg, timeout);
            }
            else
            {
                app.WaitForNoElement(element, msg);
            }
        }

        public string GetUIElementText(UIElement element)
        {
            return UIElementQuery(element).First().Text;
        }

        public AppResult[] UIElementQuery(UIElement element)
        {
            return app.Query(element);
        }

        public AppResult[] QueryByText(string text)

        {
            return app.Query(x => x.Marked(text));
        }

    }
}
