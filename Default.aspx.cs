using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataAdapter da;
    DataSet ds;


    void mycon()
    {
        con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True");
        con.Open();
    }

    void CityFill()
    {
        mycon();
        cmd = new SqlCommand("select * from City_Master", con);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        DropDownList1.DataSource = ds;
        DropDownList1.DataTextField = "City";
        DropDownList1.DataValueField = "C_Id";
        DropDownList1.DataBind();
        DropDownList1.Items.Insert(0, "---Select City----");
        DropDownList1.Items[0].Value = "0";
        con.Close();

    }
    void GrideFill()
    {
        mycon();
        cmd = new SqlCommand("select u.Id,u.Name,u.Email,u.Password,u.Gender,c.City,u.Image,u.Mobile,u.Rdate from User_Master As u Inner join City_Master As c On u.Id=c.C_Id", con);
        // cmd = new SqlCommand("select * from User_Master As u Inner join City_Master As c On u.Id=c.C_Id", con);

        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();
        con.Close();

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            CityFill();
            mycon();
            if (Request.QueryString["edit"] != null)
            {



                cmd = new SqlCommand("Select * from User_Master where Id=@id", con);
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(Request.QueryString["edit"].ToString()));
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtname.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                    txtemail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                    txtpassword.Text = ds.Tables[0].Rows[0]["Password"].ToString();
                    if (ds.Tables[0].Rows[0]["Gender"].ToString() == "Male")
                    {
                        RadioButton1.Checked = true;
                    }
                    else
                    {
                        RadioButton2.Checked = true;

                    }
                    DropDownList1.Text = ds.Tables[0].Rows[0]["City"].ToString();
                    txtmobile.Text = ds.Tables[0].Rows[0]["Mobile"].ToString();
                    con.Close();
                    btnsubmit.Text = "Update";

                }
            }

        }
        GrideFill();
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        mycon();
        string path = "";
        if (Request.QueryString["edit"] != null)
        {
            cmd = new SqlCommand("Update User_Master set Name=@name,Email=@email,Password=@password,Gender=@gender,City=@city,Mobile=@mobile,@imgs where Id=@id",con);
            cmd.Parameters.AddWithValue("@name", txtname.Text);
            cmd.Parameters.AddWithValue("@email", txtemail.Text);
            cmd.Parameters.AddWithValue("@password", txtpassword.Text);
            string gen = "";
            if (RadioButton1.Checked)
            {
                gen = RadioButton1.Text;
            }
            else
            {
                gen = RadioButton1.Text;

            }
            cmd.Parameters.AddWithValue("@gender", gen);
            cmd.Parameters.AddWithValue("@city", DropDownList1.Text);
            if (FileUpload1.HasFile)
            {
                FileUpload1.SaveAs(Server.MapPath("~/Images/") + FileUpload1.FileName);
                path = "~/Images/" + FileUpload1.FileName;

            }
            if (path != null)
            {
                cmd.Parameters.AddWithValue("@imgs", path);

            }
            else
            {
                cmd.Parameters.AddWithValue("@imgs", Image1.ImageUrl);

            }
            cmd.Parameters.AddWithValue("@mobile", txtmobile.Text);
            cmd.Parameters.AddWithValue("@rdate", System.DateTime.Now.ToString());
            cmd.Parameters.AddWithValue("@id", Request.QueryString["edit"].ToString());

            cmd.ExecuteNonQuery();
            con.Close();
            GrideFill();
            Response.Write("<script>alert('Succefully Update Data....')</script>");
            txtname.Text = "";
            txtemail.Text = "";
            txtpassword.Text = "";
            txtmobile.Text = "";
            DropDownList1.SelectedIndex = 0;

        }
        else
        {
            cmd = new SqlCommand("Insert into User_Master Values(@name,@email,@password,@gender,@city,@imgs,@mobile,@rdate)", con);
            cmd.Parameters.AddWithValue("@name", txtname.Text);
            cmd.Parameters.AddWithValue("@email", txtemail.Text);
            cmd.Parameters.AddWithValue("@password", txtpassword.Text);
            string gen = "";
            if (RadioButton1.Checked)
            {
                gen = RadioButton1.Text;
            }
            else
            {
                gen = RadioButton1.Text;

            }
            cmd.Parameters.AddWithValue("@gender", gen);
            cmd.Parameters.AddWithValue("@city", DropDownList1.Text);
            if (FileUpload1.HasFile)
            {
                FileUpload1.SaveAs(Server.MapPath("~/Images/") + FileUpload1.FileName);
                path = "~/Images/" + FileUpload1.FileName;

            }
            cmd.Parameters.AddWithValue("@imgs",path);
            cmd.Parameters.AddWithValue("@mobile", txtmobile.Text);
            cmd.Parameters.AddWithValue("@rdate", System.DateTime.Now.ToString());
            cmd.ExecuteNonQuery();
            con.Close();
            GrideFill();
            Response.Write("<script>alert('Succefully Save Data....')</script>");
            txtname.Text = "";
            txtemail.Text = "";
            txtpassword.Text = "";
            txtmobile.Text = "";
            DropDownList1.SelectedIndex = 0;

        }




    }
}