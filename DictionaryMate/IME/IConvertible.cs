using System.Collections.Generic;
using System.Text;

namespace AioiLight.DictionaryMate.IME
{
    public interface IConvertible
    {
        Encoding Encoding { get; }

        string Convert(List<Dictionary> jsonDic);

        string SpeechToString(Speech? speech);
    }
}