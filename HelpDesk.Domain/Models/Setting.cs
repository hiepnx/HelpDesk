using System;
using System.Collections.Generic;

namespace HelpDesk.Domain.Models
{
    public partial class Setting
    {
        public string SettingName { get; set; }
        public string SettingValue { get; set; }
        public string DefaultValue { get; set; }
        public string SettingType { get; set; }
        public string SettingDescription { get; set; }
    }
}
