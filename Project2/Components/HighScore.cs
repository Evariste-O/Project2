using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2.Components
{
    [Table("StuffDataModel")]
    internal class HighScore
    {
        [PrimaryKey]
        public int Id { get; set; }
        public int Score { get; set; }
    }
}
