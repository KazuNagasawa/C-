using System;
using System.Drawing;
using System.Windows.Forms;

class button04
{
    public static string str;

    public static void Main()
    {
        Size sz = new Size(120,50);
        MyForm mf = new MyForm(sz);
        MyButton mybtn1 = new MyButton(mf,
            new Point(10, 10), sz, 0);

        MyButton mybtn2 = new MyButton(mf,
            new Point(20+mybtn1.Width, 10), sz, 1);

        MyButton mybtn3 = new MyButton(mf,
            new Point(10,20 + mybtn1.Height), sz, 2);

        MyButton mybtn4 = new MyButton(mf,
            new Point(20 + mybtn1.Width, 20 + mybtn1.Height), sz, 3);

        Application.Run(mf);
    }
}

class MyForm : Form
{
    Size bSize;
    public MyForm(Size sz)
    {
        Text = "プログラム設計学習";
        BackColor = SystemColors.Window;
        bSize = sz;
        AutoScroll = true;
        AutoScrollMinSize = new Size(sz.Width*2+20,sz.Height*2+60);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        Graphics g = e.Graphics;
        int x = 10;
        int y = bSize.Height * 2 + 30;
        Font font = new Font("MSゴシック",14);
        g.DrawString(button04.str, font, Brushes.Black,
            x + AutoScrollPosition.X,
            y + AutoScrollPosition.Y);
    }
}
class MyButton : Button
{
    int no;
    public MyButton(Form parent,Point pt,Size sz,int n)
    {
        no = n;
        Parent = parent;
        Location = pt;
        Size = sz;
        BackColor = SystemColors.Control;
        FlatStyle = FlatStyle.Flat;
    }
    protected override void OnClick(EventArgs e)
    {
        base.OnClick(e);
        string str = "ボタン" + (no + 1) + "が押されました";
        button04.str = str;
        Parent.Invalidate();
        MessageBox.Show(str, "プログラム設計実習",
            MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
    }
    protected override void OnMouseHover(EventArgs e)
    {
        base.OnMouseHover(e);
        this.Cursor = Cursors.Hand;
    }

    protected override void OnPaint(PaintEventArgs pevent)
    {
        base.OnPaint(pevent);
        string title = "ボタン";
        Graphics g = pevent.Graphics;
        Brush br;
        switch (no)
        {
            case 0:
                br = Brushes.Red;
                title += "１";
                break;
            case 1:
                br = Brushes.Blue;
                title += "２";
                break;
            case 2:
                br = Brushes.Brown;
                title += "３";
                break;
            case 3:
                br = Brushes.Gold;
                title += "４";
                break;
            default:
                br = Brushes.Black;
                break;
        }
        g.FillRectangle(br,
            new Rectangle(5, 5, this.Width - 10, this.Height - 10));
        Font font = new Font("MSゴシック",14);
        SizeF sz = g.MeasureString(title,font);
        Single x = (this.Width - sz.Width) / 2.0F;
        Single y = (this.Width - sz.Width) / 2.0F;
        g.DrawString(title, font, Brushes.White, x, y);
    }
}