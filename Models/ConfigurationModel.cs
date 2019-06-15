using SQLite;
using System;

namespace AutoService.Models
{
    public class ConfigurationModel
    {
        [PrimaryKey]
        public Guid IdConfiguration { get; set; }
        public Guid IdMotorizedCardReader { get; set; }
    }
}
