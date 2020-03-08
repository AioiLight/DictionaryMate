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
                // 置換候補が6つ以上あれば、複数同じ単語で登録する必要がある
                for (var i = item.Replace.Length; 0 < i ; i -= 5)
                {
                    var replace = string.Join('\t', item.Replace.Skip(item.Replace.Length - i).Take(5));
                    sb.Append(
                        $"{item.Pronounce}\t{item.Word}\t{SpeechToString(item.Speech)}\t{item.Comment}\t{replace}\r\n"
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
    }
}
