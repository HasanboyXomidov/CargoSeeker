using CargoSeeker.Domain.Entities.Users;
using CargoSeeker.Domain.Enums.TransportEnums;
using LoadSeeker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace CargoSeeker.Domain.Entities.Transports

//    INSERT INTO public.transport(
// userid, bodytype, bodycapacity, bodyvolume, bodylength, bodywidth, bodyheight, permission, startinglocation, endinglocation, startingtime, archivizeafterday, payment, is_active, created_at, updated_at) 
//    VALUES(@userId,@Bodytype,@BodyCapacity,@BodyVolume,@BodyLength,@BodyWidth,@BodyHeight,@Permission,@StartingLocation,@EndingLocation,@StartingTime,@ArchivizeAfterDay,@Payment,@isActive,@created_at,@updated_at);

{
    public class Transport: Auditable
{
        public long userId { get; set; }            
        public string Bodytype { get; set; }=string.Empty;
        public float BodyCapacity { get; set; }
        public float BodyVolume { get ; set; }
        public float BodyVoluem { get;set ; }
        public float BodyLength { get; set; }
        public float BodyWidth { get; set; }
        public float BodyHeight { get; set; }
        public string Permission { get; set; } = string.Empty;
        public string StartingLocation { get; set; }=string.Empty;
        public string EndingLocation { get; set;}=string.Empty;
        public DateTime StartingTime { get; set; }
        public int ArchivizeAfterDay { get; set; } = 2;
        public string Payment { get; set; } = string.Empty;
        public bool isActive { get; set; } = true;
     }
}
