using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneTrip3G.IServices
{
    public interface ISettingService
    {
        T GetSettings<T>() where T : ISetting;
        void SaveSettings<T>(T globalSetting) where T : ISetting;
    }
}
