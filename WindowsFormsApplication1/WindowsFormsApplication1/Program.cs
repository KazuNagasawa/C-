using System;
using System.Drawing;
using System.Windows.Forms;

class Program
{
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.Run(new Form1());
    }
}

class Form1 : Form
{
    Timer timer = new Timer();  //タイマ

    public Form1()
    {
        timer.Interval = 1000;  //更新間隔（ミリ秒）
        //タイマ用のイベントハンドラを登録
        timer.Tick += new EventHandler(timer_Tick);
        //タイマ用のイベントハンドラをフォームに登録
        this.Load += new EventHandler(timer_Tick);
        timer.Start();  //タイマON
    }
    //Tickイベントのイベントハンドラ
    void timer_Tick(object sender, EventArgs e)
    {
        //現在日時を取得
        DateTime datetime = DateTime.Now;
        //タイトルバーに現在日時を表示
        this.Text = datetime.ToLongTimeString();

    }
}