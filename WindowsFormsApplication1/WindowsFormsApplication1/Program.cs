using System;
using System.Drawing;
using System.Windows.Forms;

class button03
{
    public static void Main()
    {
        MyForm mf = new MyForm();
        MyButton mb1 = new MyButton("ボタン１", mf, new Point(10, 10));
        MyButton mb2 = new MyButton("ボタン２",mf,new Point(20+mb1.Width,10));

        Application.Run(mf);
    }
}

class MyForm : Form
{
    public MyForm()
    {
        Text = "プログラム設計学習";
        BackColor = SystemColors.Window;

    }
}

class MyButton : Button
{
    string btnstr;
    public MyButton(string str,Form form,Point pnt)
    {
        Text = str;
        Parent = form;
        Location = pnt;
        BackColor = SystemColors.Control;
        btnstr = str;

    }

    protected override void OnClick(EventArgs e)
    {
        base.OnClick(e);
        MessageBox.Show(btnstr + "が押されました", "プログラム設計学習"
            , MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
    }
}