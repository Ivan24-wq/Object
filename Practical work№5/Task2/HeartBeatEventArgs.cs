using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
namespace MeasuringDevice;

public class HeartBeatEventArs : EventArgs
{
    public DateTime TimeStamp {get;}

    //Конструктор
    public HeartBeatEventArs() : base()
    {
        TimeStamp = DateTime.Now;
    }
}

public delegate void HeartBeatEventHandler(object sender, HeartBeatEventArs ars);