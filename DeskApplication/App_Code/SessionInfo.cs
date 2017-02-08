using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for SessionInfo
/// </summary>
public class SessionInfo
{
    public Boolean hideGlobalData, valid;
    public String redirectText, hallID, hallName;
    
    public SessionInfo(Boolean valid, Boolean hideGlobalData, String redirectText, String hallID, String hallName)
	{
        this.hideGlobalData = hideGlobalData;
        this.valid = valid;
        this.redirectText = redirectText;
        this.hallID = hallID;
        this.hallName = hallName;
	}
}
