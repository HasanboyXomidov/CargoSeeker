using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoSeeker.DataAccess.ViewModels.GettransportView;

public class GettransportView
{
    public long id { get; set; }  
    public long transportid { get; set; }
    public string bodytype { get; set; }=string.Empty;
    public float bodycapacity { get ; set; }
    public long cargoid { get; set; }
    public string cargo { get; set; } = string.Empty;
    public float cargo_weight { get; set; }
    public DateTime startingtime { get; set; }
    public bool is_accepted { get; set; }
    public string status { get; set; } = string.Empty;
    public string description { get ; set; } = string.Empty;
    public float bid { get; set; }
    public string disctance_type { get; set; } = string.Empty;
    public DateTime agreement_day { get; set; }
    public DateTime created_at { get; set; }

}
