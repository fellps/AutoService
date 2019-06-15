using SQLite;
using System;

namespace AutoService.DAL
{
    public class Configuration
    {
        [PrimaryKey]
        public Guid IdConfiguration { get; set; }
        public Guid IdMotorizedCardReader { get; set; }
    }
}
