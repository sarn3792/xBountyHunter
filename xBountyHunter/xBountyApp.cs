using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace xBountyHunter
{
    public class xBountyApp : Application
    {
        public xBountyApp()
        {
            MainPage = new NavigationPage(new Views.MainTabbedPage());
        }

        protected override void OnStart()
        {
            base.OnStart();
            Device.StartTimer(new TimeSpan(0, 0, 30), () =>
            {
                try
                {
                    Extras.webServiceConnection ws = new Extras.webServiceConnection(MainPage);
                    ws.connectGET();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            });
        }

    }
}
