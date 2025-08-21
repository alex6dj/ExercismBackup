using System;

static class Appointment
{
    public static DateTime Schedule(string appointmentDateDescription)
    {
        return DateTime.Parse(appointmentDateDescription);
    }

    public static bool HasPassed(DateTime appointmentDate)
    {
        return DateTime.Now > appointmentDate;
    }

    public static bool IsAfternoonAppointment(DateTime appointmentDate)
    {
        var time = TimeOnly.FromDateTime(appointmentDate);
        return time >= new TimeOnly(12, 0) && time < new TimeOnly(18, 0);
    }

    public static string Description(DateTime appointmentDate)
    {
        return $"You have an appointment on {appointmentDate}.";
    }

    public static DateTime AnniversaryDate()
    {
        var today = DateTime.Today;

        return new DateTime(today.Year, 9, 15);
    }
}
