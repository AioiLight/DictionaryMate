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
        "comments": [ 
            {
                "comment": "ゲームに登場するアイテム",
                "auto": false,
                "replace": [
                    "そんなにすごくない剣",
                    "ちょっとすごい剣",
                    "わりとすごい剣",
                    "かつて流行った剣",
                    "かなりすごい剣"
                ]
            }
        ]
    },
    {
        "pronounce": "ゆうき",
        "word": "ユウキ",
        "speech": "person",
        "comments": [
            {
                "comment": "ゲームに登場するキャラクター",
                "autoReplace": false,
                "replace": [
                    "騎士クン",
                    "へんたいふしんしゃさん",
                    "主さま",
                    "お兄ちゃん",
                    "弟くん"
                ]
            },
            {
                "comment": "主人公",
                "autoReplace": false,
                "replace": [
                    "ユウキの坊ちゃん",
                    "王子はん",
                    "ドSさん"
                ]
            }
        ]
    }
]
```

### ATOKの出力
```txt
!!ATOK_TANGO_TEXT_HEADER_1
すごいけん	すごい剣	固有一般		ゲームに登場するアイテム	しない	そんなにすごくない剣	ちょっとすごい剣	わりとすごい剣	かつて流行った剣	かなりすごい剣
ゆうき	ユウキ	固有人他	ゲームに登場するキャラクター	しない	騎士クン	へんたいふしんしゃさん	主さま	お兄ちゃん	弟くん
ゆうき	ユウキ	固有人他	主人公	しない	ユウキの坊ちゃん	王子はん	ドSさん
```

### Google 日本語入力の出力
```txt
すごいけん	すごい剣	固有名詞	ゲームに登場するアイテム
ゆうき	ユウキ	人名	ゲームに登場するキャラクター
```

### Microsoft IMEの出力
```txt
!Microsoft IME Dictionary Tool
すごいけん	すごい剣	固有名詞	ゲームに登場するアイテム
ゆうき	ユウキ	人名	ゲームに登場するキャラクター
```

## 品詞一覧

| 名前 | 品詞 |
| ---- | ---- |
| noun | 名詞 |
| proper | 固有名詞 |
| family | 姓 |
| name | 名 |
| person | 人名 |
| place | 場所 |
| org | 組織 |
| short | 短縮読み |
| emoji | 絵文字 | 

## 挙動

Microsoft IME、Google 日本語入力のときは1番目のコメントのコメント文が使われます
