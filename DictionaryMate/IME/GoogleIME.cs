using System;
using System.Collections.Generic;
using System.Text;

namespace AioiLight.DictionaryMate.IME
{
    internal class GoogleIME : IConvertible
    {
        public string Output { get; set; }
        public Encoding Encoding
        {
            get
            {
                return Encoding.Unicode;
            }
        }

        public void Convert(JsonFormat jsonFormat)
        {
            var sb = new StringBuilder();
            foreach (var item in jsonFormat.Dictionaries)
            {
                sb.Append
            }
        }

        public string SpeechToString(Speech? speech)
        {
            return !speech.HasValue
                ? "名詞"
                : (speech.Value switch
                {
                    Speech.Noun => "名詞",
                    Speech.Family => "姓",
                    Speech.Name => "名",
                    Speech.Person => "人名",
                    Speech.Place => "地名",
                    Speech.Org => "組織",
                    Speech.Short => "短縮よみ",
                    Speech.Emoji => "顔文字",
                    _ => "名詞",
                });
        }
    }
}
