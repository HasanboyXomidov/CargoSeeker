﻿using CargoSeeker.Domain.Enums.GetTransportEnums;
using LoadSeeker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoSeeker.Domain.Entities.GetTransports;

public class GetTransport: Auditable
{
    public long transport_id { get ; set; }
    public long cargoId { get; set; }
    public bool is_accepted { get; set; }
    public string status { get; set; }=string.Empty;
    public string description { get; set; } = string.Empty;
    public float bid { get; set; }
    public string distance_Type { get; set; } = string.Empty;
    public DateTime agreement_Day { get; set; }

}
