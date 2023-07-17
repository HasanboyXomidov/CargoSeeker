using CargoSeeker.Domain.Enums.GetCargoEnums;
using LoadSeeker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoSeeker.Domain.Entities.GetCargos;

public class GetCargo: Auditable
{
    public long transport_id { get; set; }
    public long cargo_id { get;set; }
    public bool is_Accepted { get; set; }
    public GetCargoEnum status { get; set; }
    public string description { get; set; } = string.Empty;
    public float bid { get; set; }
    public DistanceTypeEnum distance_Type { get; set; }
    public DateTime aggrement_day { get; set; }
}
