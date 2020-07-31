using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppTest.asp
{
    public partial class UploadASP : System.Web.UI.Page
    {
        string fi;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                //多个文件

                // Get the HttpFileCollection
                HttpFileCollection hfc = Request.Files;
                for (int i = 0; i < hfc.Count; i++)
                {

                    HttpPostedFile hpf = hfc[i];
                    if (hpf.ContentLength > 0)
                    {
                        string name = System.IO.Path.GetFileName(hpf.FileName);
                        if (name.Contains("."))
                        {
                            System.Random srd = new Random();
                            int srdName = srd.Next(1000);
                            name = name.Substring(name.LastIndexOf("."), name.Length - name.LastIndexOf("."));
                            name = DateTime.Now.ToString("yyyyMMddhhmmss") + srdName.ToString() + name;
                        }
                        // FileUpload2.PostedFile.SaveAs(Server.MapPath("upimge/") + name);
                        if (hfc.Count == 1)
                        {
                            fi = name;
                        }
                        if (hfc.Count != 1)
                        {
                            //file += name;
                            fi += name + ";";
                        }
                        //创造年,月,日的文件夹
                        //string year = DateTime.Now.Year.ToString();
                        //string month = DateTime.Now.Month.ToString();
                        //string day = DateTime.Now.Day.ToString();
                        //if (Directory.Exists("upload" + "\\" + year) == false)
                        //{
                        //    Directory.CreateDirectory("upload" + "\\" + year);
                        //}
                        //if (Directory.Exists("upload" + "\\" + year + "\\" + month) == false)
                        //{
                        //    Directory.CreateDirectory("upload" + "\\" + year + "\\" + month);
                        //}
                        //if (Directory.Exists("upload" + "\\" + year + "\\" + month + "\\" + day) == false)
                        //{
                        //    Directory.CreateDirectory("upload" + "\\" + year + "\\" + month + "\\" + day);
                        //}
                        //保存地址this.TextBox1.Text ="/" + year + "/" + month + "/" + day +"/"+name;
                        hpf.SaveAs(Server.MapPath("upload") + "\\" + name);
                        //hpf.SaveAs(Server.MapPath("upload") + "\\" + System.IO.Path.GetFileName(hpf.FileName));
                        // Response.Write("<b>File: </b>" + hpf.FileName + "  <b>Size:</b> " +
                        //hpf.ContentLength + "  <b>Type:</b> " + hpf.ContentType + " Uploaded Successfully <br/>");
                    }
                    //this.TextBox1.Text = fi;
                    
                }

            }
            catch (Exception ex)
            {

            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="jsContent"></param>
        //protected void WriteJs(string jsContent)
        //{

        //    ClientScript.RegisterStartupScript(this.GetType(), "writejs", "<script type='text/javascript'>" + jsContent + "</script>");
        //}


    }
}