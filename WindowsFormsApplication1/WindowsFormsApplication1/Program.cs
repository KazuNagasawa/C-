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
    Button button;

    public Form1()
    {
        button = new Button()
        {
            Text = "Dialog1",
            Location = new Point(20,20),
        };

        button.Click += new EventHandler(buttton_Click);
        this.Controls.Add(button);
        this.Text = "Form1";
    }

    void buttton_Click(object sender,EventArgs e)
    {
        Dialog1 dialog1 = new Dialog1();
        dialog1.ShowDialog();   //モーダルダイアログとして起動
    }

}

class Dialog1 : Form
{
    public Dialog1()
    {
        this.Text = "Dialog1";
        //ダイアログボックス用の設定
        //this.HelpButton = true;
        //this.ShowIcon = true;
        this.MaximizeBox = false;           //最大化ボタン
        this.MinimizeBox = false;           //最小化ボタン    
        this.ShowInTaskbar = false;         //タスクバー上に表示
        this.FormBorderStyle = 
            FormBorderStyle.FixedDialog;    //境界のスタイル
        //this.Location = new Point(120, 30);
        this.StartPosition =
            FormStartPosition.CenterParent; //親フォームの中央に配置


    }
}