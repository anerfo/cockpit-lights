namespace CockpitLights.Msfs
{
    internal abstract class Constants
    {
        public const int WM_USER_SIMCONNECT = 0x0402;

        public static SimvarRequest RudderPedalRequest = new SimvarRequest
        {
            eDef = DEFINITION.Light,
            eRequest = REQUEST.Zero,
            Name = "LIGHT POTENTIOMETER:13",
            Units = "Percent",
            IsString = false
        };

        public static int ConnectInterval = 1000;
        public static int RequestInterval = 1000;
    }
}
