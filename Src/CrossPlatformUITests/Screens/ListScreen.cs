using System;
using CrossPlatformUITests.Support;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using UIElement = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;
namespace CrossPlatformUITests.Screens
{
    public class ListScreen : XamarinUITestWrapper
    {
        public ListScreen(IApp app, Platform platform)
          : base(app, platform)
        {
            WaitForScreenToload();
        }

        private UIElement _GoButton => x => x.Marked("Go");

        public void WaitForScreenToload()
        {
            string  classname = platform == Platform.Android ? "TextView" : "UITableViewLabel";

            UIElement listtemquery = x => x.Marked("Number").Sibling(classname).Text("1");
            
            WaitForUIElement(listtemquery, "List screen not loaded");
        }

        public AppResult[] QueryListItemNumber(string itemnumber)
        {
            string classname = platform == Platform.Android ? "TextView" : "UITableViewLabel";
            UIElement listitemquery = x => x.Marked("Number").Sibling(classname).Text(itemnumber);
            return UIElementQuery(listitemquery);
        }

        public void  TapOnListItem(string itemnumber)
        {
            UIElement listtem = x => x.Marked("Number").Sibling("TextView").Text(itemnumber);
            TapOn(listtem);
        }

    }
}

