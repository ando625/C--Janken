// ========================================
// GameManager.cs：ゲーム全体の進行を管理するクラス
// ========================================

namespace Janken
{
    // 【このクラスの役割】
    // ゲームの「司令塔」
    // Player・Judge・Hand を組み合わせてゲームを進める
    // 料理で言うと「シェフ」
    // Player = 食材、Judge = 調理器具、GameManager = シェフ

    public class GameManager
    {
        // =============================================
        // フィールド（クラスが持つ変数）
        // プロパティと似てるけど、外から直接触わらせたくないとき
        // "private" = このクラスの中からしか使えない
        // =============================================

        // プレイヤーのオブジェクト（Player設計図から作った実体）
        private Player _player;

        // CPUのオブジェクト
        private Player _cpu;

        // ランダムな数を作る道具
        // Random = サイコロみたいなもの
        private Random _random;

        // =============================================
        // コンストラクタ
        // GameManager が new されたとき最初に動く
        // =============================================
        public GameManager()
        {
            // Player クラスの設計図から「プレイヤー」という実体を作る
            // new = 「設計図から実体を作って」
            _player = new Player("プレイヤー");

            // CPU も Player クラスから作る（名前だけ違う）
            _cpu = new Player("CPU");

            // Random オブジェクトを作る
            _random = new Random();
        }

        // =============================================
        // ゲームを開始するメソッド
        // ここがゲームのメインループ
        // =============================================
        public void Start()
        {
            Console.WriteLine("=============================");
            Console.WriteLine("   ✊✌️✋ じゃんけんゲーム ✋✌️✊  ");
            Console.WriteLine("=============================");

            // while(true) = 「終了するまでずっと繰り返す」
            while (true)
            {
                // ----- プレイヤーの手を選ぶ -----
                // _player.ChooseHand() = Player クラスの ChooseHand を呼ぶ
                Hand playerHand = _player.ChooseHand();

                // ----- CPU の手をランダムで決める -----
                Hand cpuHand = GetCpuHand();

                // ----- 結果を表示する -----
                ShowResult(playerHand, cpuHand);

                // ----- 続けるか聞く -----
                Console.Write("\nもう一回やりますか？(y = 続ける / s = スコア / それ以外 = 終了): ");
                string? answer = Console.ReadLine();

                if (answer == "y")
                {
                    continue; // ループの先頭に戻る
                }
                else if (answer == "s")
                {
                    // スコアを表示してから続ける
                    _player.ShowScore();
                    _cpu.ShowScore();
                    continue;
                }
                else
                {
                    // 最終スコアを表示して終了
                    Console.WriteLine("\n===== 最終結果 =====");
                    _player.ShowScore();
                    _cpu.ShowScore();
                    Console.WriteLine("\nまたね！👋");
                    break; // while ループを抜ける
                }
            }
        }

        // =============================================
        // CPU の手をランダムで決めるメソッド
        // private = このクラスの中だけで使う
        // =============================================
        private Hand GetCpuHand()
        {
            // _random.Next(0, 3) = 0以上3未満のランダムな整数を返す
            // つまり 0, 1, 2 のどれかが返ってくる
            int randomNumber = _random.Next(0, 3);

            // (Hand)randomNumber = 数値を Hand型 に変換する
            // 0 → Hand.Rock（グー）
            // 1 → Hand.Scissors（チョキ）
            // 2 → Hand.Paper（パー）
            // これを「キャスト（型変換）」と言う
            return (Hand)randomNumber;
        }

        // =============================================
        // 結果を表示してスコアを更新するメソッド
        // =============================================
        private void ShowResult(Hand playerHand, Hand cpuHand)
        {
            // Judge.GetHandName() で手の名前を日本語に変換
            Console.WriteLine($"\nあなた: {Judge.GetHandName(playerHand)}");
            Console.WriteLine($"CPU:    {Judge.GetHandName(cpuHand)}");
            Console.WriteLine("------------------------------");

            // Judge.Determine() で勝敗を判定
            Judge.Result result = Judge.Determine(playerHand, cpuHand);

            // 勝敗によって表示とスコアを変える
            switch (result)
            {
                case Judge.Result.Win:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("🎉 あなたの勝ち！！");
                    Console.ResetColor();
                    // スコアを更新（+1する）
                    _player.WinCount++;   // ++ = 「1増やして」の省略形
                    _cpu.LoseCount++;
                    break;

                case Judge.Result.Lose:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("😢 あなたの負け...");
                    Console.ResetColor();
                    _player.LoseCount++;
                    _cpu.WinCount++;
                    break;

                case Judge.Result.Draw:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("🤝 引き分け！");
                    Console.ResetColor();
                    _player.DrawCount++;
                    _cpu.DrawCount++;
                    break;
            }
        }
    }
}