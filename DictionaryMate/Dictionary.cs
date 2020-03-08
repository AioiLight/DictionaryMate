using System;
using System.Collections.Generic;
using System.Text;

namespace AioiLight.DictionaryMate
{
    public class Dictionary
    {
        /// <summary>
        /// 単語
        /// </summary>
        public string Word { get; set; }
        /// <summary>
        /// 発音
        /// </summary>
        public string Pronounce { get; set; }
        /// <summary>
        /// 品詞
        /// </summary>
        public Speech? Speech { get; set; }
        /// <summary>
        /// コメント
        /// </summary>
        public string Comment { get; set; }
        /// <summary>
        /// 自動置換
        /// </summary>
        public bool? AutoReplace { get; set; }
        /// <summary>
        /// 置換候補
        /// </summary>
        public string[] Replace { get; set; }
    }

    /// <summary>
    /// 品詞
    /// </summary>
    public enum Speech
    {
        /// <summary>
        /// 名詞
        /// </summary>
        Noun,
        /// <summary>
        /// 固有名詞
        /// </summary>
        Proper,
        /// <summary>
        /// 姓
        /// </summary>
        Family,
        /// <summary>
        /// 名
        /// </summary>
        Name,
        /// <summary>
        /// 人名
        /// </summary>
        Person,
        /// <summary>
        /// 地名
        /// </summary>
        Place,
        /// <summary>
        /// 組織
        /// </summary>
        Org,
        /// <summary>
        /// 短縮よみ
        /// </summary>
        Short,
        /// <summary>
        /// 顔文字
        /// </summary>
        Emoji
    }
}
