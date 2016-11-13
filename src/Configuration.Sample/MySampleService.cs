using Configuration.Sample.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Configuration.Sample
{
    public class MySampleService : IMySampleService
    {
        private IOptionsMonitor<MySettings> _settings;
        private IDisposable _configWatcher;

        public MySettings Settings { get { return _settings.CurrentValue; } }

        public MySampleService(IOptionsMonitor<MySettings> settings)
        {
            _settings = settings;
            Settings.MySettingsNumber += 10;
            _configWatcher = _settings.OnChange(ConfigChanged);
            //access options with _settings.CurrentValue.[PropertyName]
        }

        ~MySampleService()
        {
            if (_configWatcher != null)
            {
                _configWatcher.Dispose();
                _configWatcher = null;
            }
        }

        private void ConfigChanged(MySettings currentConfig)
        {
            Console.WriteLine("Config changed!");
        }
    }
}
