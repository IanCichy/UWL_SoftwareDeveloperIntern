using iTextSharp.text;
using iTextSharp.text.pdf;
using Rlis.Sql;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;

/// <summary>
/// Summary description for PDF
/// </summary>
public class PDF
{
    protected int year;
    protected DateTime currentDate;

    public PDF()
    {
        currentDate = DateTime.Now;
        year = Settings.Year;
    }

    public void createHousingPDF()
    {
        DateTime time = DateTime.Now;
        // Create a Document object
        var document = new Document(PageSize.A4, 50, 50, 120, 25);

        // Create a new PdfWriter object, specifying the output stream
        var output = new MemoryStream();
        var writer = PdfWriter.GetInstance(document, output);

        // Open the Document for writing
        document.Open();

        var titleFont = FontFactory.GetFont("Arial", 20, Font.BOLD);
        var subTitleFont = FontFactory.GetFont("Arial", 16, Font.BOLD);
        var boldTableFont = FontFactory.GetFont("Arial", 14, Font.BOLD);
        var endingMessageFont = FontFactory.GetFont("Arial", 8, Font.ITALIC);
        var bodyFont = FontFactory.GetFont("Arial", 14, Font.NORMAL);

        document.Add(new Paragraph("WIAA State Track Housing Assignment", titleFont));

        var schoolName = new PdfPTable(4);
        schoolName.HorizontalAlignment = 0;
        schoolName.SpacingBefore = 10;
        schoolName.SpacingAfter = 10;
        schoolName.DefaultCell.Border = 0;
        schoolName.SetWidths(new int[] { 1, 2, 1, 2 });
        schoolName.AddCell(new Phrase("School Name:", boldTableFont));
        schoolName.AddCell(HttpContext.Current.Session["School"].ToString());
        schoolName.AddCell(new Phrase("Today's Date: ", boldTableFont));
        schoolName.AddCell(time.ToString());

        var hallAssigned = new PdfPTable(2);
        hallAssigned.HorizontalAlignment = 0;
        hallAssigned.SpacingBefore = 5;
        hallAssigned.SpacingAfter = 5;
        hallAssigned.DefaultCell.Border = 0;
        hallAssigned.SetWidths(new int[] { 1, 2 });
        hallAssigned.AddCell(new Phrase("Hall Assignment:", boldTableFont));
        hallAssigned.AddCell(HttpContext.Current.Session["Hall"].ToString());

        var roomsAssigned = new PdfPTable(2);
        roomsAssigned.HorizontalAlignment = 0;
        roomsAssigned.SpacingBefore = 5;
        roomsAssigned.SpacingAfter = 10;
        roomsAssigned.DefaultCell.Border = 0;
        roomsAssigned.SetWidths(new int[] { 1, 2 });
        roomsAssigned.AddCell(new Phrase("Rooms Assigned:", boldTableFont));
        roomsAssigned.AddCell(HttpContext.Current.Session["Rooms"].ToString());

        var day = new PdfPTable(6);
        day.HorizontalAlignment = 0;
        day.SpacingBefore = 5;
        day.SpacingAfter = 0;
        day.DefaultCell.Border = 0;
        day.SetWidths(new int[] { 2, 1, 2, 1, 1, 2 });
        day.AddCell("Room Type");
        day.AddCell("TH");
        day.AddCell("F");
        day.AddCell("TH");
        day.AddCell("F");
        day.AddCell("Total Rooms Needed");

        var roomReservations = new PdfPTable(6);
        roomReservations.HorizontalAlignment = 0;
        roomReservations.SpacingBefore = 0;
        roomReservations.SpacingAfter = 5;
        roomReservations.DefaultCell.Border = 1;
        roomReservations.SetWidths(new int[] { 2, 1, 2, 1, 1, 2 });
        int mSingles;
        string school = HttpContext.Current.Session["School"].ToString();//.Replace("'","''").Trim();
        int mst = int.Parse(SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT MST FROM WiaaSchoolReservations WHERE SchoolName = @school and Year = " + year + "", new SqlParameter("@school", school)).ToString());
        int msf = int.Parse(SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT MSF FROM WiaaSchoolReservations WHERE SchoolName = @school and Year = " + year + "", new SqlParameter("@school", school)).ToString());
        if (mst < msf)
            mSingles = msf;
        else mSingles = mst;

        int mDoubles;
        int mdt = int.Parse(SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT MDT FROM WiaaSchoolReservations WHERE SchoolName = @school and Year = " + year + "", new SqlParameter("@school", school)).ToString());
        int mdf = int.Parse(SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT MDF FROM WiaaSchoolReservations WHERE SchoolName = @school and Year = " + year + "", new SqlParameter("@school", school)).ToString());
        if (mdt < mdf)
            mDoubles = mdf;
        else mDoubles = mdt;

        int mTriples;
        int mtt = int.Parse(SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT MTT FROM WiaaSchoolReservations WHERE SchoolName = @school and Year = " + year + "", new SqlParameter("@school", school)).ToString());
        int mtf = int.Parse(SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT MTF FROM WiaaSchoolReservations WHERE SchoolName = @school and Year = " + year + "", new SqlParameter("@school", school)).ToString());
        if (mtt < mtf)
            mTriples = mtf;
        else mTriples = mtt;

        int fSingles;
        int fst = int.Parse(SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT FST FROM WiaaSchoolReservations WHERE SchoolName = @school and Year = " + year + "", new SqlParameter("@school", school)).ToString());
        int fsf = int.Parse(SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT FSF FROM WiaaSchoolReservations WHERE SchoolName = @school and Year = " + year + "", new SqlParameter("@school", school)).ToString());
        if (fst < fsf)
            fSingles = fsf;
        else fSingles = fst;

        int fDoubles;
        int fdt = int.Parse(SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT FDT FROM WiaaSchoolReservations WHERE SchoolName = @school and Year = " + year + "", new SqlParameter("@school", school)).ToString());
        int fdf = int.Parse(SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT FDF FROM WiaaSchoolReservations WHERE SchoolName = @school and Year = " + year + "", new SqlParameter("@school", school)).ToString());
        if (fdt < fdf)
            fDoubles = fdf;
        else fDoubles = fdt;

        int fTriples;
        int ftt = int.Parse(SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT FTT FROM WiaaSchoolReservations WHERE SchoolName = @school and Year = " + year + "", new SqlParameter("@school", school)).ToString());
        int ftf = int.Parse(SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT FTF FROM WiaaSchoolReservations WHERE SchoolName = @school and Year = " + year + "", new SqlParameter("@school", school)).ToString());
        if (ftt < ftf)
            fTriples = ftf;
        else fTriples = ftt;

        int mStudies;
        int MStudyT = int.Parse(SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT MStudyT FROM WiaaSchoolReservations WHERE SchoolName = @school and Year = " + year + "", new SqlParameter("@school", school)).ToString());
        int MStudyF = int.Parse(SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT MStudyF FROM WiaaSchoolReservations WHERE SchoolName = @school and Year = " + year + "", new SqlParameter("@school", school)).ToString());
        if (MStudyT < MStudyF)
            mStudies = MStudyF;
        else mStudies = MStudyT;

        int fStudies;
        int FStudyT = int.Parse(SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT FStudyT FROM WiaaSchoolReservations WHERE SchoolName = @school and Year = " + year + "", new SqlParameter("@school", school)).ToString());
        int FStudyF = int.Parse(SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT FStudyF FROM WiaaSchoolReservations WHERE SchoolName = @school and Year = " + year + "", new SqlParameter("@school", school)).ToString());
        if (FStudyT < FStudyF)
            fStudies = FStudyF;
        else fStudies = FStudyT;

        int MEagleSingles;
        int MEagleST = int.Parse(SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT MEagleST FROM WiaaSchoolReservations WHERE SchoolName = @school and Year = " + year + "", new SqlParameter("@school", school)).ToString());
        int MEagleSF = int.Parse(SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT MEagleSF FROM WiaaSchoolReservations WHERE SchoolName = @school and Year = " + year + "", new SqlParameter("@school", school)).ToString());
        if (MEagleST < MEagleSF)
            MEagleSingles = MEagleSF;
        else MEagleSingles = MEagleST;

        int MEagleDoubles;
        int MEagleDT = int.Parse(SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT MEagleDT FROM WiaaSchoolReservations WHERE SchoolName = @school and Year = " + year + "", new SqlParameter("@school", school)).ToString());
        int MEagleDF = int.Parse(SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT MEagleDF FROM WiaaSchoolReservations WHERE SchoolName = @school and Year = " + year + "", new SqlParameter("@school", school)).ToString());
        if (MEagleDT < MEagleDF)
            MEagleDoubles = MEagleDF;
        else MEagleDoubles = MEagleDT;

        int FEagleSingles;
        int FEagleST = int.Parse(SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT FEagleST FROM WiaaSchoolReservations WHERE SchoolName = @school and Year = " + year + "", new SqlParameter("@school", school)).ToString());
        int FEagleSF = int.Parse(SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT FEagleSF FROM WiaaSchoolReservations WHERE SchoolName = @school and Year = " + year + "", new SqlParameter("@school", school)).ToString());
        if (FEagleST < FEagleSF)
            FEagleSingles = FEagleSF;
        else FEagleSingles = FEagleST;

        int FEagleDoubles;
        int FEagleDT = int.Parse(SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT FEagleDT FROM WiaaSchoolReservations WHERE SchoolName = @school and Year = " + year + "", new SqlParameter("@school", school)).ToString());
        int FEagleDF = int.Parse(SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT FEagleDF FROM WiaaSchoolReservations WHERE SchoolName = @school and Year = " + year + "", new SqlParameter("@school", school)).ToString());
        if (FEagleDT < FEagleDF)
            FEagleDoubles = FEagleDF;
        else FEagleDoubles = FEagleDT;

        roomReservations.AddCell(new Phrase("Single Rooms:", boldTableFont));
        roomReservations.AddCell(mst.ToString());
        roomReservations.AddCell(msf.ToString());
        roomReservations.AddCell(fst.ToString());
        roomReservations.AddCell(fsf.ToString());
        roomReservations.AddCell((mSingles + fSingles).ToString());

        roomReservations.AddCell(new Phrase("Double Rooms:", boldTableFont));
        roomReservations.AddCell(mdt.ToString());
        roomReservations.AddCell(mdf.ToString());
        roomReservations.AddCell(fdt.ToString());
        roomReservations.AddCell(fdf.ToString());
        roomReservations.AddCell((mDoubles + fDoubles).ToString());

        roomReservations.AddCell(new Phrase("Triple    Rooms:", boldTableFont));
        roomReservations.AddCell(mtt.ToString());
        roomReservations.AddCell(mtf.ToString());
        roomReservations.AddCell(ftt.ToString());
        roomReservations.AddCell(ftf.ToString());
        roomReservations.AddCell((mTriples + fTriples).ToString());

        roomReservations.AddCell(new Phrase("Studies:", boldTableFont));
        roomReservations.AddCell(MStudyT.ToString());
        roomReservations.AddCell(MStudyF.ToString());
        roomReservations.AddCell(FStudyT.ToString());
        roomReservations.AddCell(FStudyF.ToString());
        roomReservations.AddCell((mStudies + fStudies).ToString());

        roomReservations.AddCell(new Phrase("Eagle Singles:", boldTableFont));
        roomReservations.AddCell(MEagleST.ToString());
        roomReservations.AddCell(MEagleSF.ToString());
        roomReservations.AddCell(FEagleST.ToString());
        roomReservations.AddCell(FEagleSF.ToString());
        roomReservations.AddCell((MEagleSingles + FEagleSingles).ToString());

        roomReservations.AddCell(new Phrase("Eagle Doubles:", boldTableFont));
        roomReservations.AddCell(MEagleDT.ToString());
        roomReservations.AddCell(MEagleDF.ToString());
        roomReservations.AddCell(FEagleDT.ToString());
        roomReservations.AddCell(FEagleDF.ToString());
        roomReservations.AddCell((MEagleDoubles + FEagleDoubles).ToString());

        var signature = new PdfPTable(1);
        signature.HorizontalAlignment = 0;
        signature.SpacingBefore = 20;
        signature.SpacingAfter = 30;
        signature.DefaultCell.Border = 0;
        signature.AddCell(new Phrase("_______________________       _______________________", boldTableFont));
        signature.AddCell(new Phrase("Signature of Check-in Staff                          Date", bodyFont));

        var frontDesk = new Paragraph("To be completed by Front Desk Staff ONLY", titleFont);
        frontDesk.SpacingAfter = 10;
        var roommateListing = new Paragraph("_______ Roommate listing collected from 1 roster per team", bodyFont);
        roommateListing.SpacingAfter = 5;
        var emergency = new Paragraph("_______ Emergency contact forms collected from coach : 1 form for each key", bodyFont);
        emergency.SpacingAfter = 100;

        var signature2 = new PdfPTable(1);
        signature2.HorizontalAlignment = 0;
        signature2.SpacingBefore = 20;
        signature2.SpacingAfter = 45;
        signature2.DefaultCell.Border = 0;
        signature2.AddCell(new Phrase("_______________________       _______________________", boldTableFont));
        signature2.AddCell("Signature of Residence Hall Staff            Date");

        Font arial = new Font(Font.FontFamily.TIMES_ROMAN, 11);
        Paragraph reslife = new Paragraph("Office of Residence Life\nEagle Hall | University of Wisconsin-La Crosse | 1500 La Crosse Street | La Crosse, WI 54601 USA\nPhone: 608.785.8075 | Fax: 608.875.8078\nAn affirmative action/equal opportunity employer", arial);
        reslife.Alignment = Element.ALIGN_CENTER;

        document.Add(schoolName);
        document.Add(hallAssigned);
        document.Add(roomsAssigned);
        document.Add(new Paragraph("Note: Males are the first two columns, females are the second two."));

        document.Add(day);
        document.Add(roomReservations);
        //document.Add(signature);
        document.Add(frontDesk);
        document.Add(roommateListing);
        document.Add(emergency);
        //document.Add(signature2);
        document.Add(reslife);

        var logo = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("~/wiaa/images/bigHeader.gif"));
        logo.SetAbsolutePosition(35, 730);
        logo.ScaleAbsolute(516, 46);
        document.Add(logo);

        document.Close();

        HttpContext.Current.Response.ContentType = "application/pdf";
        HttpContext.Current.Response.AddHeader("Content-Disposition", string.Format("attachment;filename=Housing-{0}.pdf", HttpContext.Current.Session["School"].ToString()));
        HttpContext.Current.Response.BinaryWrite(output.ToArray());
    }

    public void createReceiptPDF()
    {
        WiaaReservation res = (WiaaReservation)HttpContext.Current.Session["WiaaReservation"];

        DateTime time = DateTime.Now;
        // Create a Document object
        var document = new Document(PageSize.A4, 50, 50, 120, 11);

        // Create a new PdfWriter object, specifying the output stream
        var output = new MemoryStream();
        var writer = PdfWriter.GetInstance(document, output);

        // Open the Document for writing
        document.Open();

        var titleFont = FontFactory.GetFont("Arial", 18, Font.BOLD);
        var subTitleFont = FontFactory.GetFont("Arial", 11, Font.BOLD);
        var boldTableFont = FontFactory.GetFont("Arial", 11, Font.BOLD);
        var endingMessageFont = FontFactory.GetFont("Arial", 8, Font.ITALIC);
        var bodyFont = FontFactory.GetFont("Arial", 11, Font.NORMAL);

        document.Add(new Paragraph("WIAA State Track Housing Receipt", titleFont));

        var schoolName = new PdfPTable(4);
        schoolName.HorizontalAlignment = 0;
        schoolName.SpacingBefore = 5;
        schoolName.SpacingAfter = 0;
        schoolName.DefaultCell.Border = 0;
        schoolName.SetWidths(new int[] { 1, 2, 1, 2 });
        schoolName.AddCell(new Phrase("School Name:", boldTableFont));
        schoolName.AddCell(res.school);
        schoolName.AddCell(new Phrase("Today's Date: ", boldTableFont));
        schoolName.AddCell(time.ToString());

        var contactPerson = new PdfPTable(2);
        contactPerson.HorizontalAlignment = 0;
        contactPerson.SpacingBefore = 5;
        contactPerson.SpacingAfter = 0;
        contactPerson.DefaultCell.Border = 0;
        contactPerson.SetWidths(new int[] { 1, 2 });
        contactPerson.AddCell(new Phrase("Contact Person, Title:", boldTableFont));
        contactPerson.AddCell(res.fname + " " + res.lname + ", " + res.title);

        var address = new PdfPTable(2);
        address.HorizontalAlignment = 0;
        address.SpacingBefore = 5;
        address.SpacingAfter = 0;
        address.DefaultCell.Border = 0;
        address.SetWidths(new int[] { 1, 2 });
        address.AddCell(new Phrase("Address:", boldTableFont));
        address.AddCell(res.schoolAddress);

        var cityStateZip = new PdfPTable(2);
        cityStateZip.HorizontalAlignment = 0;
        cityStateZip.SpacingBefore = 0;
        cityStateZip.SpacingAfter = 5;
        cityStateZip.DefaultCell.Border = 0;
        cityStateZip.SetWidths(new int[] { 1, 2 });
        cityStateZip.AddCell(new Phrase("City/State/Zip:", boldTableFont));
        cityStateZip.AddCell(res.city + ", WI " + res.zip);

        var hallAssigned = new PdfPTable(2);
        hallAssigned.HorizontalAlignment = 0;
        hallAssigned.SpacingBefore = 5;
        hallAssigned.SpacingAfter = 10;
        hallAssigned.DefaultCell.Border = 0;
        hallAssigned.SetWidths(new int[] { 1, 2 });
        hallAssigned.AddCell(new Phrase("Hall Assignment:", boldTableFont));
        hallAssigned.AddCell(res.hallAssign);

        var day = new PdfPTable(7);
        day.HorizontalAlignment = 0;
        day.SpacingBefore = 5;
        day.SpacingAfter = 0;
        day.DefaultCell.Border = 0;
        day.SetWidths(new int[] { 2, 1, 2, 1, 1, 2, 1 });
        day.AddCell("");
        day.AddCell("TH");
        day.AddCell("F");
        day.AddCell("TH");
        day.AddCell("F");
        day.AddCell("");
        day.AddCell("Total");

        var roomReservations = new PdfPTable(7);
        roomReservations.HorizontalAlignment = 0;
        roomReservations.SpacingBefore = 0;
        roomReservations.SpacingAfter = 5;
        roomReservations.DefaultCell.Border = 1;
        roomReservations.SetWidths(new int[] { 2, 1, 2, 1, 1, 2, 1 });

        int totalSingles = res.mst + res.msf + res.fst + res.fsf;
        int singleCost = int.Parse(SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT SingleCost FROM RoomCosts WHERE year = " + year + "").ToString());

        int totalDoubles = res.mdt + res.mdf + res.fdt + res.fdf;
        int doubleCost = int.Parse(SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT DoubleCost FROM RoomCosts WHERE year = " + year + "").ToString());

        int totalTriples = res.mtt + res.mtf + res.ftt + res.ftf;
        int tripleCost = int.Parse(SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT TripleCost FROM RoomCosts WHERE year = " + year + "").ToString());

        int totalStudies = res.mStudyT + res.mStudyF + res.fStudyT + res.fStudyF;
        int studyCost = int.Parse(SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT StudyCost FROM RoomCosts WHERE year = " + year + "").ToString());

        int totalEagleSingles = res.mEagleST + res.mEagleSF + res.fEagleST + res.fEagleSF;
        int eagleSingleCost = int.Parse(SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT EagleSingleCost FROM RoomCosts WHERE year = " + year + "").ToString());

        int totalEagleDoubles = res.mEagleDT + res.mEagleDF + res.fEagleDT + res.fEagleDF;
        int eagleDoubleCost = int.Parse(SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT EagleDoubleCost FROM RoomCosts WHERE year = " + year + "").ToString());

        roomReservations.AddCell(new Phrase("Single Rooms:", boldTableFont));
        roomReservations.AddCell(res.mst.ToString());
        roomReservations.AddCell(res.msf.ToString());
        roomReservations.AddCell(res.fst.ToString());
        roomReservations.AddCell(res.fsf.ToString());
        roomReservations.AddCell(totalSingles + " X $" + singleCost);
        roomReservations.AddCell("$" + (singleCost * totalSingles).ToString());

        roomReservations.AddCell(new Phrase("Double Rooms:", boldTableFont));
        roomReservations.AddCell(res.mdt.ToString());
        roomReservations.AddCell(res.mdf.ToString());
        roomReservations.AddCell(res.fdt.ToString());
        roomReservations.AddCell(res.fdf.ToString());
        roomReservations.AddCell(totalDoubles + " X $" + doubleCost);
        roomReservations.AddCell("$" + (doubleCost * totalDoubles).ToString());

        roomReservations.AddCell(new Phrase("Triple Rooms:", boldTableFont));
        roomReservations.AddCell(res.mtt.ToString());
        roomReservations.AddCell(res.mtf.ToString());
        roomReservations.AddCell(res.ftt.ToString());
        roomReservations.AddCell(res.ftf.ToString());
        roomReservations.AddCell(totalTriples + " X $" + tripleCost);
        roomReservations.AddCell("$" + (tripleCost * totalTriples).ToString());

        roomReservations.AddCell(new Phrase("Studies:", boldTableFont));
        roomReservations.AddCell(res.mStudyT.ToString());
        roomReservations.AddCell(res.mStudyF.ToString());
        roomReservations.AddCell(res.fStudyT.ToString());
        roomReservations.AddCell(res.fStudyF.ToString());
        roomReservations.AddCell(totalStudies + " X $" + studyCost);
        roomReservations.AddCell("$" + (totalStudies * studyCost).ToString());

        roomReservations.AddCell(new Phrase("Eagle Singles:", boldTableFont));
        roomReservations.AddCell(res.mEagleST.ToString());
        roomReservations.AddCell(res.mEagleSF.ToString());
        roomReservations.AddCell(res.fEagleST.ToString());
        roomReservations.AddCell(res.fEagleSF.ToString());
        roomReservations.AddCell(totalEagleSingles + " X $" + eagleSingleCost);
        roomReservations.AddCell("$" + (totalEagleSingles * eagleSingleCost).ToString());

        roomReservations.AddCell(new Phrase("Eagle Doubles:", boldTableFont));
        roomReservations.AddCell(res.mEagleDT.ToString());
        roomReservations.AddCell(res.mEagleDF.ToString());
        roomReservations.AddCell(res.fEagleDT.ToString());
        roomReservations.AddCell(res.fEagleDF.ToString());
        roomReservations.AddCell(totalEagleDoubles + " X $" + eagleDoubleCost);
        roomReservations.AddCell("$" + (totalEagleDoubles * eagleDoubleCost).ToString());

        var paid = new PdfPTable(7);
        paid.HorizontalAlignment = 0;
        paid.SpacingBefore = 10;
        paid.SpacingAfter = 0;
        paid.DefaultCell.Border = 0;
        paid.SetWidths(new int[] { 1, 1, 1, 1, 1, 1, 0 });
        paid.AddCell("Paid By:");
        paid.AddCell(res.paidBy);
        paid.AddCell("Amount: ");
        string amount = "$" + res.amount.ToString();
        paid.AddCell(amount);
        paid.AddCell("Check Number:");
        paid.AddCell(res.checkNumber);
        paid.AddCell("");

        var secondpaid = new PdfPTable(7);
        secondpaid.HorizontalAlignment = 0;
        secondpaid.SpacingBefore = 0;
        secondpaid.SpacingAfter = 5;
        secondpaid.DefaultCell.Border = 0;
        secondpaid.SetWidths(new int[] { 1, 1, 1, 1, 1, 1, 0 });
        secondpaid.AddCell("Paid By(2):");
        secondpaid.AddCell(res.paidBy2);
        secondpaid.AddCell("Amount(2): ");
        string amount2 = "$" + res.amount2.ToString();
        secondpaid.AddCell(amount2);
        secondpaid.AddCell("Check Number(2):");
        secondpaid.AddCell(res.checkNumber2);
        secondpaid.AddCell("");

        var thirdpaid = new PdfPTable(7);
        thirdpaid.HorizontalAlignment = 0;
        thirdpaid.SpacingBefore = 0;
        thirdpaid.SpacingAfter = 5;
        thirdpaid.DefaultCell.Border = 0;
        thirdpaid.SetWidths(new int[] { 1, 1, 1, 1, 1, 1, 0 });
        thirdpaid.AddCell("Paid By(3):");
        thirdpaid.AddCell(res.paidBy3);
        thirdpaid.AddCell("Amount(3): ");
        string amount3 = "$" + res.amount3.ToString();
        thirdpaid.AddCell(amount3);
        thirdpaid.AddCell("Check Number(3):");
        thirdpaid.AddCell(res.checkNumber3);
        thirdpaid.AddCell("");

        var finalTotal = new PdfPTable(2);
        finalTotal.HorizontalAlignment = 0;
        finalTotal.SpacingBefore = 5;
        finalTotal.SpacingAfter = 5;
        finalTotal.DefaultCell.Border = 3;
        finalTotal.SetWidths(new int[] { 1, 2 });
        finalTotal.AddCell("Refund:");
        finalTotal.AddCell("$" + res.refund.ToString());
        finalTotal.AddCell(new Phrase("Total:", boldTableFont));
        finalTotal.AddCell(new Phrase("$" + res.billTotal.ToString()));

        var refundExp = new PdfPTable(2);
        refundExp.HorizontalAlignment = 0;
        refundExp.SpacingBefore = 5;
        refundExp.SpacingAfter = 0;
        refundExp.DefaultCell.Border = 0;
        refundExp.SetWidths(new int[] { 1, 2 });
        refundExp.AddCell("Refund Explanation: ");
        refundExp.AddCell(res.refundExp);

        var note = new PdfPTable(1);
        note.HorizontalAlignment = 0;
        note.SpacingBefore = 0;
        note.SpacingAfter = 5;
        note.DefaultCell.Border = 0;
        note.SetWidths(new int[] { 1 });
        note.AddCell("*Note* A refund check will be processed and sent to your school. Please allow up to 14 business days.");

        var signature = new PdfPTable(2);
        signature.HorizontalAlignment = 0;
        signature.SpacingBefore = 10;
        signature.SpacingAfter = 8;
        signature.DefaultCell.Border = 0;

        var sig = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("~/wiaa/images/troySignature.gif"));
        signature.AddCell(sig);
        signature.AddCell("\n\n\n\nDate: " + DateTime.Now.ToString());

        //signature.AddCell(new Phrase("_______________________            "  + DateTime.Now.ToString(), boldTableFont)); //Code for a blank signature line
        //signature.AddCell("Signature of Residence Life Staff                      Date");

        Font arial = new Font(Font.FontFamily.TIMES_ROMAN, 8);
        Paragraph reslife = new Paragraph("Office of Residence Life\nEagle Hall | University of Wisconsin-La Crosse | 1500 La Crosse Street | La Crosse, WI 54601 USA\nPhone: 608.785.8075 | Fax: 608.875.8078\nAn affirmative action/equal opportunity employer", arial);
        reslife.Alignment = Element.ALIGN_CENTER;

        document.Add(schoolName);
        document.Add(contactPerson);
        document.Add(address);
        document.Add(cityStateZip);
        document.Add(hallAssigned);
        document.Add(day);
        document.Add(roomReservations);
        document.Add(paid);
        if (res.paidBy2 != "")
        {
            document.Add(secondpaid);
        }
        if (res.paidBy3 != "")
        {
            document.Add(thirdpaid);
        }
        document.Add(finalTotal);

        if (res.refund != 0)
        {
            document.Add(refundExp);
            document.Add(note);
        }
        document.Add(signature);
        document.Add(reslife);

        var logo = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("~/wiaa/images/bigHeader.gif"));
        logo.SetAbsolutePosition(35, 730);
        logo.ScaleAbsolute(516, 46);
        document.Add(logo);

        if (Settings.AutomaticallyPrintReceipts())
        {
            PdfAction action = new PdfAction(PdfAction.PRINTDIALOG);
            writer.AddViewerPreference(PdfName.NUMCOPIES, new PdfNumber(2));
            writer.SetOpenAction(action);
        }

        document.Close();

        HttpContext.Current.Response.ContentType = "application/pdf";
        HttpContext.Current.Response.AddHeader("Content-Disposition", string.Format("attachment;filename=Receipt-{0}.pdf", res.school));
        HttpContext.Current.Response.BinaryWrite(output.ToArray());
    }

    public void volunteerHousingPDF()
    {
        DateTime time = DateTime.Now;
        // Create a Document object
        var document = new Document(PageSize.A4, 50, 50, 120, 25);

        // Create a new PdfWriter object, specifying the output stream
        var output = new MemoryStream();
        var writer = PdfWriter.GetInstance(document, output);

        // Open the Document for writing
        document.Open();

        var titleFont = FontFactory.GetFont("Arial", 20, Font.BOLD);
        var subTitleFont = FontFactory.GetFont("Arial", 16, Font.BOLD);
        var boldTableFont = FontFactory.GetFont("Arial", 14, Font.BOLD);
        var endingMessageFont = FontFactory.GetFont("Arial", 8, Font.ITALIC);
        var bodyFont = FontFactory.GetFont("Arial", 14, Font.NORMAL);

        document.Add(new Paragraph("WIAA State Track Volunteer Housing Assignment", titleFont));

        var volunteerName = new PdfPTable(4);
        volunteerName.HorizontalAlignment = 0;
        volunteerName.SpacingBefore = 10;
        volunteerName.SpacingAfter = 10;
        volunteerName.DefaultCell.Border = 0;
        volunteerName.SetWidths(new int[] { 2, 2, 1, 2 });
        volunteerName.AddCell(new Phrase("Volunteer:", boldTableFont));
        volunteerName.AddCell(HttpContext.Current.Session["Volunteer"].ToString());
        volunteerName.AddCell(new Phrase("Today's Date: ", boldTableFont));
        volunteerName.AddCell(time.ToString());

        var hallAssigned = new PdfPTable(2);
        hallAssigned.HorizontalAlignment = 0;
        hallAssigned.SpacingBefore = 5;
        hallAssigned.SpacingAfter = 5;
        hallAssigned.DefaultCell.Border = 0;
        hallAssigned.SetWidths(new int[] { 1, 2 });
        hallAssigned.AddCell(new Phrase("Hall Assignment:", boldTableFont));
        hallAssigned.AddCell("Reuter");

        var roomsAssigned = new PdfPTable(2);
        String name = HttpContext.Current.Session["Volunteer"].ToString();
        String room = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT Room From VolunteerRoomReservations WHERE [Bed A] = '" + name + "' OR [Bed B] = '" + name + "' OR [Bed C] = '" + name + "' OR [Bed D] = '" + name + "'").ToString();
        roomsAssigned.HorizontalAlignment = 0;
        roomsAssigned.SpacingBefore = 5;
        roomsAssigned.SpacingAfter = 10;
        roomsAssigned.DefaultCell.Border = 0;
        roomsAssigned.SetWidths(new int[] { 1, 2 });
        roomsAssigned.AddCell(new Phrase("Room Assigned:", boldTableFont));
        roomsAssigned.AddCell(room);
        //roomsAssigned.AddCell(HttpContext.Current.Session["VolunteerRoom"].ToString());

        var days = new PdfPTable(2);
        days.HorizontalAlignment = 0;
        days.SpacingBefore = 5;
        days.SpacingAfter = 10;
        days.DefaultCell.Border = 0;
        days.SetWidths(new int[] { 1, 2 });
        String[] fullname = HttpContext.Current.Session["Volunteer"].ToString().Split(' ');
        String fname = fullname[0];
        String lname = fullname[1];
        String thursday = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT RST From WiaaVolunteerInfo WHERE LName = '" + lname + "' AND FName = '" + fname + "'").ToString();
        String friday = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT RSF From WiaaVolunteerInfo WHERE LName = '" + lname + "' AND FName = '" + fname + "'").ToString();
        days.AddCell(new Phrase("Thursday: ", boldTableFont));
        days.AddCell(thursday);
        days.AddCell(new Phrase("Friday: ", boldTableFont));
        days.AddCell(friday);

        var signature = new PdfPTable(1);
        signature.HorizontalAlignment = 0;
        signature.SpacingBefore = 20;
        signature.SpacingAfter = 30;
        signature.DefaultCell.Border = 0;
        signature.AddCell(new Phrase("_______________________       _______________________", boldTableFont));
        signature.AddCell(new Phrase("Signature of Check-in Staff                          Date", bodyFont));

        var frontDesk = new Paragraph("To be completed by Front Desk Staff ONLY", titleFont);
        frontDesk.SpacingAfter = 10;
        var emergency = new Paragraph("_______ Emergency contact form collected: 1 form for each key", bodyFont);

        var signature2 = new PdfPTable(1);
        signature2.HorizontalAlignment = 0;
        signature2.SpacingBefore = 20;
        signature2.SpacingAfter = 65;
        signature2.DefaultCell.Border = 0;
        signature2.AddCell(new Phrase("_______________________       _______________________", boldTableFont));
        signature2.AddCell("Signature of Residence Hall Staff            Date");

        Font arial = new Font(Font.FontFamily.TIMES_ROMAN, 11);
        Paragraph reslife = new Paragraph("Office of Residence Life\nEagle Hall | University of Wisconsin-La Crosse | 1500 La Crosse Street | La Crosse, WI 54601 USA\nPhone: 608.785.8075 | Fax: 608.875.8078\nAn affirmatvie action/equal opportunity employer", arial);
        reslife.Alignment = Element.ALIGN_CENTER;

        document.Add(volunteerName);
        document.Add(hallAssigned);
        document.Add(roomsAssigned);
        document.Add(days);
        document.Add(signature);
        document.Add(frontDesk);
        document.Add(emergency);
        document.Add(signature2);
        document.Add(reslife);

        var logo = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("~/wiaa/images/bigHeader.gif"));
        logo.SetAbsolutePosition(35, 730);
        logo.ScaleAbsolute(516, 46);
        document.Add(logo);

        document.Close();

        HttpContext.Current.Response.ContentType = "application/pdf";
        HttpContext.Current.Response.AddHeader("Content-Disposition", string.Format("attachment;filename=Volunteer Housing-{0}.pdf", HttpContext.Current.Session["Volunteer"].ToString()));
        HttpContext.Current.Response.BinaryWrite(output.ToArray());
    }

    //receipt for volunteers
    public void createVolReceiptPDF()
    {
        DateTime time = DateTime.Now;
        String name = HttpContext.Current.Session["Volunteer"].ToString();
        String[] temp = name.Split(' ');
        String fname = temp[0];
        String lname = temp[1];
        // Create a Document object
        var document = new Document(PageSize.A4, 50, 50, 120, 25);

        // Create a new PdfWriter object, specifying the output stream
        var output = new MemoryStream();
        var writer = PdfWriter.GetInstance(document, output);

        // Open the Document for writing
        document.Open();

        var titleFont = FontFactory.GetFont("Arial", 20, Font.BOLD);
        var subTitleFont = FontFactory.GetFont("Arial", 16, Font.BOLD);
        var boldTableFont = FontFactory.GetFont("Arial", 14, Font.BOLD);
        var endingMessageFont = FontFactory.GetFont("Arial", 12, Font.ITALIC);
        var bodyFont = FontFactory.GetFont("Arial", 14, Font.NORMAL);

        document.Add(new Paragraph("WIAA State Track Volunteer Housing Receipt", titleFont));

        var volunteerName = new PdfPTable(4);
        volunteerName.HorizontalAlignment = 0;
        volunteerName.SpacingBefore = 10;
        volunteerName.SpacingAfter = 10;
        volunteerName.DefaultCell.Border = 0;
        volunteerName.SetWidths(new int[] { 2, 2, 1, 2 });
        volunteerName.AddCell(new Phrase("Volunteer:", boldTableFont));
        volunteerName.AddCell(HttpContext.Current.Session["Volunteer"].ToString());
        volunteerName.AddCell(new Phrase("Today's Date: ", boldTableFont));
        volunteerName.AddCell(time.ToString());

        var address = new PdfPTable(2);
        address.HorizontalAlignment = 0;
        address.SpacingBefore = 5;
        address.SpacingAfter = 0;
        address.DefaultCell.Border = 0;
        address.SetWidths(new int[] { 1, 2 });
        address.AddCell(new Phrase("Address:", boldTableFont));
        String strAddress = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT Address FROM WiaaVolunteerInfo WHERE ContactEmail = '" + HttpContext.Current.Session["EmailID"].ToString() + "' and year = " + year + "").ToString();
        address.AddCell(strAddress);

        var cityStateZip = new PdfPTable(2);
        cityStateZip.HorizontalAlignment = 0;
        cityStateZip.SpacingBefore = 0;
        cityStateZip.SpacingAfter = 5;
        cityStateZip.DefaultCell.Border = 0;
        cityStateZip.SetWidths(new int[] { 1, 2 });
        cityStateZip.AddCell(new Phrase("City/State/Zip:", boldTableFont));
        String state = "WI";
        String strCityStateZip = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT City + ',' + ' ' + '" + state + "' + ' ' + Zip FROM WiaaVolunteerInfo WHERE ContactEmail = '" + HttpContext.Current.Session["EmailID"].ToString() + "' and year = " + year + "").ToString();
        cityStateZip.AddCell(strCityStateZip);

        var hallAssigned = new PdfPTable(2);
        hallAssigned.HorizontalAlignment = 0;
        hallAssigned.SpacingBefore = 5;
        hallAssigned.SpacingAfter = 10;
        hallAssigned.DefaultCell.Border = 0;
        hallAssigned.SetWidths(new int[] { 1, 2 });
        hallAssigned.AddCell(new Phrase("Hall Assignment:", boldTableFont));
        hallAssigned.AddCell("Reuter");

        var day = new PdfPTable(3);
        day.HorizontalAlignment = 0;
        day.SpacingBefore = 5;
        day.SpacingAfter = 0;
        day.DefaultCell.Border = 0;
        day.SetWidths(new int[] { 1, 1, 1 });
        day.AddCell("");
        day.AddCell("");
        day.AddCell("Total");

        var roomReservations = new PdfPTable(3);
        roomReservations.HorizontalAlignment = 0;
        roomReservations.SpacingBefore = 0;
        roomReservations.SpacingAfter = 5;
        roomReservations.DefaultCell.Border = 1;
        roomReservations.SetWidths(new int[] { 1, 1, 1 });
        int thursday = (int)SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT RST From WiaaVolunteerInfo WHERE ContactEmail = '" + HttpContext.Current.Session["EmailID"].ToString() + "' and year = " + year + "");
        int friday = (int)SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT RSF From WiaaVolunteerInfo WHERE ContactEmail = '" + HttpContext.Current.Session["EmailID"].ToString() + "' and year = " + year + "");
        int reuterCost = (int)SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT ReuterCost From RoomCosts WHERE Year = " + year + "");
        int totalThursday = thursday * reuterCost;
        int totalFriday = friday * reuterCost;

        roomReservations.AddCell(new Phrase("Thursday:", boldTableFont));
        roomReservations.AddCell(thursday + " X $" + reuterCost);
        roomReservations.AddCell("$" + totalThursday);

        roomReservations.AddCell(new Phrase("Friday", boldTableFont));
        roomReservations.AddCell(friday + " X $" + reuterCost);
        roomReservations.AddCell("$" + totalFriday);

        String paidby = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT PaidBy FROM WiaaVolunteerInfo WHERE ContactEmail = '" + HttpContext.Current.Session["EmailID"].ToString() + "' and year = " + year + "").ToString();
        String check = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT CheckNumber FROM WiaaVolunteerInfo WHERE ContactEmail = '" + HttpContext.Current.Session["EmailID"].ToString() + "' and year = " + year + "").ToString();
        String refund = "$" + SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT Refund FROM WiaaVolunteerInfo WHERE ContactEmail = '" + HttpContext.Current.Session["EmailID"].ToString() + "' and year = " + year + "").ToString();

        var total_refund = new PdfPTable(7);
        total_refund.HorizontalAlignment = 0;
        total_refund.SpacingBefore = 10;
        total_refund.SpacingAfter = 0;
        total_refund.DefaultCell.Border = 0;
        total_refund.SetWidths(new int[] { 3, 3, 0, 0, 1, 2, 2 });
        total_refund.AddCell("Paid By:");
        total_refund.AddCell(paidby);
        total_refund.AddCell("");
        total_refund.AddCell("");
        total_refund.AddCell("");
        total_refund.AddCell("Refund:");
        refund = refund.Substring(0, refund.Length - 2);
        total_refund.AddCell(refund);
        total_refund.AddCell("Check Number:");
        total_refund.AddCell(check);
        total_refund.AddCell("");
        total_refund.AddCell("");
        total_refund.AddCell("");
        total_refund.AddCell(new Phrase("Total:", boldTableFont));
        String finalTotal = "$" + SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT FinalTotal FROM WiaaVolunteerInfo WHERE ContactEmail = '" + HttpContext.Current.Session["EmailID"].ToString() + "' and year = " + year + "").ToString();
        finalTotal = finalTotal.Substring(0, finalTotal.Length - 2);
        total_refund.AddCell(finalTotal);

        String paidby2 = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT SecondPaidBy FROM WiaaVolunteerInfo WHERE ContactEmail ='" + HttpContext.Current.Session["EmailID"].ToString() + "' and Year = " + year + "").ToString();
        String check2 = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT SecondCheckNumber FROM WiaaVolunteerInfo WHERE ContactEmail ='" + HttpContext.Current.Session["EmailID"].ToString() + "' and Year = " + year + "").ToString();
        var secondpaid = new PdfPTable(2);
        secondpaid.HorizontalAlignment = 0;
        secondpaid.SpacingBefore = 0;
        secondpaid.SpacingAfter = 0;
        secondpaid.DefaultCell.Border = 0;
        secondpaid.SetWidths(new int[] { 1, 2 });
        secondpaid.AddCell("Paid By (2):");
        secondpaid.AddCell(paidby2);
        secondpaid.AddCell("Check Number (2):");
        secondpaid.AddCell(check2);

        var refundExp = new PdfPTable(2);
        refundExp.HorizontalAlignment = 0;
        refundExp.SpacingBefore = 5;
        refundExp.SpacingAfter = 5;
        refundExp.DefaultCell.Border = 0;
        refundExp.SetWidths(new int[] { 1, 2 });
        refundExp.AddCell("Refund Explanation: ");
        String explanation = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT RefundExplanation from WiaaVolunteerInfo WHERE ContactEmail = '" + HttpContext.Current.Session["EmailID"].ToString() + "' and year = " + year + "").ToString();
        refundExp.AddCell(explanation);

        var signature = new PdfPTable(1);
        signature.HorizontalAlignment = 0;
        signature.SpacingBefore = 20;
        signature.SpacingAfter = 55;
        signature.DefaultCell.Border = 0;
        signature.AddCell(new Phrase("_______________________       _______________________", boldTableFont));
        signature.AddCell("Signature of Residence Life Staff                      Date");

        Font arial = new Font(Font.FontFamily.TIMES_ROMAN, 11);
        Paragraph reslife = new Paragraph("Office of Residence Life\nEagle Hall | University of Wisconsin-La Crosse | 1500 La Crosse Street | La Crosse, WI 54601 USA\nPhone: 608.785.8075 | Fax: 608.875.8078\nAn affirmatvie action/equal opportunity employer", arial);
        reslife.Alignment = Element.ALIGN_CENTER;

        document.Add(volunteerName);
        document.Add(address);
        document.Add(cityStateZip);
        document.Add(hallAssigned);
        document.Add(day);
        document.Add(roomReservations);
        document.Add(total_refund);
        if (paidby2 != "")
        {
            document.Add(secondpaid);
        }
        document.Add(refundExp);
        document.Add(signature);
        document.Add(reslife);

        var logo = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("~/wiaa/images/bigHeader.gif"));
        logo.SetAbsolutePosition(35, 730);
        logo.ScaleAbsolute(516, 46);
        document.Add(logo);

        if (Settings.AutomaticallyPrintReceipts())
        {
            PdfAction action = new PdfAction(PdfAction.PRINTDIALOG);
            writer.AddViewerPreference(PdfName.NUMCOPIES, new PdfNumber(2));
            writer.SetOpenAction(action);
        }

        document.Close();

        HttpContext.Current.Response.ContentType = "application/pdf";
        HttpContext.Current.Response.AddHeader("Content-Disposition", string.Format("attachment;filename=Volunteer Receipt-{0}.pdf", HttpContext.Current.Session["Volunteer"].ToString()));
        HttpContext.Current.Response.BinaryWrite(output.ToArray());
    }

    public void schoolChargePDF()
    {
        DateTime time = DateTime.Now;
        // Create a Document object
        var document = new Document(PageSize.A4, 50, 50, 120, 25);

        // Create a new PdfWriter object, specifying the output stream
        var output = new MemoryStream();
        var writer = PdfWriter.GetInstance(document, output);

        // Open the Document for writing
        document.Open();

        var titleFont = FontFactory.GetFont("Arial", 20, Font.BOLD);
        var subTitleFont = FontFactory.GetFont("Arial", 16, Font.BOLD);
        var boldTableFont = FontFactory.GetFont("Arial", 14, Font.BOLD);
        var endingMessageFont = FontFactory.GetFont("Arial", 12, Font.ITALIC);
        var bodyFont = FontFactory.GetFont("Arial", 14, Font.NORMAL);

        document.Add(new Paragraph("WIAA State Track Housing Charges", titleFont));

        var schoolName = new PdfPTable(4);
        schoolName.HorizontalAlignment = 0;
        schoolName.SpacingBefore = 10;
        schoolName.SpacingAfter = 10;
        schoolName.DefaultCell.Border = 0;
        schoolName.SetWidths(new int[] { 1, 2, 1, 2 });
        schoolName.AddCell(new Phrase("School Name:", boldTableFont));
        schoolName.AddCell(HttpContext.Current.Session["School"].ToString());
        schoolName.AddCell(new Phrase("Today's Date: ", boldTableFont));
        schoolName.AddCell(time.ToString());

        var contactPerson = new PdfPTable(2);
        contactPerson.HorizontalAlignment = 0;
        contactPerson.SpacingBefore = 5;
        contactPerson.SpacingAfter = 5;
        contactPerson.DefaultCell.Border = 0;
        contactPerson.SetWidths(new int[] { 1, 2 });
        contactPerson.AddCell(new Phrase("Contact Person, Title:", boldTableFont));
        String contact = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT ContactFNAME + ' ' + ContactLName + ',' + ' ' + ContactTitle AS ContactName FROM WiaaSchoolReservations WHERE SchoolName = '" + HttpContext.Current.Session["School"].ToString().Replace("'","''") + "' and year = " + year + "").ToString();
        contactPerson.AddCell(contact);

        var hallAssigned = new PdfPTable(2);
        hallAssigned.HorizontalAlignment = 0;
        hallAssigned.SpacingBefore = 5;
        hallAssigned.SpacingAfter = 10;
        hallAssigned.DefaultCell.Border = 0;
        hallAssigned.SetWidths(new int[] { 1, 2 });
        hallAssigned.AddCell(new Phrase("Hall Assignment:", boldTableFont));
        String hall = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT HallAssignment FROM WiaaSchoolReservations WHERE SchoolName = '" + HttpContext.Current.Session["School"].ToString().Replace("'","''") + "' and year = " + year + "").ToString();
        hallAssigned.AddCell(hall);

        var miscCharge = new PdfPTable(2);
        miscCharge.HorizontalAlignment = 0;
        miscCharge.SpacingBefore = 5;
        miscCharge.SpacingAfter = 5;
        miscCharge.DefaultCell.Border = 0;
        miscCharge.SetWidths(new int[] { 1, 2 });
        miscCharge.AddCell(new Phrase("Charge Amount:", boldTableFont));
        String amount = "$" + HttpContext.Current.Session["ChargeAmount"].ToString();
        //amount = amount.Substring(0, amount.Length - 2);
        miscCharge.AddCell(amount);

        var miscReason = new PdfPTable(2);
        miscReason.HorizontalAlignment = 0;
        miscReason.SpacingBefore = 5;
        miscReason.SpacingAfter = 5;
        miscReason.DefaultCell.Border = 0;
        miscReason.SetWidths(new int[] { 1, 2 });
        miscReason.AddCell(new Phrase("Charge Reason:", boldTableFont));
        String reason = HttpContext.Current.Session["ChargeReason"].ToString();
        miscReason.AddCell(reason);

        var method = new PdfPTable(2);
        method.HorizontalAlignment = 0;
        method.SpacingBefore = 5;
        method.SpacingAfter = 5;
        method.DefaultCell.Border = 0;
        method.SetWidths(new int[] { 1, 2 });
        method.AddCell(new Phrase("Method of Payment:", boldTableFont));
        String payType = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT MiscPayment FROM WiaaSchoolReservations WHERE SchoolName = '" + HttpContext.Current.Session["School"].ToString().Replace("'","''") + "' and year = " + year + "").ToString();
        method.AddCell(payType);
        //method.AddCell("___________________________");

        var coachSig = new PdfPTable(2);
        coachSig.HorizontalAlignment = 0;
        coachSig.SpacingBefore = 5;
        coachSig.SpacingAfter = 5;
        coachSig.DefaultCell.Border = 0;
        coachSig.SetWidths(new int[] { 1, 2 });
        coachSig.AddCell(new Phrase("Coach Signature:", boldTableFont));
        coachSig.AddCell("___________________________");

        var staffSig = new PdfPTable(2);
        staffSig.HorizontalAlignment = 0;
        staffSig.SpacingBefore = 5;
        staffSig.SpacingAfter = 250;
        staffSig.DefaultCell.Border = 0;
        staffSig.SetWidths(new int[] { 1, 2 });
        staffSig.AddCell(new Phrase("Staff Signature:", boldTableFont));
        staffSig.AddCell("___________________________");

        Font arial = new Font(Font.FontFamily.TIMES_ROMAN, 11);
        Paragraph reslife = new Paragraph("Office of Residence Life\nEagle Hall | University of Wisconsin-La Crosse | 1500 La Crosse Street | La Crosse, WI 54601 USA\nPhone: 608.785.8075 | Fax: 608.875.8078\nAn affirmative action/equal opportunity employer", arial);
        reslife.Alignment = Element.ALIGN_CENTER;

        document.Add(schoolName);
        document.Add(contactPerson);
        document.Add(hallAssigned);
        document.Add(miscCharge);
        document.Add(miscReason);
        document.Add(method);
        document.Add(coachSig);
        document.Add(staffSig);
        document.Add(reslife);

        var logo = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("~/wiaa/images/bigHeader.gif"));
        logo.SetAbsolutePosition(35, 730);
        logo.ScaleAbsolute(516, 46);
        document.Add(logo);

        document.Close();

        HttpContext.Current.Response.ContentType = "application/pdf";
        HttpContext.Current.Response.AddHeader("Content-Disposition", string.Format("attachment;filename=School Charges-{0}.pdf", HttpContext.Current.Session["School"].ToString()));
        HttpContext.Current.Response.BinaryWrite(output.ToArray());
    }

    public void volunteerChargePDF()
    {
        DateTime time = DateTime.Now;

        String name = HttpContext.Current.Session["Volunteer"].ToString();
        String[] temp = name.Split(' ');
        String fname = temp[0];
        String lname = temp[1];

        // Create a Document object
        var document = new Document(PageSize.A4, 50, 50, 120, 25);

        // Create a new PdfWriter object, specifying the output stream
        var output = new MemoryStream();
        var writer = PdfWriter.GetInstance(document, output);

        // Open the Document for writing
        document.Open();

        var titleFont = FontFactory.GetFont("Arial", 20, Font.BOLD);
        var subTitleFont = FontFactory.GetFont("Arial", 16, Font.BOLD);
        var boldTableFont = FontFactory.GetFont("Arial", 14, Font.BOLD);
        var endingMessageFont = FontFactory.GetFont("Arial", 12, Font.ITALIC);
        var bodyFont = FontFactory.GetFont("Arial", 14, Font.NORMAL);

        document.Add(new Paragraph("WIAA State Track Housing Charges", titleFont));

        var volunteer = new PdfPTable(4);
        volunteer.HorizontalAlignment = 0;
        volunteer.SpacingBefore = 10;
        volunteer.SpacingAfter = 10;
        volunteer.DefaultCell.Border = 0;
        volunteer.SetWidths(new int[] { 2, 2, 1, 2 });
        volunteer.AddCell(new Phrase("Volunteer:", boldTableFont));
        volunteer.AddCell(HttpContext.Current.Session["Volunteer"].ToString());
        volunteer.AddCell(new Phrase("Today's Date: ", boldTableFont));
        volunteer.AddCell(time.ToString());

        var hallAssigned = new PdfPTable(2);
        hallAssigned.HorizontalAlignment = 0;
        hallAssigned.SpacingBefore = 5;
        hallAssigned.SpacingAfter = 10;
        hallAssigned.DefaultCell.Border = 0;
        hallAssigned.SetWidths(new int[] { 1, 2 });
        hallAssigned.AddCell(new Phrase("Room Assignment:", boldTableFont));
        String hall = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT Room FROM WiaaVolunteerInfo WHERE FName = '" + fname + "' AND LName = '" + lname + "' and year = " + year + "").ToString();
        hallAssigned.AddCell("Reuter Hall, room " + hall);

        var miscCharge = new PdfPTable(2);
        miscCharge.HorizontalAlignment = 0;
        miscCharge.SpacingBefore = 5;
        miscCharge.SpacingAfter = 5;
        miscCharge.DefaultCell.Border = 0;
        miscCharge.SetWidths(new int[] { 1, 2 });
        miscCharge.AddCell(new Phrase("Charge Amount:", boldTableFont));
        String amount = "$" + HttpContext.Current.Session["ChargeAmount"].ToString();
        //amount = amount.Substring(0, amount.Length - 2);
        miscCharge.AddCell(amount);

        var miscReason = new PdfPTable(2);
        miscReason.HorizontalAlignment = 0;
        miscReason.SpacingBefore = 5;
        miscReason.SpacingAfter = 5;
        miscReason.DefaultCell.Border = 0;
        miscReason.SetWidths(new int[] { 1, 2 });
        miscReason.AddCell(new Phrase("Charge Reason:", boldTableFont));
        String reason = HttpContext.Current.Session["ChargeReason"].ToString();
        miscReason.AddCell(reason);

        var method = new PdfPTable(2);
        method.HorizontalAlignment = 0;
        method.SpacingBefore = 5;
        method.SpacingAfter = 5;
        method.DefaultCell.Border = 0;
        method.SetWidths(new int[] { 1, 2 });
        method.AddCell(new Phrase("Method of Payment:", boldTableFont));
        String payType = SqlHelper.ExecuteScalar(Settings.WIAAConnection, CommandType.Text, "SELECT MiscPayment FROM [WiaaVolunteerInfo] WHERE FName = '" + fname + "' AND LName = '" + lname + "' and year = " + year + "").ToString();
        method.AddCell(payType);

        var coachSig = new PdfPTable(2);
        coachSig.HorizontalAlignment = 0;
        coachSig.SpacingBefore = 5;
        coachSig.SpacingAfter = 5;
        coachSig.DefaultCell.Border = 0;
        coachSig.SetWidths(new int[] { 1, 2 });
        coachSig.AddCell(new Phrase("Volunteer Signature:", boldTableFont));
        coachSig.AddCell("___________________________");

        var staffSig = new PdfPTable(2);
        staffSig.HorizontalAlignment = 0;
        staffSig.SpacingBefore = 5;
        staffSig.SpacingAfter = 250;
        staffSig.DefaultCell.Border = 0;
        staffSig.SetWidths(new int[] { 1, 2 });
        staffSig.AddCell(new Phrase("Staff Signature:", boldTableFont));
        staffSig.AddCell("___________________________");

        Font arial = new Font(Font.FontFamily.TIMES_ROMAN, 11);
        Paragraph reslife = new Paragraph("Office of Residence Life\nEagle Hall | University of Wisconsin-La Crosse | 1500 La Crosse Street | La Crosse, WI 54601 USA\nPhone: 608.785.8075 | Fax: 608.875.8078\nAn affirmative action/equal opportunity employer", arial);
        reslife.Alignment = Element.ALIGN_CENTER;

        document.Add(volunteer);
        document.Add(hallAssigned);
        document.Add(miscCharge);
        document.Add(miscReason);
        document.Add(method);
        document.Add(coachSig);
        document.Add(staffSig);
        document.Add(reslife);

        var logo = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("~/wiaa/images/bigHeader.gif"));
        logo.SetAbsolutePosition(35, 730);
        logo.ScaleAbsolute(516, 46);
        document.Add(logo);

        document.Close();

        HttpContext.Current.Response.ContentType = "application/pdf";
        HttpContext.Current.Response.AddHeader("Content-Disposition", string.Format("attachment;filename=Volunteer Charges-{0}.pdf", HttpContext.Current.Session["Volunteer"].ToString()));
        HttpContext.Current.Response.BinaryWrite(output.ToArray());
    }
}