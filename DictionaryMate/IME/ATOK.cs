using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AioiLight.DictionaryMate.IME;

namespace AioiLight.DictionaryMate.IME
{
    internal class ATOK : IConvertible
    {
        public Encoding Encoding
        {
            get
            {
                return Encoding.Unicode;
            }
        }

        public string Convert(List<Dictionary> jsonDic)
        {
            var sb = new StringBuilder();
            
            // ヘッダー
            sb.Append("!!ATOK_TANGO_TEXT_HEADER_1\r\n");

            foreach (var item in jsonDic)
            {
                foreach (var cmnt in item.Comments)
                {
                    var replace = string.Join('\t', cmnt.Replace.Take(5));
                    sb.Append(
                        $"{item.Pronounce}\t{item.Word}\t{SpeechToString(item.Speech)}\t{cmnt.Comment}\t{GetAutoReplace(cmnt.AutoReplace)}\t{replace}\r\n"
                        );
                }
            }


            return sb.ToString();
        }

        public string SpeechToString(Speech? speech)
        {
            return !speech.HasValue
                ? "名詞"
                : (speech.Value switch
                {
                    Speech.Noun => "名詞",
                    Speech.Proper => "固有一般	",
                    Speech.Family => "固有人姓",
                    Speech.Name => "固有人名",
                    Speech.Person => "固有人他",
                    Speech.Place => "固有地名",
                    Speech.Org => "固有組織",
                    Speech.Short => "短縮読み",
                    Speech.Emoji => "顔文字",
                    _ => "名詞",
                });
        }

        private string GetAutoReplace(bool? autoReplace)
        {
            if (!autoReplace.HasValue)
            {
                return "しない";
            }
            else
            {
                return autoReplace.Value ? "する" : "しない";
            }
        }
    }
}
