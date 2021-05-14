using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace Sara
{
    public class SaraResult
    {
        private static fmPrincipal fm = new fmPrincipal();
        public static void WhatTimeIs()
        {
            fm.Speak(DateTime.Now.ToShortTimeString());
        }

        public static void WhatDateIs()
        {
            string[] Respond = { "Hoje é", "Estamos em", "Acredito que seja" };
            //string[] Date = { "Dia", DateTime.Now.Day.ToString(), "do", DateTime.Now.Month.ToString(), "de", DateTime.Now.Year.ToString() };
            //Date.
            string Date = string.Format("{0:D}", DateTime.Now);
            fm.Speak(Respond, Date);
        }

        public static void ARedLedOn()
        {
            fm.Speak("Ligando o Led Vermelho");

            SerialPort Com3 = new SerialPort();

            Com3.PortName = "COM3";
            try
            {
                Com3.Open();
                Com3.Write("A");
                Com3.Close();
            }
            catch { return; }

            fm.Speak("Luz acesa");

        }

        public static void Shutdown()
        {
            string[] Result = { "Desligando o computador", "Desligando", "Tchau, até depois", "Preparando para desligar o sistema" };
            fm.Speak(Result);
            Process.Start("shutdown", "/s");
        }

        public static void Reboot()
        {
            string[] Result = { "Reiniciando o computador", "Rebootando", "Já volto" };
            fm.Speak(Result);
            Process.Start("shutdown", "/r");
        }

        public static void StopShutdown()
        {
            string[] Result = { "Não vou desligar", "Cancelando", "Jamais faria isso" };
            fm.Speak(Result);
            Process.Start("shutdown", "/a");
        }

        public static void NetworkConfig()
        {
            fm.Speak(CmdExecute("ping google.com"));
        }

        public static void OpenCmd()
        {
            string[] Result = { "Abrindo o promp de comando", "Abrindo o doss", "Ok", "Já estou fazendo isso" };
            fm.Speak(Result);
            Process.Start("cmd", "ipconfig");
        }

        public static string CmdExecute(string command)
        {
            using (Process process = new Process())
            {
                process.StartInfo.FileName = Environment.GetEnvironmentVariable("comspec");

                // Formata a string para passar como argumento para o cmd.exe
                process.StartInfo.Arguments = string.Format("/c {0}", command);

                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;

                process.Start();
                process.WaitForExit();

                string saida = process.StandardOutput.ReadToEnd();
                return saida;
            }
        }

        public static void SaraMemoryUsed()
        {
            PerformanceCounter CpuCounter = new PerformanceCounter();
            PerformanceCounter RamCounter = new PerformanceCounter("Memory", "Available MBytes");
            string GetCurrentCpuUsage;
            string GetAvaibleRam;

            CpuCounter.CategoryName = "Processor";
            CpuCounter.CounterName = "% Processor Time";
            CpuCounter.InstanceName = "_Total";

            GetCurrentCpuUsage = CpuCounter.NextValue() + "%".ToString();
            GetAvaibleRam = RamCounter.NextValue() + "%".ToString();

            fm.Speak(GetAvaibleRam);
        } 
    }
}
