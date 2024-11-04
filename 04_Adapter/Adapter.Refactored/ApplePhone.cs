namespace Adapter.Refactored
{
    public class ApplePhone
    {

        public void Aufladen(LightningLadegerät lightningLadegerät)
        {
            int strom = lightningLadegerät.LiefereStromViaLightning();

            Console.WriteLine($"Apple Phone wird mit {strom} mA aufgeladen.");
        }
    }
}