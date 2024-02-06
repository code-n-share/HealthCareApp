namespace HCI.HealthCare.API.Infrastructure;

public class Slot
{
    public Time StartTime { get; set; }
    public Time EndTime { get; set; }

    public override string ToString() =>
        $"{GetTimeIn12HrClock(this.StartTime)} - {GetTimeIn12HrClock(this.EndTime)}";

    public string GetTimeIn12HrClock(Time time)
    {
        string? minutes = time.Minutes < 10 ? $"0{time.Minutes}" : time.Minutes.ToString();
        if(time.Hours < 12) return $"{time.Hours}:{minutes} AM";
        else {
            if(time.Hours == 12 )return $"{time.Hours}:{minutes} PM";
            else return $"{time.Hours - 12}:{minutes} PM";
        }
    }
}