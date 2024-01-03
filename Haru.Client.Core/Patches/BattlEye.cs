// Prevent BE from detecting injected assemblies.

using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Haru.Reflection;
using Haru.Client.Shared;

namespace Haru.Client.Core.Patches
{
    public class BattlEye : APatch
    {
        private static readonly PropertyInfo _succeed;
        private static readonly MethodInfo _mi;

        static BattlEye()
        {
            var name = "RunValidation";
            var type = PatchConsts.EftTypes.Single(x => x?.GetMethod(name) != null);

            _succeed = type.GetProperties().Single(x => x.Name == "Succeed");
            _mi = type.GetMethod(name);
        }

        public BattlEye() : base()
        {
            Id = "com.Haru.Client.battleye";
            Type = EPatchType.Prefix;
        }

        protected override MethodBase GetOriginalMethod()
        {
            return _mi;
        }

        protected static bool Patch(ref Task __result, object __instance)
        {
            _succeed.SetValue(__instance, true);

            __result = Task.CompletedTask;
            return false;
        }
    }
}