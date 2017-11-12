using System;
using System.Drawing;
using System.Windows.Forms;

struct MyStr
{
    public static string strTitle;
}

class controlcollection01
{
    public static void Main()
    {
        MyForm mf = new MyForm();
        Button bt1 = new Button();
        bt1.Text = "ボタン１(&1)";
        bt1.BackColor = SystemColors.Control;
        bt1.Location = new Point(10,10);
        bt1.Click += new EventHandler(btn_Click);

        Button bt2 = new Button();
        bt2.Text = "ボタン２(&2)";
        bt2.BackColor = SystemColors.Control;
        bt2.Location = new Point(20+bt1.Width, 10);
        bt2.Click += new EventHandler(btn_Click);

        mf.Controls.Add(bt1);
        mf.Controls.Add(bt2);
        Application.Run(mf);
    }
    static void btn_Click(object sender,EventArgs e)
    {
        Button from = (Button)sender;
        string str;
        if(from.Parent.Controls[0] == (Button)sender)
        {
            str = "ボタン１を押したね";
            MyStr.strTitle = str;
        }
        else if (from.Parent.Controls[1] == (Button)sender)
        {
            str = "ボタン２を押したね";
            MyStr.strTitle = str;
        }
        else
        {
            str = "";
            MyStr.strTitle = default(string);
        }
        from.Parent.Invalidate();
        MessageBox.Show(str, "プログラム設計実習",
            MessageBoxButtons.OK, MessageBoxIcon.Information);

    }
}
class MyForm : Form
{
    public MyForm()
    {
        Text = "プログラム設計学習";
        BackColor = SystemColors.Window;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        Graphics g = e.Graphics;
        Font font = new Font("MSゴシック", 14);
        g.DrawString(MyStr.strTitle, font, Brushes.Black,
            new PointF(10.0F, this.Controls[0].Height + 20.0F));    
    }

}