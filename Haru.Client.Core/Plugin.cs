using BepInEx;
using Haru.Reflection;
using Haru.Client.Core.Patches;

namespace Haru.Client.Core
{
    [BepInPlugin("com.Haru.Client.Core", "Haru.Client.Core", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        private readonly APatch[] _patches;

        public Plugin()
        {
            _patches = new APatch[]
            {
                new BattlEye(),
                new SslCertificate()
            };
        }

        // used by bepinex
        private void Awake()
        {
            Logger.LogInfo("Loading: Haru.Core");

            foreach (var patch in _patches)
            {
                patch.Enable();
            }
        }

        // used by bepinex
        private void OnApplicationQuit()
        {
            foreach (var patch in _patches)
            {
                patch.Disable();
            }
        }
    }
}