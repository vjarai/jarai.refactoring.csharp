namespace Adapter.Original
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var applePhone = new ApplePhone();

            var lightningLadegerät = new LightningLadegerät();
            applePhone.Aufladen(lightningLadegerät);

            var usbLadegerät = new UsbLadegerät();
            // applePhone.Aufladen(usbLadegerät);   // Geht nicht! Was tun?

            Console.Read();
        }
    }
}