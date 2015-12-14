using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//This Application A

public partial class ApplA : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnCallWS_Click(object sender, EventArgs e)
    {
        WBForm2XMLReference.WBFormToXMLClient w2xmlc = new WBForm2XMLReference.WBFormToXMLClient();
        WBForm2XMLReference.Transfer transfer = new WBForm2XMLReference.Transfer();
        transfer.customer_name = txtbox_custname.Text;
        transfer.customer_surname = txtbox_custsurname.Text;
        transfer.customer_address = txtbox_custaddress.Text;
        transfer.customer_phone = txtbox_custphone.Text;
        transfer.chair_number = Int32.Parse(txtbox_chairnum.Text);
        transfer.chair_weight = Decimal.Parse(txtbox_chairweight.Text);
        transfer.chair_price = Decimal.Parse(txtbox_chairprice.Text);
        transfer.table_number = Int32.Parse(txtbox_tablenum.Text);
        transfer.table_weight = Decimal.Parse(txtbox_tableweight.Text);
        transfer.table_price = Decimal.Parse(txtbox_tableprice.Text);
        transfer.order_date = DateTime.Now;
        transfer.supplier_name = txtbox_supplname.Text;
        transfer.supplier_address = txtbox_suppladdress.Text;
        transfer.transporter_name = txtbox_transpname.Text;
        transfer.price_per_kilo = Decimal.Parse(txtbox_priceperkilo.Text);

        string response = w2xmlc.CreateXML(transfer);

        lblResponse.Text = response;
        lblResponse.Visible = true;
    }
}