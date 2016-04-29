using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Entities
{
    public class Bank
    {
        public int Id { get; set; }
        //айдишник банка на сайте obmennik.by
        public int ObmennikById { get; set; }
        public string Name { get; set; }
        public List<BankDepartment> Departments { get; set; }
    }
}
