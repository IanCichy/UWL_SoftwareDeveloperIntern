<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Comments.ascx.cs" Inherits="Controls_Messages" %>

<article class="module width_quarter">
    <header>
        <h3>Comments</h3>
    </header>
    <div class="message_list">
        <div class="module_content">
        </div>
    </div>
    <footer>
        <div class="post_message">
            <input type="text" value="Message" onfocus="if(!this._haschanged){this.value=''};this._haschanged=true;">
            <input type="submit" class="btn_post_message" value="Submit" />
        </div>
    </footer>
</article>
<!-- end of messages article -->