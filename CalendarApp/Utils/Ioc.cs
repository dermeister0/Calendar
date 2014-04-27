using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject;

namespace CalendarApp.Utils
{
    public static class Ioc
    {
        public static T Get<T>()
        {
            return (App.Current as App).IocContainer.Get<T>();
        }
    }
}
