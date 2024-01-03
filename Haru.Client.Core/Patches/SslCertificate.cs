// Override certificate checking.

using System.Linq;
using System.Reflection;
using UnityEngine.Networking;
using Haru.Reflection;
using Haru.Client.Shared;

namespace Haru.Client.Core.Patches
{
    public class SslCertificate : APatch
    {
        public SslCertificate() : base()
        {
            Id = "com.Haru.Client.sslcertificate";
            Type = EPatchType.Prefix;
        }

        protected override MethodBase GetOriginalMethod()
        {
            return PatchConsts.EftTypes.Single(x => x.BaseType == typeof(CertificateHandler))
                .GetMethod("ValidateCertificate");
        }

        // todo: proper certificate validation
        protected static bool Patch(ref bool __result)
        {
            __result = true;
            return false;
        }
    }
}