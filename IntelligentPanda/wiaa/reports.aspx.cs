using Rlis.Sql;
using System;
using System.Data;
using System.Web.UI;

public partial class wiaa_reports : System.Web.UI.Page
{
    private DateTime currentDate;
    private int year;

    protected void Page_Load(object sender, EventArgs e)
    {
        currentDate = DateTime.Now;
        year = currentDate.Year;

        if (!Account.hasRights(1))
        {
            Response.Redirect("~/wiaa/index.aspx?permission=false");
        }

        DataSet schoolHallAssign = SqlHelper.ExecuteDataset(Settings.WIAAConnection, CommandType.Text, "SELECT SchoolName, HallAssignment FROM SchoolHall WHERE Year = '" + Settings.Year + "' ORDER BY SchoolName");
        hallAssignGrid.DataSource = schoolHallAssign;
        hallAssignGrid.DataBind();

        //DataSet schoolRefund = SqlHelper.ExecuteDataset(Settings.WIAAConnection, CommandType.Text, "SELECT SchoolName, Refund FROM RefundNeeded WHERE Year = '" + Settings.Year + "' Order by SchoolName");
        DataSet schoolRefund = SqlHelper.ExecuteDataset(Settings.WIAAConnection, CommandType.Text, "SELECT [SchoolName],[Address],[City],[Zip],[Refund] FROM [wiaa].[dbo].[WiaaSchoolReservations] WHERE Year = 2016 AND Refund > 0");
        schoolRefundGrid.DataSource = schoolRefund;
        schoolRefundGrid.DataBind();

        DataSet totalRevenue = SqlHelper.ExecuteDataset(Settings.WIAAConnection, CommandType.Text, "SELECT NumberOfSchools, TotalRevenue FROM TotalRevenue WHERE Year = '" + Settings.Year + "'");
        TotalRevenueGrid.DataSource = totalRevenue;
        TotalRevenueGrid.DataBind();

        DataSet phoneNumbers = SqlHelper.ExecuteDataset(Settings.WIAAConnection, CommandType.Text, "SELECT SchoolName, Phone, ContactName, ContactCellPhone FROM SchoolPhone WHERE Year = '" + Settings.Year + "' order by SchoolName");
        schoolPhoneGrid.DataSource = phoneNumbers;
        schoolPhoneGrid.DataBind();

        DataSet cancelledSchool = SqlHelper.ExecuteDataset(Settings.WIAAConnection, CommandType.Text, "SELECT SchoolName, ContactEmail, Phone FROM CancelledSchools WHERE Year = '" + Settings.Year + "' order by SchoolName");
        cancelledSchoolGrid.DataSource = cancelledSchool;
        cancelledSchoolGrid.DataBind();

        DataSet volMisc = SqlHelper.ExecuteDataset(Settings.WIAAConnection, CommandType.Text, "SELECT FName, LName, MiscCharges, MiscPayment, MiscExplanation FROM VolunteerMiscCharges WHERE Year = '" + Settings.Year + "'AND MiscCharges <> 0 ORDER BY LName, FName");
        volMiscGrid.DataSource = volMisc;
        volMiscGrid.DataBind();

        DataSet volContact = SqlHelper.ExecuteDataset(Settings.WIAAConnection, CommandType.Text, "SELECT FName, LName, Phone, ContactEmail, CASE WHEN RST = 1 THEN 'Yes' ELSE 'No' END as Thursday, CASE WHEN RSF = 1 THEN 'Yes' ELSE 'No' END as Friday, Room FROM WiaaVolunteerInfo WHERE Year = '" + Settings.Year + "' ORDER BY LName, FName");
        volContactGrid.DataSource = volContact;
        volContactGrid.DataBind();

        DataSet schoolsRooms = SqlHelper.ExecuteDataset(Settings.WIAAConnection, CommandType.Text, "SELECT Hall, Room, School FROM ReservedRooms WHERE Reserved = 'True' order by Hall");
        roomsReservedGrid.DataSource = schoolsRooms;
        roomsReservedGrid.DataBind();

        DataSet allTotal = SqlHelper.ExecuteDataset(Settings.WIAAConnection, CommandType.Text, "SELECT SchoolName, Address, City, Zip, PaidBy, Amount, CheckNumber, PaidBy2, Amount2, CheckNumber2, PaidBy3, Amount3, CheckNumber3, (cast(Amount as int)  + cast(Amount2 as int) + cast(Amount3 as int)) as TotalPayment, Refund,  BillTotal As TotalBill FROM WiaaSchoolReservations WHERE Year = " + Settings.Year + " And Cancelled = 0  ORDER BY SchoolName");
        allTotalGrid.DataSource = allTotal;
        allTotalGrid.DataBind();

        DataSet miscCharges = SqlHelper.ExecuteDataset(Settings.WIAAConnection, CommandType.Text, "SELECT SchoolName, MiscCharges, MiscPayment FROM WiaaSchoolReservations WHERE Year = " + Settings.Year + " And Cancelled = 0 AND MiscCharges <> 0 ORDER BY SchoolName");
        miscChargesGrid.DataSource = miscCharges;
        miscChargesGrid.DataBind();

        DataSet numReservations = SqlHelper.ExecuteDataset(Settings.WIAAConnection, CommandType.Text, "SELECT SchoolName, CONVERT(varchar, ExpectedArrival, 100) as ArrivalTime, (CASE WHEN MST > MSF THEN MST ELSE MSF END) + (CASE WHEN MDT > MDF THEN MDT ELSE MDF END) + (CASE WHEN MTT > MTF THEN MTT ELSE MTF END) + (CASE WHEN MStudyT > MStudyF THEN MStudyT ELSE MStudyF END) + (CASE WHEN MEagleST > MEagleSF THEN MEagleST ELSE MEagleSF END) +"
      + " (CASE WHEN MEagleDT > MEagleDF THEN MEagleDT ELSE MEagleDF END) + (CASE WHEN FST > FSF THEN FST ELSE FSF END) + (CASE WHEN FDT > FDF THEN FDT ELSE FDF END) + (CASE WHEN FTT > FTF THEN FTT ELSE FTF END) + (CASE WHEN FStudyT > FStudyF THEN FStudyT ELSE FStudyF END) + (CASE WHEN FEagleST > FEagleSF THEN FEagleST ELSE FEagleSF END) + (CASE WHEN FEagleDT > FEagleDF THEN FEagleDT ELSE FEagleDF END)"
      + " AS TotalRoomsNeeded, CASE WHEN [SpecNeeds] = 1 THEN 'True' ELSE 'False' END AS SpecNeeds, CASE WHEN SpecNeedsRoomsT > SpecNeedsRoomsF THEN SpecNeedsRoomsT ELSE SpecNeedsRoomsF END AS SpecRoomsNeeded FROM [wiaa].[dbo].[WiaaSchoolReservations] WHERE Year =" + Settings.Year + " ORDER BY ExpectedArrival, SchoolName");
        numReservationsGrid.DataSource = numReservations;
        numReservationsGrid.DataBind();

        DataSet arrivalTimes = SqlHelper.ExecuteDataset(Settings.WIAAConnection, CommandType.Text, "SELECT [SchoolName],CONVERT(varchar, ExpectedArrival, 100) as ArrivalTime FROM [wiaa].[dbo].[WiaaSchoolReservations] WHERE Year = " + Settings.Year);
        arrivalTimesGrid.DataSource = arrivalTimes;
        arrivalTimesGrid.DataBind();

        DataSet volRes = SqlHelper.ExecuteDataset(Settings.WIAAConnection, CommandType.Text, "SELECT [Hall] ,[Room],[Bed A],[Bed B],[Bed C],[Bed D] FROM [wiaa].[dbo].[VolunteerRoomReservations] WHERE [Bed A] IS NOT NULL ORDER BY [Room]");
        volReservationsGrid.DataSource = volRes;
        volReservationsGrid.DataBind();
    }

    //Will export the grid view into an excel file
    protected void exportButton_Click(object sender, EventArgs e)
    {
        Response.Clear();

        Response.AddHeader("content-disposition",
        "attachment;filename=Report.xls");
        Response.Charset = "";

        // If you want the option to open the Excel file without saving than
        // comment out the line below

        // Response.Cache.SetCacheability(HttpCacheability.NoCache);

        Response.ContentType = "application/vnd.xls";

        System.IO.StringWriter stringWrite = new System.IO.StringWriter();

        System.Web.UI.HtmlTextWriter htmlWrite =
        new HtmlTextWriter(stringWrite);

        //Whenever you add a new GridView, you must add another else if here:

        if (Session["Grid"].ToString() == "hallAssignGrid")
        {
            hallAssignGrid.RenderControl(htmlWrite);
        }
        else if (Session["Grid"].ToString() == "schoolRefundGrid")
        {
            schoolRefundGrid.RenderControl(htmlWrite);
        }
        else if (Session["Grid"].ToString() == "TotalRevenueGrid")
        {
            TotalRevenueGrid.RenderControl(htmlWrite);
        }
        else if (Session["Grid"].ToString() == "schoolPhoneGrid")
        {
            schoolPhoneGrid.RenderControl(htmlWrite);
        }
        else if (Session["Grid"].ToString() == "cancelledSchoolGrid")
        {
            cancelledSchoolGrid.RenderControl(htmlWrite);
        }
        else if (Session["Grid"].ToString() == "volMiscGrid")
        {
            volMiscGrid.RenderControl(htmlWrite);
        }
        else if (Session["Grid"].ToString() == "volContactGrid")
        {
            volContactGrid.RenderControl(htmlWrite);
        }
        else if (Session["Grid"].ToString() == "roomsReservedGrid")
        {
            roomsReservedGrid.RenderControl(htmlWrite);
        }
        else if (Session["Grid"].ToString() == "allTotalGrid")
        {
            allTotalGrid.RenderControl(htmlWrite);
        }
        else if (Session["Grid"].ToString() == "miscChargesGrid")
        {
            miscChargesGrid.RenderControl(htmlWrite);
        }
        else if (Session["Grid"].ToString() == "numReservationsGrid")
        {
            numReservationsGrid.RenderControl(htmlWrite);
        }
        else if (Session["Grid"].ToString() == "arrivalTimesGrid")
        {
            arrivalTimesGrid.RenderControl(htmlWrite);
        }
        else if (Session["Grid"].ToString() == "volReservationsGrid")
        {
            volReservationsGrid.RenderControl(htmlWrite);
        }

        Response.Write(stringWrite.ToString());

        Response.End();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        // Confirms that an HtmlForm control is rendered for the

        //specified ASP.NET server control at run time.
    }

    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        String selected = RadioButtonList1.SelectedValue.ToString();
        Session["Selected"] = selected;
    }

    //The case number refers to the value of the radio button that is clicked. The first one
    //has a value of 0, second has a value of 1, etc. You will have to be sure to give each new
    //option a value, and then add a new case for that value.
    protected void generateButton_Click(object sender, EventArgs e)
    {
        int panel = int.Parse(Session["Selected"].ToString());
        switch (panel)
        {
            case 0: panel1.Visible = true;
                panel2.Visible = false;
                panel3.Visible = false;
                panel4.Visible = false;
                panel5.Visible = false;
                panel6.Visible = false;
                panel7.Visible = false;
                panel8.Visible = false;
                panel9.Visible = false;
                panel10.Visible = false;
                panel11.Visible = false;
                panel12.Visible = false;
                panel13.Visible = false;
                Session["Grid"] = "hallAssignGrid";
                goto default;
            case 1: panel2.Visible = true;
                panel1.Visible = false;
                panel3.Visible = false;
                panel4.Visible = false;
                panel5.Visible = false;
                panel6.Visible = false;
                panel7.Visible = false;
                panel8.Visible = false;
                panel9.Visible = false;
                panel10.Visible = false;
                panel11.Visible = false;
                panel12.Visible = false;
                panel13.Visible = false;
                Session["Grid"] = "schoolRefundGrid";
                goto default;
            case 2: panel3.Visible = true;
                panel1.Visible = false;
                panel2.Visible = false;
                panel4.Visible = false;
                panel5.Visible = false;
                panel6.Visible = false;
                panel7.Visible = false;
                panel8.Visible = false;
                panel9.Visible = false;
                panel10.Visible = false;
                panel11.Visible = false;
                panel12.Visible = false;
                panel13.Visible = false;
                Session["Grid"] = "TotalRevenueGrid";
                goto default;
            case 3: panel4.Visible = true;
                panel1.Visible = false;
                panel2.Visible = false;
                panel3.Visible = false;
                panel5.Visible = false;
                panel6.Visible = false;
                panel7.Visible = false;
                panel8.Visible = false;
                panel9.Visible = false;
                panel10.Visible = false;
                panel11.Visible = false;
                panel12.Visible = false;
                panel13.Visible = false;
                Session["Grid"] = "schoolPhoneGrid";
                goto default;
            case 4: panel5.Visible = true;
                panel1.Visible = false;
                panel2.Visible = false;
                panel3.Visible = false;
                panel4.Visible = false;
                panel6.Visible = false;
                panel7.Visible = false;
                panel8.Visible = false;
                panel9.Visible = false;
                panel10.Visible = false;
                panel11.Visible = false;
                panel12.Visible = false;
                panel13.Visible = false;
                Session["Grid"] = "cancelledSchoolGrid";
                goto default;
            case 5: panel6.Visible = true;
                panel1.Visible = false;
                panel2.Visible = false;
                panel3.Visible = false;
                panel4.Visible = false;
                panel5.Visible = false;
                panel7.Visible = false;
                panel8.Visible = false;
                panel9.Visible = false;
                panel10.Visible = false;
                panel11.Visible = false;
                panel12.Visible = false;
                panel13.Visible = false;
                Session["Grid"] = "volMiscGrid";
                goto default;
            case 6: panel7.Visible = true;
                panel1.Visible = false;
                panel2.Visible = false;
                panel3.Visible = false;
                panel4.Visible = false;
                panel5.Visible = false;
                panel6.Visible = false;
                panel8.Visible = false;
                panel9.Visible = false;
                panel10.Visible = false;
                panel11.Visible = false;
                panel12.Visible = false;
                panel13.Visible = false;
                Session["Grid"] = "volContactGrid";
                goto default;
            case 7: panel8.Visible = true;
                panel1.Visible = false;
                panel2.Visible = false;
                panel3.Visible = false;
                panel4.Visible = false;
                panel5.Visible = false;
                panel6.Visible = false;
                panel7.Visible = false;
                panel9.Visible = false;
                panel10.Visible = false;
                panel11.Visible = false;
                panel12.Visible = false;
                panel13.Visible = false;
                Session["Grid"] = "roomsReservedGrid";
                goto default;
            case 8: panel9.Visible = true;
                panel1.Visible = false;
                panel2.Visible = false;
                panel3.Visible = false;
                panel4.Visible = false;
                panel5.Visible = false;
                panel6.Visible = false;
                panel7.Visible = false;
                panel8.Visible = false;
                panel10.Visible = false;
                panel11.Visible = false;
                panel12.Visible = false;
                panel13.Visible = false;
                Session["Grid"] = "allTotalGrid";
                goto default;
            case 9: panel10.Visible = true;
                panel1.Visible = false;
                panel2.Visible = false;
                panel3.Visible = false;
                panel4.Visible = false;
                panel5.Visible = false;
                panel6.Visible = false;
                panel7.Visible = false;
                panel8.Visible = false;
                panel9.Visible = false;
                panel11.Visible = false;
                panel12.Visible = false;
                panel13.Visible = false;
                Session["Grid"] = "miscChargesGrid";
                goto default;
            case 10: panel11.Visible = true;
                panel1.Visible = false;
                panel2.Visible = false;
                panel3.Visible = false;
                panel4.Visible = false;
                panel5.Visible = false;
                panel6.Visible = false;
                panel7.Visible = false;
                panel8.Visible = false;
                panel9.Visible = false;
                panel10.Visible = false;
                panel12.Visible = false;
                panel13.Visible = false;
                Session["Grid"] = "numReservationsGrid";
                goto default;
            case 11: panel12.Visible = true;
                panel1.Visible = false;
                panel2.Visible = false;
                panel3.Visible = false;
                panel4.Visible = false;
                panel5.Visible = false;
                panel6.Visible = false;
                panel7.Visible = false;
                panel8.Visible = false;
                panel9.Visible = false;
                panel10.Visible = false;
                panel11.Visible = false;
                panel13.Visible = false;
                Session["Grid"] = "arrivalTimesGrid";
                goto default;
            case 12: panel13.Visible = true;
                panel1.Visible = false;
                panel2.Visible = false;
                panel3.Visible = false;
                panel4.Visible = false;
                panel5.Visible = false;
                panel6.Visible = false;
                panel7.Visible = false;
                panel8.Visible = false;
                panel9.Visible = false;
                panel10.Visible = false;
                panel11.Visible = false;
                panel12.Visible = false;
                Session["Grid"] = "volReservationsGrid";
                goto default;
            default: break;
        }
    }
}