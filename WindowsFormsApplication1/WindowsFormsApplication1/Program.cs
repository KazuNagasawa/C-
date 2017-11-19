using System;
using System.Drawing;
using System.Windows.Forms;

class imgbtn01
{
    public static void Main()
    {
        Form form = new Form();
        form.Text = "プログラム設計学習";
        form.BackColor = SystemColors.Window;
        form.ClientSize = new Size(230,230);
        MyButton mb1 = new MyButton();
        mb1.Location = new Point(10, 10);

        MyButton mb2 = new MyButton();
        mb2.Location = new Point(20+mb1.Width, 10);

        MyButton mb3 = new MyButton();
        mb3.Location = new Point(10, 20+mb1.Height);

        MyButton mb4 = new MyButton();
        mb4.Location = new Point(20+mb1.Width, 20+mb1.Height);

        form.Controls.Add(mb1);
        form.Controls.Add(mb2);
        form.Controls.Add(mb3);
        form.Controls.Add(mb4);
        Application.Run(form);

    }
}
class MyButton:Button
{
    public MyButton()
    {
        Text = "城";
        TextAlign = ContentAlignment.BottomLeft;
        Font = new Font("MSゴシック",36);
        ForeColor = Color.Green;
        Size = new Size(100,100);
        BackColor = SystemColors.Control;
        Image = new Bitmap(GetType(), "WindowsFormsApplication1.shiro.jpg");
        ImageAlign = ContentAlignment.BottomCenter;
    }

    protected override void OnMouseHover(EventArgs e)
    {
        base.OnMouseHover(e);
        ForeColor = Color.Red;
        Cursor = Cursors.Hand;
    }

    protected override void OnMouseLeave(EventArgs e)
    {
        base.OnMouseLeave(e);
        ForeColor = Color.Green;
        Cursor = Cursors.Arrow;
    }

    protected override void OnClick(EventArgs e)
    {
        base.OnClick(e);
        string str;
        int n = Parent.Controls.IndexOf(this);
        switch (n)
        {
            case 0:
                str = "左上のボタンが押されました";
                break;
            case 1:
                str = "右上のボタンが押されました";
                break;
            case 2:
                str = "左下のボタンが押されました";
                break;
            case 3:
                str = "右下のボタンが押されました";
                break;
            default:
                str = default(string);
                break;
        }
        MessageBox.Show(str, "プログラム設計学習",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

}