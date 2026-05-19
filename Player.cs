// ========================================
// Player.cs：プレイヤーの設計図
// ========================================

namespace Janken
{
    // 【classのプロパティとは？】
    // クラスが「持っているデータ」のこと
    // 例：人間クラスなら「名前・年齢・身長」がプロパティ
    // プレイヤークラスなら「名前・勝ち数・負け数」がプロパティ
    public class Player
    {
        // =============================================
        // プロパティ（このクラスが持つデータ）
        // "public" = 外から読み書きできる
        // "string" = 文字列型
        // "{ get; set; }" = 「読める・書ける」という意味
        // =============================================
        //プレイヤーの名前
        public string Name { get; set; }

        //勝った回数
        public int WinCount { get; set; }

        //負けた回数
        public int LoseCount { get; set; }

        //引き分けの回数
        public int DrawCount { get; set; }

        // =============================================
        // コンストラクタ
        // 「new Player("プレイヤー1")」と書いたとき
        // 最初に自動で呼ばれる「初期設定の部屋」
        // 料理で言うと「材料を準備する工程」
        // =============================================
        public Player(string name)
        {
            // this.Name = 「このクラス自身のNameプロパティ」
            // name = 「外から渡されてきた名前」
            this.Name = name;

            // 最初は全部0からスタート
            this.WinCount = 0;
            this.LoseCount = 0;
            this.DrawCount = 0;
        }

        // =============================================
        // 手を選ぶメソッド（プレイヤー用）
        // キーボードから入力を受け取って Hand型 を返す
        // =============================================
        public Hand ChooseHand()
        {
            //選択を表示
            Console.WriteLine($"\n{Name}、手を選んでください:");
            Console.WriteLine(" 1: グー ✊");
            Console.WriteLine(" 2: チョキ ✌️");
            Console.WriteLine(" 3: パー ✋");
            Console.Write("番号を入力:");

            string? input = Console.ReadLine();

            // switch で入力された番号に対応する Hand を返す
            switch (input)
            {
                case "1":
                    return Hand.Rock;
                case "2":
                    return Hand.Scissors;
                case "3":
                    return Hand.Paper;
                default:
                    //１〜３以外が入力されたらグーにする
                    Console.WriteLine("⚠️無効な入力です。グーにします！");
                    return Hand.Rock;
            }
        }

        // =============================================
        // 結果を表示するメソッド
        // =============================================
        public void ShowScore()
        {
            // $"..." の中に {Name} {WinCount} など変数を埋め込む
            Console.WriteLine($"\n{Name} の成績:");
            Console.WriteLine($" 勝ち: {WinCount} 回");
            Console.WriteLine($" 負け: {LoseCount} 回");
            Console.WriteLine($" 引き分け: {DrawCount} 回");
        }
    }
}