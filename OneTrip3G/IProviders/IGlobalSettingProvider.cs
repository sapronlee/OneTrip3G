using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneTrip3G.IProviders
{
    public interface IGlobalSettingProvider
    {
        T GetGlobalSettings<T>() where T : ISetting;
        void SaveGlobalSettings<T>(T globalSetting) where T : ISetting;
    }
}
