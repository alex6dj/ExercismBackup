public static class TelemetryBuffer
{
    public static byte[] ToBuffer(long reading)
    {
        var buffer = new byte[9];

        int size;
        bool isSigned;

        switch (reading)
        {
            case >= 0 and <= ushort.MaxValue:
                size = 2;
                isSigned = false;
                break;
            case >= short.MinValue and <= short.MaxValue:
                size = 2;
                isSigned = true;
                break;
            case >= int.MinValue and <= int.MaxValue:
                size = 4;
                isSigned = true;
                break;
            case >= 0 and <= uint.MaxValue:
                size = 4;
                isSigned = false;
                break;
            case >= long.MinValue and <= long.MaxValue:
                size = 8;
                isSigned = true;
                break;
        }
        
        var prefix = isSigned ? (byte)(256 - size) : (byte)size;
        buffer[0] = prefix;

        var payload = BitConverter.GetBytes(reading);
        Array.Copy(payload, 0, buffer, 1, size);

        return buffer;
    }

    public static long FromBuffer(byte[] buffer)
    {
        if (buffer is not { Length: 9 })
            return 0;

        var prefix = buffer[0];
        int size;
        bool isSigned;

        switch (prefix)
        {
            case 2 or 4 or 8:
                size = prefix;
                isSigned = false;
                break;
            case 254:
            case 252:
            case 248:
                size = 256 - prefix;
                isSigned = true;
                break;
            default:
                return 0;
        }

        var payload = new byte[8];
        Array.Copy(buffer, 1, payload, 0, size);

        return size switch
        {
            2 when isSigned => BitConverter.ToInt16(payload, 0),
            2 when !isSigned => BitConverter.ToUInt16(payload, 0),
            4 when isSigned => BitConverter.ToInt32(payload, 0),
            4 when !isSigned => BitConverter.ToUInt32(payload, 0),
            8 when isSigned => BitConverter.ToInt64(payload, 0),
            _ => 0
        };
    }
}
