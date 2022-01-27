using System;
using System.Speech.Recognition;
using System.Globalization;

namespace SpeechRecognition
{
    class Program
    {
        static void Main(string[] args)
        {
             using(SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine(GetCultureInfo())){
         
                recognizer.LoadGrammar(new DictationGrammar());
                recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(recognizer_SpeechRecognized);
                recognizer.SetInputToDefaultAudioDevice();
                recognizer.RecognizeAsync(RecognizeMode.Multiple);
                while(true){
                    Console.ReadLine();
                }
         
         
            }
        }
        static void recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e){
            System.Console.WriteLine("Recognized text: "+ e.Result.Text);
        }

        static CultureInfo GetCultureInfo(){
            System.Console.WriteLine("Please type your country code(en/fr/tr/etc..):");
            var cultureInfo = CultureInfo.GetCultureInfo(Console.ReadLine());
            return cultureInfo;
        }
    }
}
