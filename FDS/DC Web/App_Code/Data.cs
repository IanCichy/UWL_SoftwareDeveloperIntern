using FDS;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web.Script.Services;
using System.Web.Services;

/// <summary>
/// Provides access for Javascript AJAX requests to get statistics for use on /Stats.aspx
/// </summary>
[WebService(Namespace = "http://reslife.uwlax.edu/dcweb")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class Data : System.Web.Services.WebService
{
    // TODO: Only gets labels from first dataset currently
    // TODO: Colors
    private string DictToAllLineJSON(List<KeyValuePair<string, int>> dataset1, List<KeyValuePair<string, int>> dataset2,
                                     List<KeyValuePair<string, int>> dataset3, List<KeyValuePair<string, int>> dataset4,
                                     List<KeyValuePair<string, int>> dataset5, List<KeyValuePair<string, int>> dataset6,
                                     List<KeyValuePair<string, int>> dataset7, List<KeyValuePair<string, int>> dataset8,
                                     List<KeyValuePair<string, int>> dataset9, List<KeyValuePair<string, int>> dataset10, List<KeyValuePair<string, int>> dataset11,
                                     string label1, string label2, string label3, string label4, string label5,
                                     string label6, string label7, string label8, string label9, string label10, string label11)
    {
        var keys1 = from d in dataset1 select d.Key;
        var values1 = from d in dataset1 select d.Value;
        var labelsString1 = "\"" + string.Join("\", \"", keys1) + "\"";
        var dataString1 = "\"" + string.Join("\", \"", values1) + "\"";
        //-------------------------------------------------------------
        var keys2 = from d in dataset2 select d.Key;
        var values2 = from d in dataset2 select d.Value;
        var labelsString2 = "\"" + string.Join("\", \"", keys2) + "\"";
        var dataString2 = "\"" + string.Join("\", \"", values2) + "\"";
        //-------------------------------------------------------------
        var keys3 = from d in dataset3 select d.Key;
        var values3 = from d in dataset3 select d.Value;
        var labelsString3 = "\"" + string.Join("\", \"", keys3) + "\"";
        var dataString3 = "\"" + string.Join("\", \"", values3) + "\"";
        //-------------------------------------------------------------
        var keys4 = from d in dataset4 select d.Key;
        var values4 = from d in dataset4 select d.Value;
        var labelsString4 = "\"" + string.Join("\", \"", keys4) + "\"";
        var dataString4 = "\"" + string.Join("\", \"", values4) + "\"";
        //-------------------------------------------------------------
        var keys5 = from d in dataset5 select d.Key;
        var values5 = from d in dataset5 select d.Value;
        var labelsString5 = "\"" + string.Join("\", \"", keys5) + "\"";
        var dataString5 = "\"" + string.Join("\", \"", values5) + "\"";
        //-------------------------------------------------------------
        var keys6 = from d in dataset6 select d.Key;
        var values6 = from d in dataset6 select d.Value;
        var labelsString6 = "\"" + string.Join("\", \"", keys6) + "\"";
        var dataString6 = "\"" + string.Join("\", \"", values6) + "\"";
        //-------------------------------------------------------------
        var keys7 = from d in dataset7 select d.Key;
        var values7 = from d in dataset7 select d.Value;
        var labelsString7 = "\"" + string.Join("\", \"", keys7) + "\"";
        var dataString7 = "\"" + string.Join("\", \"", values7) + "\"";
        //-------------------------------------------------------------
        var keys8 = from d in dataset8 select d.Key;
        var values8 = from d in dataset8 select d.Value;
        var labelsString8 = "\"" + string.Join("\", \"", keys8) + "\"";
        var dataString8 = "\"" + string.Join("\", \"", values8) + "\"";
        //-------------------------------------------------------------
        var keys9 = from d in dataset9 select d.Key;
        var values9 = from d in dataset9 select d.Value;
        var labelsString9 = "\"" + string.Join("\", \"", keys9) + "\"";
        var dataString9 = "\"" + string.Join("\", \"", values9) + "\"";
        //-------------------------------------------------------------
        var keys10 = from d in dataset10 select d.Key;
        var values10 = from d in dataset10 select d.Value;
        var labelsString10 = "\"" + string.Join("\", \"", keys10) + "\"";
        var dataString10 = "\"" + string.Join("\", \"", values10) + "\"";
        //-------------------------------------------------------------
        var keys11 = from d in dataset11 select d.Key;
        var values11 = from d in dataset11 select d.Value;
        var labelsString11 = "\"" + string.Join("\", \"", keys11) + "\"";
        var dataString11 = "\"" + string.Join("\", \"", values11) + "\"";
        var json = string.Format(
@"{{
    ""labels"": [{0}],
    ""datasets"": [
        {{
            ""label"": ""{1}"",
            ""fillColor"": ""rgba(248,23,12,.4)"",
            ""strokeColor"": ""rgba(248,23,12,.4)"",
            ""HighlightFill"": ""#fff"",
            ""HighlightStroke"": ""rgba(248,23,12,.4)"",
            ""data"": [{2}]
        }} ,
        {{
            ""label"": ""{3}"",
            ""fillColor"": ""rgba(140,11,248,.4)"",
            ""strokeColor"": ""rgba(140,11,248,.4)"",

            ""HighlightFill"": ""#fff"",
            ""HighlightStroke"": ""rgba(140,11,248,.4)"",
            ""data"": [{4}]
        }} ,
        {{
            ""label"": ""{5}"",
            ""fillColor"": ""rgba(58,66,149,.4)"",
            ""strokeColor"": ""rgba(58,66,149,.4)"",
            ""HighlightFill"": ""#fff"",
            ""HighlightStroke"": ""rgba(58,66,149,.4)"",
            ""data"": [{6}]
        }} ,
        {{
            ""label"": ""{7}"",
            ""fillColor"": ""rgba(12,83,117,.4)"",
            ""strokeColor"": ""rgba(12,83,117,.4)"",
            ""HighlightFill"": ""#fff"",
            ""HighlightStroke"": ""rgba(12,83,117,.4)"",
            ""data"": [{8}]
        }} ,
        {{
            ""label"": ""{9}"",
            ""fillColor"": ""rgba(215,157,74,.4)"",
            ""strokeColor"": ""rgba(215,157,74,.4)"",
            ""HighlightFill"": ""#fff"",
            ""HighlightStroke"": ""rgba(215,157,74,.4)"",
            ""data"": [{10}]
        }} ,
        {{
            ""label"": ""{11}"",
            ""fillColor"": ""rgba(248,99,9,.4)"",
            ""strokeColor"": ""rgba(248,99,9,.4)"",
            ""HighlightFill"": ""#fff"",
            ""HighlightStroke"": ""rgba(248,99,9,.4)"",
            ""data"": [{12}]
        }} ,
        {{
            ""label"": ""{13}"",
            ""fillColor"": ""rgba(45,175,181,.4)"",
            ""strokeColor"": ""rgba(45,175,181,.4)"",
            ""HighlightFill"": ""#fff"",
            ""HighlightStroke"": ""rgba(45,175,181,.4)"",
            ""data"": [{14}]
        }} ,
        {{
            ""label"": ""{15}"",
            ""fillColor"": ""rgba(101,39,2,.4)"",
            ""strokeColor"": ""rgba(101,39,2,.4)"",
            ""HighlightFill"": ""#fff"",
            ""HighlightStroke"": ""rgba(101,39,2,.4)"",
            ""data"": [{16}]
        }} ,
        {{
            ""label"": ""{17}"",
            ""fillColor"": ""rgba(220,59,123,.4)"",
            ""strokeColor"": ""rgba(220,59,123,.4)"",
            ""HighlightFill"": ""#fff"",
            ""HighlightStroke"": ""rgba(220,59,123,.4)"",
            ""data"": [{18}]
        }} ,
        {{
            ""label"": ""{19}"",
            ""fillColor"": ""rgba(184,207,157,.4)"",
            ""strokeColor"": ""rgba(184,207,157,.4)"",
            ""HighlightFill"": ""#fff"",
            ""HighlightStroke"": ""rgba(184,207,157,.4)"",
            ""data"": [{20}]
        }} ,
        {{
            ""label"": ""{21}"",
            ""fillColor"": ""rgba(190,218,85,.4)"",
            ""strokeColor"": ""rgba(190,218,85,.4)"",
            ""HighlightFill"": ""#fff"",
            ""HighlightStroke"": ""rgba(190,218,85,.4)"",
            ""data"": [{22}]
        }}
    ]
}}
", labelsString1, label1, dataString1, label2, dataString2, label3, dataString3, label4, dataString4, label5, dataString5,
 label6, dataString6, label7, dataString7, label8, dataString8, label9, dataString9, label10, dataString10, label11, dataString11);

        return json;
    }




    // Build a dictionary, then sort it into a list, then pass it in to this
    private string DictToLineJSON(List<KeyValuePair<string, int>> data, string label)
    {
        var keys = from d in data select d.Key;
        var values = from d in data select d.Value;
        var labelsString = "\"" + string.Join("\", \"", keys) + "\"";
        var dataString = "\"" + string.Join("\", \"", values) + "\"";
        var json = string.Format(
@"{{
    ""labels"": [{0}],
    ""datasets"": [
        {{
            ""label"": ""{1}"",
            ""fillColor"": ""rgba(151,187,205,0.2)"",
            ""strokeColor"": ""rgba(151,187,205,1)"",
            ""pointColor"": ""rgba(151,187,205,1)"",
            ""pointStrokeColor"": ""#fff"",
            ""HighlightFill"": ""#fff"",
            ""HighlightStroke"": ""rgba(151,187,205,1)"",
            ""data"": [{2}]
        }}
    ]
}}
", labelsString, label, dataString);

        return json;
    }

    // TODO: Only gets labels from first dataset currently
    // TODO: Colors
    private string DictToTwoLineJSON(List<KeyValuePair<string, int>> dataset1,
                                     List<KeyValuePair<string, int>> dataset2, string label1, string label2)
    {
        var keys1 = from d in dataset1 select d.Key;
        var values1 = from d in dataset1 select d.Value;
        var labelsString1 = "\"" + string.Join("\", \"", keys1) + "\"";
        var dataString1 = "\"" + string.Join("\", \"", values1) + "\"";
        var keys2 = from d in dataset2 select d.Key;
        var values2 = from d in dataset2 select d.Value;
        var labelsString2 = "\"" + string.Join("\", \"", keys2) + "\"";
        var dataString2 = "\"" + string.Join("\", \"", values2) + "\"";
        var json = string.Format(
@"{{
    ""labels"": [{0}],
    ""datasets"": [
        {{
            ""label"": ""{1}"",
            ""fillColor"": ""rgba(100,100,100,0)"",
            ""strokeColor"": ""rgba(100,100,100,1)"",
            ""pointColor"": ""rgba(100,100,100,1)"",
            ""pointStrokeColor"": ""#fff"",
            ""HighlightFill"": ""#fff"",
            ""HighlightStroke"": ""rgba(100,100,100,1)"",
            ""data"": [{2}]
        }} ,
        {{
            ""label"": ""{3}"",
            ""fillColor"": ""rgba(151,187,205,0.2)"",
            ""strokeColor"": ""rgba(151,187,205,1)"",
            ""pointColor"": ""rgba(151,187,205,1)"",
            ""pointStrokeColor"": ""#fff"",
            ""HighlightFill"": ""#fff"",
            ""HighlightStroke"": ""rgba(151,187,205,1)"",
            ""data"": [{4}]
        }}
    ]
}}
", labelsString1, label1, dataString1, label2, dataString2);

        return json;
    }

    private string DictsToLineJSON(Dictionary<int, List<KeyValuePair<string, int>>> dicts)
    {
        if (dicts.Count == 0)
        {
            return "";
        }
        var labelsString = "\"" + string.Join("\", \"", (from d in dicts.First().Value select d.Key)) + "\"";
        List<string> datasetStrings = new List<string>();
        foreach (var kv in dicts)
        {
            Color color = ColorForHall(kv.Key);
            var datastring = "\"" + string.Join("\", \"", (from d in kv.Value select d.Value)) + "\"";
            datasetStrings.Add(string.Format(
@"      {{
            ""label"": ""{0}"",
            ""fillColor"": ""rgba({2},{3},{4},0)"",
            ""strokeColor"": ""rgba({2},{3},{4},1)"",
            ""pointColor"": ""rgba({2},{3},{4},1)"",
            ""pointStrokeColor"": ""#fff"",
            ""HighlightFill"": ""#fff"",
            ""HighlightStroke"": ""rgba({2},{3},{4},,1)"",
            ""data"": [{1}]
        }}", Hall.GetHallById(kv.Key).Name, datastring, color.R.ToString(), color.G.ToString(), color.B.ToString()));
        }

        var json = string.Format(
@"{{
    ""labels"": [{0}],
    ""datasets"": [
        {1}
    ]
}}
", labelsString, string.Join(",\n", datasetStrings));

        return json;
    }

    private Color ColorForHall(int hallID)
    {
        switch (hallID)
        {
            case 1:
                return ColorTranslator.FromHtml("#F8170C");

            case 2:
                return ColorTranslator.FromHtml("#8C0BF8");

            case 3:
                return ColorTranslator.FromHtml("#429504");

            case 4:
                return ColorTranslator.FromHtml("#0C5375");

            case 5:
                return ColorTranslator.FromHtml("#D79D4A");

            case 6:
                return ColorTranslator.FromHtml("#F86309");

            case 7:
                return ColorTranslator.FromHtml("#2DAEB5");

            case 8:
                return ColorTranslator.FromHtml("#652702");

            case 9:
                return ColorTranslator.FromHtml("#DC3B7B");

            case 10:
                return ColorTranslator.FromHtml("#B8CF9D");

            case 11:
                return ColorTranslator.FromHtml("#BADA55");

            default:
                return ColorTranslator.FromHtml("#000000");
        }
    }

    private string HallName(int hallID)
    {
        if (hallID == -1)
        {
            return "All Halls";
        }
        return Hall.GetHallById(hallID).Name;
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
    public void PizzaDayOfWeekLine(int hallID)
    {
        var data = GetDayOfWeekStats("SELECT * FROM dbo.StatsPizzaWeekDayByHall(@hallID) ORDER BY Count DESC", hallID);

        var response = DictToLineJSON(SortByDay(data), HallName(hallID));

        Context.Response.Write(response);
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
    public void PizzaHourLine(int hallID)
    {
        var data = GetHourOfDayStats("SELECT * FROM dbo.StatsPizzaHourByHall(@hallID) ORDER BY Hour", hallID);

        var response = DictToLineJSON(data.ToList(), HallName(hallID));

        Context.Response.Write(response);
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
    public void PackageDayOfWeekLine(int hallID)
    {
        var data = GetDayOfWeekStats("SELECT * FROM dbo.StatsPackagesWeekDayByHall(@hallID) ORDER BY Count DESC", hallID);

        var response = DictToLineJSON(SortByDay(data), HallName(hallID));

        Context.Response.Write(response);
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
    public void PackageHourLine(int hallID)
    {
        var data = GetHourOfDayStats("SELECT * FROM dbo.StatsPackagesHourByHall(@hallID) ORDER BY Hour", hallID);

        var response = DictToLineJSON(data.ToList(), HallName(hallID));

        Context.Response.Write(response);
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
    public void ProductDayOfWeekLine(int hallID)
    {
        var data = GetDayOfWeekStats("SELECT * FROM [dbo].[StatsProductsWeekDayByHall] (@hallID)", hallID);

        var response = DictToLineJSON(SortByDay(data), HallName(hallID));

        Context.Response.Write(response);
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
    public void ProductHourLine(int hallID)
    {
        var data = GetHourOfDayStats("SELECT * FROM dbo.StatsProductsHourByHall(@hallID) ORDER BY Hour", hallID);

        var response = DictToLineJSON(data.ToList(), HallName(hallID));

        Context.Response.Write(response);
    }

    private Dictionary<string, int> GetDayOfWeekStats(string sql, int hallID)
    {
        var command = new SqlCommand(sql)
        {
            CommandType = System.Data.CommandType.Text,
            Connection = Connections.FDSConnection()
        };

        command.Parameters.Add(new SqlParameter("hallID", hallID));

        command.Connection.Open();
        var reader = command.ExecuteReader();

        var data = new Dictionary<string, int>();

        while (reader.Read())
        {
            var day = reader["Day"].ToString();
            var count = int.Parse(reader["Count"].ToString());
            data.Add(day, count);
        }

        command.Connection.Close();

        return data;
    }

    private Dictionary<string, int> GetHourOfDayStats(string sql, int hallID)
    {
        var command = new SqlCommand(sql)
        {
            CommandType = System.Data.CommandType.Text,
            Connection = Connections.FDSConnection()
        };
        command.Parameters.Add(new SqlParameter("hallID", hallID));

        command.Connection.Open();
        var reader = command.ExecuteReader();

        var data = new Dictionary<string, int>();
        for (int h = 0; h < 24; h++)
        {
            data.Add(h.ToString(), 0);
        }

        while (reader.Read())
        {
            var hour = reader["Hour"].ToString();
            var count = int.Parse(reader["Count"].ToString());
            data[hour] = count;
        }

        command.Connection.Close();

        return data;
    }

    private List<KeyValuePair<string, int>> SortByDay(Dictionary<string, int> data)
    {
        var dayNames = Array.ConvertAll(CultureInfo.CurrentCulture.DateTimeFormat.DayNames, d => d.ToUpperInvariant());
        return data.ToList().OrderBy(kv => (Array.IndexOf(dayNames, kv.Key.ToUpper()) + 6) % 7).ToList();
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
    public void PizzaDayOfWeekLineComparison(int hallID)
    {
        var data1 = GetDayOfWeekStats("SELECT * FROM dbo.StatsPizzaWeekDayByHall(1) ORDER BY Count DESC", 1);
        var data2 = GetDayOfWeekStats("SELECT * FROM dbo.StatsPizzaWeekDayByHall(2) ORDER BY Count DESC", 2);
        var data3 = GetDayOfWeekStats("SELECT * FROM dbo.StatsPizzaWeekDayByHall(3) ORDER BY Count DESC", 3);
        var data4 = GetDayOfWeekStats("SELECT * FROM dbo.StatsPizzaWeekDayByHall(4) ORDER BY Count DESC", 4);
        var data5 = GetDayOfWeekStats("SELECT * FROM dbo.StatsPizzaWeekDayByHall(5) ORDER BY Count DESC", 5);
        var data6 = GetDayOfWeekStats("SELECT * FROM dbo.StatsPizzaWeekDayByHall(6) ORDER BY Count DESC", 6);
        var data7 = GetDayOfWeekStats("SELECT * FROM dbo.StatsPizzaWeekDayByHall(7) ORDER BY Count DESC", 7);
        var data8 = GetDayOfWeekStats("SELECT * FROM dbo.StatsPizzaWeekDayByHall(8) ORDER BY Count DESC", 8);
        var data9 = GetDayOfWeekStats("SELECT * FROM dbo.StatsPizzaWeekDayByHall(9) ORDER BY Count DESC", 9);
        var data10 = GetDayOfWeekStats("SELECT * FROM dbo.StatsPizzaWeekDayByHall(10) ORDER BY Count DESC", 10);
        var data11 = GetDayOfWeekStats("SELECT * FROM dbo.StatsPizzaWeekDayAverage() ORDER BY Count DESC", -1);
        var response = DictToAllLineJSON(SortByDay(data1), SortByDay(data2), SortByDay(data3), SortByDay(data4), SortByDay(data5),
                                         SortByDay(data6), SortByDay(data7), SortByDay(data8), SortByDay(data9), SortByDay(data10), SortByDay(data11),
                                         "Angell","Coate","Drake","Eagle","Hutch","Laux","Reuter","Sanford","Wentz","White","Avg");
        Context.Response.Write(response);
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
    public void PizzaHourLineComparison(int hallID)
    {
        var data1 = GetHourOfDayStats("SELECT * FROM dbo.StatsPizzaHourByHall(@hallID) ORDER BY Hour", hallID);
        var data2 = GetHourOfDayStats("SELECT * FROM dbo.StatsPizzaHourAverage() ORDER BY Hour", -1);

        var response = DictToTwoLineJSON(data2.ToList(), data1.ToList(), "Average", HallName(hallID));

        Context.Response.Write(response);
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
    public void PackageDayOfWeekLineComparison(int hallID)
    {
        var data1 = GetDayOfWeekStats("SELECT * FROM dbo.StatsPackagesWeekDayByHall(@hallID) ORDER BY Count DESC", hallID);
        var data2 = GetDayOfWeekStats("SELECT * FROM dbo.StatsPackagesWeekDayAverage() ORDER BY Count DESC", -1);

        var response = DictToTwoLineJSON(SortByDay(data2), SortByDay(data1), "Average", HallName(hallID));

        Context.Response.Write(response);
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
    public void PackageHourLineComparison(int hallID)
    {
        var data1 = GetHourOfDayStats("SELECT * FROM dbo.StatsPackagesHourByHall(@hallID) ORDER BY Hour", hallID);
        var data2 = GetHourOfDayStats("SELECT * FROM dbo.StatsPackagesHourAverage() ORDER BY Hour", -1);

        var response = DictToTwoLineJSON(data2.ToList(), data1.ToList(), "Average", HallName(hallID));

        Context.Response.Write(response);
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
    public void PizzaDayOfWeekLineAll()
    {
        Dictionary<int, List<KeyValuePair<string, int>>> data = new Dictionary<int, List<KeyValuePair<string, int>>>();
        for (int hallID = 1; hallID <= 10; hallID++)
        {
            data.Add(hallID, SortByDay(GetDayOfWeekStats("SELECT * FROM dbo.StatsPizzaWeekDayByHall(@hallID) ORDER BY Count DESC", hallID)));
        }
        var response = DictsToLineJSON(data);

        Context.Response.Write(response);
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
    public void DVDCheckOutDayOfWeekLine(int hallID)
    {
        var data = GetDayOfWeekStats("SELECT * FROM [dbo].[StatsDVDCheckOutWeekDayByHall](@hallID) ORDER BY Count DESC", hallID);
        var response = DictToLineJSON(SortByDay(data), HallName(hallID));
        Context.Response.Write(response);
    }
}