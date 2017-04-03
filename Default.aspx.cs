using System;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Drawing;
using System.IO;
using System.Linq;

public partial class _Default : System.Web.UI.Page
{
    System.Drawing.Image img1;
    Image<Gray, byte> img2;
    Image<Bgr, byte> img3;
    string apath = @"~/Files/2cascade.xml";
    string bpath = @"~/Files/4cascade.xml";
    string cpath = @"~/Files/";
    CascadeClassifier cc, c1;
    static int count = 0, car = 0, ram = 0, proc = 0;
    static string pth, pti, pta;
    Bitmap bi, ni;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        pth = Server.MapPath(cpath);
        if (!Directory.Exists(pth))
        {
            Directory.CreateDirectory(pth);
        }
        if (FileUpload1.HasFile)
        {
            try
            {

                FileUpload1.SaveAs(pth + FileUpload1.FileName);
                Image1.ImageUrl = cpath + FileUpload1.FileName;
                Button1.Text = pth + FileUpload1.FileName;
            }
            catch (Exception ee)
            {
                Button1.Text = ee.Message;
            }
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        pth = Server.MapPath(apath);
        pti = Server.MapPath(bpath);
        pta = Server.MapPath(cpath);
        cc = new CascadeClassifier(pth);
        c1 = new CascadeClassifier(pti);
        img1 = System.Drawing.Image.FromFile(Button1.Text);
        img3 = new Image<Bgr, byte>(new Bitmap(img1));
        img2 = new Image<Gray, byte>(new Bitmap(img1));
        try
        {
            var det = cc.DetectMultiScale(img2, 1.5, 9, Size.Empty, Size.Empty);
            if (det.Count() > 0)
                count++;
            foreach (var de in det)
            {
                img3.Draw(new Rectangle(de.X, de.Y, de.Width, de.Height), new Bgr(0, 255, 0), 3);
            }
            var de1 = c1.DetectMultiScale(img2, 1.5, 5, Size.Empty, Size.Empty);
            if (de1.Count() > 0)
                car++;
            foreach (var d1 in de1)
            {
                img3.Draw(new Rectangle(d1.X, d1.Y, d1.Width, d1.Height), new Bgr(0, 0, 255), 3);
            }
        }
        catch (Exception eee)
        {
            //MessageBox.Show(eee.Message);
            Button2.Text = eee.Message;
        }
        //pictureBox1.Image = img3.ToBitmap();bifile = new Bitmap(img3.ToBitmap());
        bi = new Bitmap(img3.ToBitmap());
        bi.Save(pta + "abc.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
        Image1.ImageUrl = @"~/Files/abc.jpg";
        //System.Threading.Thread.Sleep(500);
    }

}