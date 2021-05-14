using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sara
{
    class GrammarRules
    {
        public static List<string> WhatTimeIs = new List<string>()
        {
            "Que horas são",
            "Me diga as horas",
            "Poderia me dizer que horas são",
            "Poderia me dizer as horas",
            "Fale as horas"
        };

        public static List<string> WhatDateIs = new List<string>()
        {
            "Que dia é hoje",
            "Você sabe que dia é hoje",
            "Me fale a data",
            "Me fale que dia é hoje",
            "Que dia nós estamos"
        };

        public static List<string> ARedLedOn = new List<string>()
        {
            "Acenda o led",
            "Por favor acenda o led",
            "Luz vermelha"
        };

        public static List<string> Shutdown = new List<string>()
        {
            "Desligue o computador",
            "Por favor desligue",
            "Feche o sistema",
            "Desligue"
        };

        public static List<string> Reboot = new List<string>()
        {
            "Reinicie o computador",
            "Reboot",
            "Reinicie"
        };

        public static List<string> StopShutdown = new List<string>()
        {
            "Não desligue",
            "Não reinicie",
            "Cancele o reboot",
            "Não faça isso"
        };

        public static List<string> NetworkConfig = new List<string>()
        {
            "Configuração de rede",
            "Me fale a configuração de rede"
        };

        public static List<string> Cmd = new List<string>()
        {
            "Abra o cmd",
            "Por favor abra o cmd",
            "Abra o dos",
            "Abra o promp de comando"
        };

        public static List<string> SaraMemoryUsed = new List<string>()
        {
            "Sara, o quanto você esta ocupando de memoria?",
            "Quanto você está gastando de memoria",
            "A memoria que você está usando é"
        };
    }
}
