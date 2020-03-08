using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AioiLight.DictionaryMate.IME
{
    internal class MSIME : IConvertible
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
            sb.Append("!Microsoft IME Dictionary Tool\r\n");

            foreach (var item in jsonDic)
            {
                // 読み、単語が存在しなければ無視
                if (string.IsNullOrEmpty(item.Pronounce)
                    || string.IsNullOrEmpty(item.Word))
                {
                    continue;
                }

                sb.Append(
                    $"{item.Pronounce}\t{item.Word}\t{SpeechToString(item.Speech)}\t{GetComment(item)}\r\n"
                    );
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
                    Speech.Proper => "固有名詞",
                    Speech.Family => "姓",
                    Speech.Name => "名",
                    Speech.Person => "人名",
                    Speech.Place => "地名",
                    Speech.Org => "固有名詞",
                    Speech.Short => "短縮よみ",
                    Speech.Emoji => "顔文字",
                    _ => "名詞",
                });
        }

        private string GetComment(Dictionary dictionary)
        {
            if (dictionary.Comments.Length > 0)
            {
                return dictionary.Comments.First().Comment ?? "";
            }
            else
            {
                return "";
            }
        }
    }
}
