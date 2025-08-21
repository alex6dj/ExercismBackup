using System;

static class Badge
{
    public static string Print(int? id, string name, string? department)
    {
        var idValue = id == null ? "" : $"[{id}] - ";
        var departmentValue = department == null ? " - OWNER" : $" - {department.ToUpper()}";

        return idValue + name + departmentValue;
    }
}
