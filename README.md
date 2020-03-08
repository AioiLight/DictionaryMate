# DictionaryMate

JSON フォーマットのファイルからATOK、Microsoft IME、Google 日本語入力の辞書ファイルに変換するツール。

それぞれのIME毎に対応する品詞が違うため、そこは上手い感じに変換されます。

## 例

```json
[
    {
        "pronounce": "すごいけん",
        "word": "すごい剣",
        "speech": "proper",
        "comment": "ゲームに登場するアイテム",
        "autoReplace": false,
        "replace": [
            "そんなにすごくない剣",
            "ちょっとすごい剣",
            "わりとすごい剣",
            "かつて流行った剣",
            "かなりすごい剣",
            "伝説級の剣"
        ]
    },
    {
        "pronounce": "ゆうき",
        "word": "ユウキ",
        "speech": "person",
        "comment": "ゲームに登場するキャラクター",
        "autoReplace": false,
        "replace": [
            "騎士クン",
            "へんたいふしんしゃさん",
            "主さま",
            "お兄ちゃん",
            "弟くん",
            "ユウキの坊ちゃん",
            "王子はん",
            "ドSさん"
        ]
    }
]
```

## 品詞一覧

| noun | 名詞 |
| proper | 固有名詞 |
| family | 姓 |
| name | 名 |
| person | 人名 |
| place | 場所 |
| org | 組織 |
| short | 短縮読み |
| emoji | 絵文字 | 
