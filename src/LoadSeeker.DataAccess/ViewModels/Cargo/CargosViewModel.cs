using CargoSeeker.Domain.Enums.CargoEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoSeeker.DataAccess.ViewModels.Cargo;

public class CargosViewModel 
{
    public long id { get ; set; }
    public long userid { get ; set; }   
    public string user_informations { get; set; }=string.Empty;
    public int user_rating { get ; set; }    
    public string cargo { get; set; } = string.Empty;
    public float cargo_Weight { get; set; }
    public float cargo_Volume { get; set; }
    public DateTime startingTime { get; set; }
    public int day_after_archive { get; set; }
    public string StartLoadingPlace { get; set; } = string.Empty;
    public double LoadingLattitude { get; set; }
    public double LoadingLongtitude { get; set; }        
    public string FinishUnloadingPlace { get; set; } = string.Empty;
    public double UnloadingLattitude { get; set; }
    public double UnloadingLongtitude { get; set; }    
    public string BodyType { get; set; } = string.Empty;
    public float Bid { get; set; }
    public CargoPaymentTypeEnum payment_type { get; set; }
    public string description { get; set; } = string.Empty;
    public int PostCargoAfterMinut { get; set; } = 0;
    public bool is_active { get; set; }
    public DateTime created_at { get; set; }

}
