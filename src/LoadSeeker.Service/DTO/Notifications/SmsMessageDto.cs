using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoSeeker.Service.DTO.Notifications;

public class SmsMessageDto
{
    public string Recipent { get ; set; }=String.Empty; 
    public string Title { get ; set; }=String.Empty;
    public string Content { get; set; } = String.Empty; 
}
