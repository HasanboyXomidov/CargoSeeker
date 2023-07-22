using CargoSeeker.Domain.Enums.TransportEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoSeeker.Service.DTO.Transports;

public class TransportCreateDto
{
    public  long userid { get; set; }
    public TransportBodyTypeEnum bodytype { get; set; }
    public float BodyCapacity { get; set; }
    public float BodyVolume { get; set; }
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
}
