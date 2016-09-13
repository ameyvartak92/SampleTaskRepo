using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;
using System.IO;
using System.Web.Script.Serialization;


public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            bindgrd();
        }
    }

    private void bindgrd()
    {
        ViewState["id"] = null;
        HttpWebRequest request = WebRequest.Create(Utility.getservicebaseURL()+"GetAllStudents") as HttpWebRequest;
        using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
        {
            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception(String.Format(
                "Server error (HTTP {0}: {1}).",
                response.StatusCode,
                response.StatusDescription));
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Students));
            object objResponse = jsonSerializer.ReadObject(response.GetResponseStream());
            Students jsonResponse = objResponse as Students;

            grdcontact.DataSource = jsonResponse.GetAllStudentsResult;
            grdcontact.DataBind();
        }
    }


    protected void grdcontact_PreRender(object sender, EventArgs e)
    {
        if (grdcontact.Rows.Count > 0)
        {
            grdcontact.UseAccessibleHeader = true;
            grdcontact.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
    protected void grdcontact_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "conedit")
        {
            txtRoll.Text = ((Label)((ImageButton)e.CommandSource).Parent.Parent.FindControl("lblroll")).Text;
            txtName.Text = ((Label)((ImageButton)e.CommandSource).Parent.Parent.FindControl("lblname")).Text;
            txtAddress.Text = ((Label)((ImageButton)e.CommandSource).Parent.Parent.FindControl("lblAddress")).Text;
            txtContact.Text = ((Label)((ImageButton)e.CommandSource).Parent.Parent.FindControl("lblcontact")).Text;
            ViewState["id"] = e.CommandArgument.ToString();
        }
        if (e.CommandName == "condelete")
        {
            HttpWebRequest request = WebRequest.Create(Utility.getservicebaseURL()+"DeleteStudent?studentid=" + Convert.ToInt32(e.CommandArgument.ToString())) as HttpWebRequest;
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                if (response.StatusCode != HttpStatusCode.OK)
                    throw new Exception(String.Format(
                    "Server error (HTTP {0}: {1}).",
                    response.StatusCode,
                    response.StatusDescription));
            }
            bindgrd();
        }
    }




    protected void btnsave_Click(object sender, EventArgs e)
    {
        HttpWebRequest request;
        if (ViewState["id"] == null)
            request = WebRequest.Create(Utility.getservicebaseURL()+"AddnewStudent?Name=" + txtName.Text + "&Address=" + txtAddress.Text + "&Contact=" + txtContact.Text + "&Roll=" + txtRoll.Text + "") as HttpWebRequest;
        else
            request = WebRequest.Create(Utility.getservicebaseURL()+"UpdateStudent?id=" + ViewState["id"].ToString() + "&Name=" + txtName.Text + "&Address=" + txtAddress.Text + "&Contact=" + txtContact.Text + "&Roll=" + txtRoll.Text + "") as HttpWebRequest;

        using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
        {
            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception(String.Format(
                "Server error (HTTP {0}: {1}).",
                response.StatusCode,
                response.StatusDescription));
            bindgrd();

        }
        clear();
    }

    private void clear()
    {
        txtContact.Text = txtAddress.Text = txtName.Text = txtRoll.Text = string.Empty;
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        clear();
        ViewState["id"] = null;
    }
}



