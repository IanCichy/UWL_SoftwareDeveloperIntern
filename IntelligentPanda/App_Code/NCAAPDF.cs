using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;

/// <summary>
/// Summary description for NCAAPDF
/// </summary>
public class NCAAPDF : PDF
{
    private double singleCost = 35.00;
    private double doubleCost = 50.00;
    private double suiteCost = 140.00;

    public void createChargePDF()
    {
        NcaaReservation res = (NcaaReservation)HttpContext.Current.Session["NcaaReservation"];

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

        document.Add(new Paragraph("NCAA National Track Housing Charges", titleFont));

        var name = new PdfPTable(4);
        name.HorizontalAlignment = 0;
        name.SpacingBefore = 10;
        name.SpacingAfter = 10;
        name.DefaultCell.Border = 0;
        name.SetWidths(new int[] { 1, 2, 1, 2 });
        name.AddCell(new Phrase("Name:", boldTableFont));
        name.AddCell(res.fname + " " + res.lname);
        name.AddCell(new Phrase("Today's Date: ", boldTableFont));
        name.AddCell(time.ToString());

        var affiliatedSchool = new PdfPTable(2);
        affiliatedSchool.HorizontalAlignment = 0;
        affiliatedSchool.SpacingBefore = 5;
        affiliatedSchool.SpacingAfter = 5;
        affiliatedSchool.DefaultCell.Border = 0;
        affiliatedSchool.SetWidths(new int[] { 1, 2 });
        affiliatedSchool.AddCell(new Phrase("Affiliated School:", boldTableFont));
        affiliatedSchool.AddCell(res.school);

        var hallAssigned = new PdfPTable(2);
        hallAssigned.HorizontalAlignment = 0;
        hallAssigned.SpacingBefore = 5;
        hallAssigned.SpacingAfter = 10;
        hallAssigned.DefaultCell.Border = 0;
        hallAssigned.SetWidths(new int[] { 1, 2 });
        hallAssigned.AddCell(new Phrase("Hall Assignment:", boldTableFont));
        if (res.reservedRooms.Count > 0)
        {
            hallAssigned.AddCell(res.reservedRooms[0].hall);
        }
        else
        {
            hallAssigned.AddCell("");
        }

        var miscCharge = new PdfPTable(2);
        miscCharge.HorizontalAlignment = 0;
        miscCharge.SpacingBefore = 5;
        miscCharge.SpacingAfter = 5;
        miscCharge.DefaultCell.Border = 0;
        miscCharge.SetWidths(new int[] { 1, 2 });
        miscCharge.AddCell(new Phrase("Charge Amount:", boldTableFont));
        miscCharge.AddCell(String.Format("${0:0.00}", Double.Parse(res.misctotal)));

        var miscReason = new PdfPTable(2);
        miscReason.HorizontalAlignment = 0;
        miscReason.SpacingBefore = 5;
        miscReason.SpacingAfter = 5;
        miscReason.DefaultCell.Border = 0;
        miscReason.SetWidths(new int[] { 1, 2 });
        miscReason.AddCell(new Phrase("Charge Reason:", boldTableFont));
        miscReason.AddCell(res.miscexplanation);

        var paid = new PdfPTable(2);
        paid.HorizontalAlignment = 0;
        paid.SpacingBefore = 5;
        paid.SpacingAfter = 5;
        paid.DefaultCell.Border = 0;
        paid.SetWidths(new int[] { 1, 2 });
        paid.AddCell(new Phrase("Paid?:", boldTableFont));
        paid.AddCell(new Phrase("Yes"));

        var method = new PdfPTable(2);
        method.HorizontalAlignment = 0;
        method.SpacingBefore = 5;
        method.SpacingAfter = 5;
        method.DefaultCell.Border = 0;
        method.SetWidths(new int[] { 1, 2 });
        method.AddCell(new Phrase("Method of Payment:", boldTableFont));
        method.AddCell("___________________________");

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

        document.Add(name);
        document.Add(affiliatedSchool);
        document.Add(hallAssigned);
        document.Add(miscCharge);
        document.Add(miscReason);
        document.Add(paid);
        document.Add(method);
        document.Add(coachSig);
        document.Add(staffSig);
        document.Add(reslife);

        var logo = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("~/wiaa/images/housingLogoTrack.jpg"));
        logo.SetAbsolutePosition(35, 730);
        document.Add(logo);

        document.Close();

        HttpContext.Current.Response.ContentType = "application/pdf";
        HttpContext.Current.Response.AddHeader("Content-Disposition", string.Format("attachment;filename=Charges-{0}.pdf", res.school == "" ? res.fname + " " + res.lname : res.school));
        HttpContext.Current.Response.BinaryWrite(output.ToArray());
    }

    new public void createHousingPDF()
    {
        DateTime time = DateTime.Now;
        // Create a Document object
        var document = new Document(PageSize.A4, 50, 50, 120, 25);

        NcaaReservation res = new NcaaReservation(HttpContext.Current.Session["NcaaEmail"].ToString());

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

        document.Add(new Paragraph("NCAA National Track Housing Assignment", titleFont));

        var schoolName = new PdfPTable(4);
        schoolName.HorizontalAlignment = 0;
        schoolName.SpacingBefore = 10;
        schoolName.SpacingAfter = 10;
        schoolName.DefaultCell.Border = 0;
        schoolName.SetWidths(new int[] { 1, 2, 1, 2 });
        schoolName.AddCell(new Phrase("School Name:", boldTableFont));
        schoolName.AddCell(res.school);
        schoolName.AddCell(new Phrase("Today's Date: ", boldTableFont));
        schoolName.AddCell(time.ToString());

        var hallAssigned = new PdfPTable(2);
        hallAssigned.HorizontalAlignment = 0;
        hallAssigned.SpacingBefore = 5;
        hallAssigned.SpacingAfter = 5;
        hallAssigned.DefaultCell.Border = 0;
        hallAssigned.SetWidths(new int[] { 1, 2 });
        hallAssigned.AddCell(new Phrase("Hall Assignment:", boldTableFont));
        // Hall
        hallAssigned.AddCell(res.reservedRooms[0].hall);

        document.Add(schoolName);
        document.Add(hallAssigned);

        if (res.reservedRooms[0].hall == "Eagle")
        {
            var maleRoomsAssigned = new PdfPTable(2);
            maleRoomsAssigned.HorizontalAlignment = 0;
            maleRoomsAssigned.SpacingBefore = 5;
            maleRoomsAssigned.SpacingAfter = 10;
            maleRoomsAssigned.DefaultCell.Border = 0;
            maleRoomsAssigned.SetWidths(new int[] { 1, 2 });
            maleRoomsAssigned.AddCell(new Phrase("Male Rooms:", boldTableFont));
            List<string> mrooms = new List<string>();
            foreach (RoomReservation r in res.reservedRooms)
            {
                if (r.gender == 'm')
                {
                    mrooms.Add(r.room + "(" + r.beds + ")");
                }
            }
            maleRoomsAssigned.AddCell(string.Join(", ", mrooms.ToArray()));

            var femaleRoomsAssigned = new PdfPTable(2);
            femaleRoomsAssigned.HorizontalAlignment = 0;
            femaleRoomsAssigned.SpacingBefore = 5;
            femaleRoomsAssigned.SpacingAfter = 10;
            femaleRoomsAssigned.DefaultCell.Border = 0;
            femaleRoomsAssigned.SetWidths(new int[] { 1, 2 });
            femaleRoomsAssigned.AddCell(new Phrase("Female Rooms:", boldTableFont));
            List<string> frooms = new List<string>();
            foreach (RoomReservation r in res.reservedRooms)
            {
                if (r.gender == 'f')
                {
                    frooms.Add(r.room + "(" + r.beds + ")");
                }
            }
            femaleRoomsAssigned.AddCell(string.Join(", ", frooms.ToArray()));

            document.Add(maleRoomsAssigned);
            document.Add(femaleRoomsAssigned);

            int mb = 0;
            int fb = 0;
            foreach (RoomReservation r in res.reservedRooms)
            {
                if (r.gender == 'f')
                {
                    fb += r.beds;
                }
                else
                {
                    mb += r.beds;
                }
            }

            var maleBeds = new PdfPTable(2);
            maleBeds.HorizontalAlignment = 0;
            maleBeds.SpacingBefore = 5;
            maleBeds.SpacingAfter = 5;
            maleBeds.DefaultCell.Border = 0;
            maleBeds.SetWidths(new int[] { 1, 2 });
            maleBeds.AddCell(new Phrase("Male Beds:", boldTableFont));
            // Hall
            maleBeds.AddCell(mb.ToString());

            var femaleBeds = new PdfPTable(2);
            femaleBeds.HorizontalAlignment = 0;
            femaleBeds.SpacingBefore = 5;
            femaleBeds.SpacingAfter = 5;
            femaleBeds.DefaultCell.Border = 0;
            femaleBeds.SetWidths(new int[] { 1, 2 });
            femaleBeds.AddCell(new Phrase("Female Beds:", boldTableFont));
            // Hall
            femaleBeds.AddCell(fb.ToString());

            var totalBeds = new PdfPTable(2);
            totalBeds.HorizontalAlignment = 0;
            totalBeds.SpacingBefore = 5;
            totalBeds.SpacingAfter = 5;
            totalBeds.DefaultCell.Border = 0;
            totalBeds.SetWidths(new int[] { 1, 2 });
            totalBeds.AddCell(new Phrase("Total Beds:", boldTableFont));
            // Hall
            totalBeds.AddCell((mb + fb).ToString());

            document.Add(maleBeds);
            document.Add(femaleBeds);
            document.Add(totalBeds);
        }
        else
        {
            var roomsAssigned = new PdfPTable(2);
            roomsAssigned.HorizontalAlignment = 0;
            roomsAssigned.SpacingBefore = 5;
            roomsAssigned.SpacingAfter = 10;
            roomsAssigned.DefaultCell.Border = 0;
            roomsAssigned.SetWidths(new int[] { 1, 2 });
            roomsAssigned.AddCell(new Phrase("Rooms:", boldTableFont));
            List<string> rooms = new List<string>();
            foreach (RoomReservation r in res.reservedRooms)
            {
                rooms.Add(r.room + "(" + r.beds + ")");
            }
            roomsAssigned.AddCell(string.Join(", ", rooms.ToArray()));

            document.Add(roomsAssigned);

            int suites = 0;
            int beds = 0;
            foreach (RoomReservation r in res.reservedRooms)
            {
                if (r.beds == 4)
                {
                    suites++;
                }
                else
                {
                    beds += r.beds;
                }
            }

            var totalSuites = new PdfPTable(2);
            totalSuites.HorizontalAlignment = 0;
            totalSuites.SpacingBefore = 5;
            totalSuites.SpacingAfter = 5;
            totalSuites.DefaultCell.Border = 0;
            totalSuites.SetWidths(new int[] { 1, 2 });
            totalSuites.AddCell(new Phrase("Suites:", boldTableFont));
            // Hall
            totalSuites.AddCell(suites.ToString());

            var totalBeds = new PdfPTable(2);
            totalBeds.HorizontalAlignment = 0;
            totalBeds.SpacingBefore = 5;
            totalBeds.SpacingAfter = 5;
            totalBeds.DefaultCell.Border = 0;
            totalBeds.SetWidths(new int[] { 1, 2 });
            totalBeds.AddCell(new Phrase("Beds:", boldTableFont));
            // Hall
            totalBeds.AddCell(beds.ToString());

            document.Add(totalSuites);
            document.Add(totalBeds);
        }

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
        emergency.SpacingAfter = 175;

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

        //document.Add(signature);
        document.Add(frontDesk);
        document.Add(roommateListing);
        document.Add(emergency);
        //document.Add(signature2);
        document.Add(reslife);

        var logo = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("~/wiaa/images/housingLogoTrack.jpg"));
        logo.SetAbsolutePosition(35, 730);
        document.Add(logo);

        document.Close();

        HttpContext.Current.Response.ContentType = "application/pdf";
        HttpContext.Current.Response.AddHeader("Content-Disposition", string.Format("attachment;filename=Housing-{0}.pdf", HttpContext.Current.Session["School"].ToString()));
        HttpContext.Current.Response.BinaryWrite(output.ToArray());
    }

    public void createReceiptPDF()
    {
        NcaaReservation res = (NcaaReservation)HttpContext.Current.Session["NcaaReservation"];

        DateTime time = DateTime.Now;
        // Create a Document object
        var document = new Document(PageSize.A4, 50, 50, 120, 10);

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

        document.Add(new Paragraph("NCAA National Track Housing Receipt", titleFont));

        var name = new PdfPTable(4);
        name.HorizontalAlignment = 0;
        name.SpacingBefore = 5;
        name.SpacingAfter = 0;
        name.DefaultCell.Border = 0;
        name.SetWidths(new int[] { 1, 2, 1, 2 });
        name.AddCell(new Phrase("Contact person:", boldTableFont));
        name.AddCell(res.fname + " " + res.lname);
        name.AddCell(new Phrase("Today's Date: ", boldTableFont));
        name.AddCell(time.ToString());

        var affiliatedSchool = new PdfPTable(2);
        affiliatedSchool.HorizontalAlignment = 0;
        affiliatedSchool.SpacingBefore = 5;
        affiliatedSchool.SpacingAfter = 0;
        affiliatedSchool.DefaultCell.Border = 0;
        affiliatedSchool.SetWidths(new int[] { 1, 2 });
        affiliatedSchool.AddCell(new Phrase("Affiliated School:", boldTableFont));
        affiliatedSchool.AddCell(res.school);

        var arrivalDeparture = new PdfPTable(2);
        arrivalDeparture.HorizontalAlignment = 0;
        arrivalDeparture.SpacingBefore = 5;
        arrivalDeparture.SpacingAfter = 0;
        arrivalDeparture.DefaultCell.Border = 0;
        arrivalDeparture.SetWidths(new int[] { 1, 2 });
        arrivalDeparture.AddCell(new Phrase("Dates:", boldTableFont));
        arrivalDeparture.AddCell(res.arrival.Split(' ')[0] + " - " + res.departure.Split(' ')[0]);

        var hallAssigned = new PdfPTable(2);
        hallAssigned.HorizontalAlignment = 0;
        hallAssigned.SpacingBefore = 5;
        hallAssigned.SpacingAfter = 10;
        hallAssigned.DefaultCell.Border = 0;
        hallAssigned.SetWidths(new int[] { 1, 2 });
        hallAssigned.AddCell(new Phrase("Hall Assignment:", boldTableFont));
        hallAssigned.AddCell(res.reservedRooms[0].hall);

        var headers = new PdfPTable(4);
        headers.HorizontalAlignment = 0;
        headers.SpacingBefore = 5;
        headers.SpacingAfter = 0;
        headers.DefaultCell.Border = 0;
        headers.SetWidths(new int[] { 2, 1, 1, 1 });
        headers.AddCell("");
        headers.AddCell("Rooms");
        headers.AddCell("Nights");
        headers.AddCell("Total");

        var roomReservations = new PdfPTable(4);
        roomReservations.HorizontalAlignment = 0;
        roomReservations.SpacingBefore = 0;
        roomReservations.SpacingAfter = 5;
        roomReservations.DefaultCell.Border = 1;
        roomReservations.SetWidths(new int[] { 2, 1, 1, 1 });

        int singles = 0;
        int doubles = 0;
        int suites = 0;
        int nights = (DateTime.Parse(res.departure) - DateTime.Parse(res.arrival)).Days;

        foreach (RoomReservation r in res.reservedRooms)
        {
            if (r.hall == "Reuter")
            {
                if (r.beds != 4)
                {
                    singles += r.beds;
                }
                else
                {
                    suites++;
                }
            }
            else
            {
                if (r.beds == 2)
                {
                    doubles++;
                }
                else
                {
                    singles++;
                }
            }
        }

        roomReservations.AddCell(new Phrase("Single rooms:", boldTableFont));
        roomReservations.AddCell(singles.ToString() + " X $" + String.Format("{0}", singleCost));
        roomReservations.AddCell("$" + String.Format("{0} X {1}", nights, singleCost * singles));
        roomReservations.AddCell("$" + String.Format("{0}", singleCost * singles * nights));

        roomReservations.AddCell(new Phrase("Double rooms:", boldTableFont));
        roomReservations.AddCell(doubles.ToString() + " X $" + String.Format("{0}", doubleCost));
        roomReservations.AddCell("$" + String.Format("{0} X {1}", nights, doubleCost * doubles));
        roomReservations.AddCell("$" + String.Format("{0}", doubleCost * doubles * nights));

        roomReservations.AddCell(new Phrase("Suites:", boldTableFont));
        roomReservations.AddCell(suites.ToString() + " X $" + String.Format("{0}", suiteCost));
        roomReservations.AddCell("$" + String.Format("{0} X {1}", nights, suiteCost * suites));
        roomReservations.AddCell("$" + String.Format("{0}", suiteCost * suites * nights));

        String paidby = res.paidBy;
        String check = res.checkNumber;

        var note = new PdfPTable(2);
        note.HorizontalAlignment = 0;
        note.SpacingBefore = 5;
        note.SpacingAfter = 10;
        note.DefaultCell.Border = 0;
        note.SetWidths(new int[] { 1, 2 });
        note.AddCell(new Phrase("Note:", boldTableFont));
        note.AddCell(res.billNote);

        var paid = new PdfPTable(7);
        paid.HorizontalAlignment = 0;
        paid.SpacingBefore = 10;
        paid.SpacingAfter = 0;
        paid.DefaultCell.Border = 0;
        paid.SetWidths(new int[] { 1, 1, 1, 1, 1, 1, 0 });
        paid.AddCell("Paid By:");
        paid.AddCell(paidby);
        paid.AddCell("Amount: ");
        String amount = res.amount.ToString();
        if (!amount.StartsWith("$"))
        {
            amount = "$" + amount;
        }
        paid.AddCell(amount);
        paid.AddCell("Check Number:");
        paid.AddCell(check);
        paid.AddCell("");

        String paidby2 = res.paidBy2;
        String check2 = res.checkNumber2;
        var secondpaid = new PdfPTable(7);
        secondpaid.HorizontalAlignment = 0;
        secondpaid.SpacingBefore = 0;
        secondpaid.SpacingAfter = 5;
        secondpaid.DefaultCell.Border = 0;
        secondpaid.SetWidths(new int[] { 1, 1, 1, 1, 1, 1, 0 });
        secondpaid.AddCell("Paid By (2):");
        secondpaid.AddCell(paidby2);
        secondpaid.AddCell("Amount (2): ");
        String amount2 = res.amount2.ToString();
        if (!amount2.StartsWith("$"))
        {
            amount2 = "$" + amount2;
        }
        secondpaid.AddCell(amount2);
        secondpaid.AddCell("Check Number (2):");
        secondpaid.AddCell(check2);
        secondpaid.AddCell("");

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

        var refundNote = new PdfPTable(1);
        refundNote.HorizontalAlignment = 0;
        refundNote.SpacingBefore = 0;
        refundNote.SpacingAfter = 5;
        refundNote.DefaultCell.Border = 0;
        refundNote.SetWidths(new int[] { 1 });
        refundNote.AddCell("*Note* A refund check will be processed and sent to your school. Please allow up to 14 business days.");

        var signature = new PdfPTable(1);
        signature.HorizontalAlignment = 0;
        signature.SpacingBefore = 10;
        signature.SpacingAfter = 8;
        signature.DefaultCell.Border = 0;
        signature.AddCell(new Phrase("_______________________       _______________________", boldTableFont));
        signature.AddCell("Signature of Residence Life Staff                      Date");

        Font arial = new Font(Font.FontFamily.TIMES_ROMAN, 11);
        Paragraph reslife = new Paragraph("Office of Residence Life\nEagle Hall | University of Wisconsin-La Crosse | 1500 La Crosse Street | La Crosse, WI 54601 USA\nPhone: 608.785.8075 | Fax: 608.875.8078\nAn affirmative action/equal opportunity employer", arial);
        reslife.Alignment = Element.ALIGN_CENTER;

        document.Add(name);
        document.Add(affiliatedSchool);
        document.Add(arrivalDeparture);
        document.Add(hallAssigned);
        document.Add(headers);
        document.Add(roomReservations);
        if (res.billNote != "")
        {
            document.Add(note);
        }
        document.Add(paid);
        if (paidby2 != "")
        {
            document.Add(secondpaid);
        }
        document.Add(finalTotal);
        String refundAmount = res.refund.ToString();
        if (refundAmount != "0")
        {
            document.Add(refundNote);
        }
        document.Add(signature);
        document.Add(reslife);

        var logo = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("~/wiaa/images/housingLogoTrack.jpg"));
        logo.SetAbsolutePosition(35, 730);
        document.Add(logo);

        document.Close();

        HttpContext.Current.Response.ContentType = "application/pdf";
        HttpContext.Current.Response.AddHeader("Content-Disposition", string.Format("attachment;filename=Receipt-{0}.pdf", res.email));
        HttpContext.Current.Response.BinaryWrite(output.ToArray());
    }
}