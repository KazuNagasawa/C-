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
    ProgressBar progressBar;        //プログレスバー
    NumericUpDown numericUpDown;    //スピンボックス
    public Form1()
    {
        progressBar = new ProgressBar()
        {
            Location = new Point(20,60),
            Width = 200,
            Style = ProgressBarStyle.Marquee,    //スタイル
        };

        numericUpDown = new NumericUpDown()
        {
            Location = new Point(20,20),
            Minimum =0,                     //最小値
            Maximum = 100,                  //最大値
        };

        numericUpDown.ValueChanged += new EventHandler(numericUpDown_ValueChanged);

        this.Controls.AddRange(new Control[]
        {
            numericUpDown,progressBar
        });
    }

    //スピンボックスの値が変更されたときのイベントハンドラ
    void numericUpDown_ValueChanged(object sender,EventArgs e)
    {
        progressBar.Value = (int)numericUpDown.Value;
    }
}