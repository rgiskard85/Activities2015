using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AppB : System.Web.UI.Page
{
    MasterReference.MasterClient msc = new MasterReference.MasterClient();

    protected void Page_Load(object sender, EventArgs e)
    {
        Dictionary<int, string> orders = new Dictionary<int, string>();
        orders = msc.GetOrdersMin();
        ddlOrders.Items.Add(new ListItem("Select time of order", "0"));
        foreach (KeyValuePair<int,string> order in orders)
        {
            ddlOrders.Items.Add(new ListItem(order.Value, order.Key.ToString()));
        }
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        Dictionary<string, string> order = new Dictionary<string, string>();
        if (ddlOrders.SelectedValue!=null)
        {
            order = msc.GetOrderByID(Int32.Parse(ddlOrders.SelectedValue));
            if (order!=null)
            {
                order_id.Text = order["order_id"];
                customer_name.Text = order["customer_name"];
                customer_surname.Text = order["customer_surname"];
                supplier_name.Text = order["supplier_name"];
                transporter_name.Text = order["transporter_name"];
                supplier_address.Text = order["supplier_address"];
                customer_address.Text = order["customer_address"];
                tbchair_num.Text = order["chair_num"];
                tbchair_price.Text = order["chair_price"];
                tbchair_weight.Text = order["chair_weight"];
                tbtable_num.Text = order["table_num"];
                tbtable_price.Text = order["table_price"];
                tbtable_weight.Text = order["table_weight"];
                tborder_date.Text = order["order_date"];
            }
        }
        
    }
}