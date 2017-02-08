using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for SessionHandler
/// </summary>
public class SessionHandler
{
	public SessionHandler()
	{
		
	}

    public static SessionInfo handleAdminSession(String hallID, String hallPath, UserData data)
    {        
        bool hideGlobalData = false, valid = true;
        string redirection = hallPath;

        if (data == null) // No session info - get out
        {
            redirection = "Login.aspx";
            valid = false;
        }
        else
        {
            if (data.hallID == "ALL") // can access any page
            {
                if (hallID == "ALL") // They want to see the global page, show it to them
                {
                    hideGlobalData = true; 
                }
                else // Want to see another page - check it for validity
                {
                    String hallName = DeskDA.getValidHallName(hallID);

                    if (hallName.Equals("")) // Invalid hall
                    {
                        redirection += "?hallid=ALL";
                        valid = false;
                    }

                    else
                    {

                    }
                }
            }
            else // Can only access the page in hallID
            {
                var validHalls = DeskDA.getAllHallsForUser(data.userName);
                if (validHalls.ContainsValue(hallID)) // Great, they are on a valid page
                {

                }
                else // No, you're not allowed to be here - send you to your page
                {
                    redirection += "ChooseHall.aspx" + data.hallID;
                    valid = false;
                }
            }
        }

        return new SessionInfo(valid, hideGlobalData, redirection, hallID, null);
    }

    
}
