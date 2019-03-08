﻿using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

using Xamarin.Forms;

using UITestSampleApp.Shared;

namespace UITestSampleApp
{
    public static class BackdoorMethodHelpers
    {
        #region Properties
        static Page CurrentPage => GetCurrentPage();
        #endregion

        #region Methods
#if DEBUG
        public static void BypassLoginScreen() => Application.Current.MainPage.Navigation.PopAsync();

        public static void OpenListViewPage()
        {
            switch (AppLinkHelpers.IsDeepLinkingSupported)
            {
                case true:
                    var app = Application.Current as App;

                    app.OpenListViewPageUsingDeepLinking();
                    break;
                default:
                    NavigateToListViewPage();
                    break;
            }
        }

        public static string GetSerializedListViewPageData()
        {
            var listPageData = GetListPageData();

            var listPageDataAsBase64String = ConverterHelpers.SerializeObject(listPageData);

            return listPageDataAsBase64String;
        }


#endif

        internal static void NavigateToListViewPage()
        {
            // Navigate to List View Page by recreating the Navigation Stack to mimic the user journey
            Device.BeginInvokeOnMainThread(async () =>
            {
                await Application.Current.MainPage.Navigation.PopAsync();
                await Application.Current.MainPage.Navigation.PushAsync(new ListPage());
            });
        }
#if DEBUG

        static List<ListPageDataModel> GetListPageData()
        {
            if (CurrentPage is ListPage listPage)
            {
                var listViewModel = listPage.BindingContext as ListViewModel;
                return listViewModel?.DataList;
            }

            return null;
        }

#endif
        static Page GetCurrentPage()
        {
            if (Application.Current.MainPage.Navigation.ModalStack.Any())
                return Application.Current.MainPage.Navigation.ModalStack.LastOrDefault();

            return Application.Current.MainPage.Navigation.NavigationStack.LastOrDefault();
        }
        #endregion
    }
}
