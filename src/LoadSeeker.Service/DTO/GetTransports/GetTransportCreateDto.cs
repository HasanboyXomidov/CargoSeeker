using CargoSeeker.Domain.Enums.GetTransportEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoSeeker.Service.DTO.GetTransports;

public class GetTransportCreateDto
{
    public long transportId { get; set; }
    public long cargoId { get; set; }
    public bool is_accepted { get; set; }
    public GetTransportEnum status { get; set; }
    public string description { get; set; } = string.Empty;
    public float bid { get; set; }
    public TransportDistanceTypeEnum distance_Type { get; set; } = 0;
    public DateTime agreement_Day { get; set; }
}
