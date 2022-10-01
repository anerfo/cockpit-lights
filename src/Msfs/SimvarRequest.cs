using System.Runtime.InteropServices;

namespace CockpitLights.Msfs
{
    public enum DEFINITION
    {
        Light = 0
    };

    public enum REQUEST
    {
        Zero = 0,
        First,
        Second,
        Third,
        Fourth,
        Fivth,
        Sixth,
        Seventh,
        Eighth,
        Ninth
    };

    public enum COPY_ITEM
    {
        Name = 0,
        Value,
        Unit
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    struct Struct1
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string sValue;
    };

    public class SimvarRequest
    {
        public DEFINITION eDef = DEFINITION.Light;
        public REQUEST eRequest = REQUEST.Zero;

        public string? Name { get; set; }
        public bool IsString { get; set; }
        public string? Value { get; set; }
        public string? Units { get; set; }
    };
}
