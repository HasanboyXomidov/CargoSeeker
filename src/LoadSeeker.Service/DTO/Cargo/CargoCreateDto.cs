﻿using CargoSeeker.Domain.Enums.CargoEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoSeeker.Service.DTO.Cargo;

public class CargoCreateDto
{
    public long userId { get; set; }
    public string cargo { get; set; } = string.Empty;
    public float cargo_Weight { get; set; }
    public float cargo_Volume { get; set; }
    public DateTime startingTime { get; set; } // Cargos delivering starting day
    public int day_after_archive { get; set; } // Archivize after Day
    public string StartLoadingPlace { get; set; } = string.Empty; // Starting Loading Place
    public double LoadingLattitude { get; set; }// Loading Coordinates
    public double LoadingLongtitude { get; set; }// Loading Coordinates
    public TimeOnly LoadingStartTime { get; set; }// Loading Start Time(Hours:Min)
    public TimeOnly LoadingFinishTime { get; set; }// Loading Start Time(Hours:Min)
    public string FinishUnloadingPlace { get; set; } = string.Empty; // Finishing Unloading Place
    public double UnloadingLattitude { get; set; }//  Unloading Place Coordinates
    public double UnloadingLongtitude { get; set; }//  Unloading Place Coordinates
    public TimeOnly  StartUnloading { get; set; }// Start Unloading Time(Hours:Min)
    public TimeOnly FinishUnloading { get; set; }// Start Unloading Time (Hours:Min)
    public string BodyType { get; set; } = string.Empty;// Trailers Body Type
    public float Bid { get; set; }// Payment Bid (Taklif Pul)
    public CargoPaymentTypeEnum payment_type { get; set; } // Hisob kitob Turi Km yoki Soat ga qarab
    public string description { get; set; } = string.Empty;
    public int PostCargoAfterMinut { get; set; } = 0;
    public bool is_active { get; set; }
}
