﻿public record RegistryJob(
    string Key,
    string Name,
    object ApplyValue,
    object RevertValue,
    RegistryValueKind Kind = RegistryValueKind.DWord,
    string? Notes = null) :
    IJob
{
    public string Path
    {
        get
        {
            var shortKey = Key
                .Replace("HKEY_LOCAL_MACHINE", "HKLM")
                .Replace("HKEY_CURRENT_CONFIG", "HKCC")
                .Replace("HKEY_CLASSES_ROOT", "HKCR")
                .Replace("HKEY_CURRENT_USER", "HKCU")
                .Replace("HKEY_USERS", "HKU");
            return @$"{shortKey}\{Name}";
        }
    }
}