using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sara
{
    class Commands
    {
        public static void Command(string Speech)
        {
            if (GrammarRules.WhatTimeIs.Any(x => x == Speech))
                SaraResult.WhatTimeIs();

            if (GrammarRules.ARedLedOn.Any(x => x == Speech))
                SaraResult.ARedLedOn();

            if (GrammarRules.WhatDateIs.Any(x => x == Speech))
                SaraResult.WhatDateIs();

            if (GrammarRules.Shutdown.Any(x => x == Speech))
                SaraResult.Shutdown();

            if (GrammarRules.Reboot.Any(x => x == Speech))
                SaraResult.Reboot();

            if (GrammarRules.StopShutdown.Any(x => x == Speech))
                SaraResult.StopShutdown();

            if (GrammarRules.NetworkConfig.Any(x => x == Speech))
                SaraResult.NetworkConfig();

            if (GrammarRules.Cmd.Any(x => x == Speech))
                SaraResult.OpenCmd();

            if (GrammarRules.SaraMemoryUsed.Any(x => x == Speech))
                SaraResult.SaraMemoryUsed();
        }
    }
}
