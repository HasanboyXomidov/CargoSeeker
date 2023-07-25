using CargoSeeker.Domain.Enums.TransportEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoSeeker.DataAccess.ViewModels.Transports;

public class TransportViewModel
{
    public long userId { get; set; }
    public string user_informations { get; set; }=string.Empty;
    public int user_rating { get; set; }    
    public TransportBodyTypeEnum Bodytype { get; set; }
    public float BodyCapacity { get; set; }
    public float BodyVolume { get; set; }
    public float BodyVoluem { get; set; }
    public float BodyLength { get; set; }
    public float BodyWidth { get; set; }
    public float BodyHeight { get; set; }
    public TransportPermissionEnum Permission { get; set; }
    public string StartingLocation { get; set; } = string.Empty;
    public string EndingLocation { get; set; } = string.Empty;
    public DateTime StartingTime { get; set; }
    public int ArchivizeAfterDay { get; set; } = 2;
    public TransportPaymentEnum Payment { get; set; }
    public bool isActive { get; set; } = true;
    public DateTime created_at { get; set; }    
}
