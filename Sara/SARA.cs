using Microsoft.Speech.Recognition;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sara
{
    public partial class fmPrincipal : Form
    {
        private SpeechRecognitionEngine SpeechEngine = new SpeechRecognitionEngine();
        private SpeechSynthesizer ss = new SpeechSynthesizer();

        public fmPrincipal()
        {
            InitializeComponent();
        }

        private void LoadSpeech()
        {
            try
            {
                SpeechEngine = new SpeechRecognitionEngine();
                SpeechEngine.SetInputToDefaultAudioDevice();
                Choices csListen = new Choices();
                Choices csCommands = new Choices();
                Choices csNumbers = new Choices();
                for (int i = 0; i < 10; i++)
                    csNumbers.Add(i.ToString());
                csListen.Add("Sara");
                csCommands.Add(GrammarRules.WhatTimeIs.ToArray());
                csCommands.Add(GrammarRules.ARedLedOn.ToArray());
                csCommands.Add(GrammarRules.WhatDateIs.ToArray());
                csCommands.Add(GrammarRules.Shutdown.ToArray());
                csCommands.Add(GrammarRules.Reboot.ToArray());
                csCommands.Add(GrammarRules.StopShutdown.ToArray());
                csCommands.Add(GrammarRules.NetworkConfig.ToArray());
                csCommands.Add(GrammarRules.Cmd.ToArray());
                csCommands.Add(GrammarRules.SaraMemoryUsed.ToArray());

                GrammarBuilder gbListen = new GrammarBuilder();
                GrammarBuilder gbComands = new GrammarBuilder();
                GrammarBuilder gbNumbers = new GrammarBuilder();
                gbListen.Append(csListen);
                gbComands.Append(csCommands);
                gbNumbers.Append(csNumbers);
                gbNumbers.Append(new Choices("vezes", "mais", "menos", "por"));
                gbNumbers.Append(csNumbers);

                Grammar grListen = new Grammar(gbListen);
                Grammar grComands = new Grammar(gbComands);
                Grammar grNumbers = new Grammar(gbNumbers);
                grComands.Name = "Sara";
                grComands.Name = "comands";
                grNumbers.Name = "numbers";

                SpeechEngine.LoadGrammar(grListen);
                SpeechEngine.LoadGrammar(grComands);
                SpeechEngine.LoadGrammar(grNumbers);
                SpeechEngine.SpeechDetected += Detected;
                SpeechEngine.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(Recognized);
                SpeechEngine.AudioLevelUpdated += new EventHandler<AudioLevelUpdatedEventArgs>(AudioLevel);
                SpeechEngine.RecognizeAsync(RecognizeMode.Multiple);

                ss.SpeakStarted += new EventHandler<SpeakStartedEventArgs>(SpeakStarted);
                ss.SpeakProgress += new EventHandler<SpeakProgressEventArgs>(SpeakProgress);
                //sp.SelectVoiceByHints(VoiceGender.Female);
                Speak("Carregando a gramática");
            }
            catch(Exception Ex)
            {
                MessageBox.Show("Ha um erro no carregamento: " + Ex, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Recognized(object o, SpeechRecognizedEventArgs e)
        {
            string Speech = e.Result.Text;
            float Conf = e.Result.Confidence;

                if (Conf > 0.70f)
                {
                    if(e.Result.Text == "Sara")
                    {
                        lblFalaSara.Text = "Oi?";
                        for (int i = 0; i < 50; i++)
                        {
                            if (Conf > 0.70f)
                            {
                                lblFala.Text = "Você: " + Speech;
                                switch (e.Result.Grammar.Name)
                                {
                                    case "comands":
                                        Commands.Command(Speech);
                                        break;
                                    case "numbers":
                                        Speak(Calc.Solver(Speech));
                                        break;
                                }
                            }
                            else
                                Speak("Desculpe não ouvi muito bem, acho que sou meio lesada");
                        }
                    }
                }
                   
        }

        private void Detected(object o, SpeechDetectedEventArgs e)
        {
           // MessageBox.Show(SpeechEngine.Recognize().ToString());
        }


        public void Speak(string text)
        {
            ss.SelectVoiceByHints(VoiceGender.Female);
            ss.SpeakAsync(text);
        }

        public void Speak(string[] texts)
        {
            Random rn = new Random();
            ss.SelectVoiceByHints(VoiceGender.Female);
            Speak(texts[rn.Next(0, texts.Length)]);
        }

        public void Speak(string[] respond, string text)
        {
            Random rn = new Random();
            ss.SelectVoiceByHints(VoiceGender.Female);
            Speak(respond[rn.Next(0, respond.Length)] + text);
        }

        public void Speak(string[] respond, string[] texts)
        {
            Random rn = new Random();
            ss.SelectVoiceByHints(VoiceGender.Female);
            Speak(respond[rn.Next(0, respond.Length)] + texts);
        }

        private void SpeakStarted(object o, SpeakStartedEventArgs e)
        {
            // Eventos para o começo da fala
        }

        private void SpeakProgress(object o, SpeakProgressEventArgs e)
        {
            lblFalaSara.Text = "Sara: " + e.Text;
        }

        private void AudioLevel(object o, AudioLevelUpdatedEventArgs e)
        {
            this.pbMic.Maximum = 100;
            this.pbMic.Value = e.AudioLevel;
        }

        private void SARA_Load(object sender, EventArgs e)
        {
            LoadSpeech();
            Speak("Já carreguei os arquivos");
        }
    }
}
