﻿<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<HelpDesk.Domain.Models.Ticket>" %>
<% var Editor = "markitup"; %>

<div class="activityHeadWrapper">
    <div class="activityHead">
        <%: ViewData["activityDisplayName"].ToString() %>:
    </div>
</div>
<div class="activityBody">
    
    <% using (Ajax.BeginForm(MVC.TicketEditor.ActionNames.GiveUp, new { ID = Model.TicketId }, new AjaxOptions { UpdateTargetId = "activityArea", OnBegin = "beginChangeActivity", OnSuccess = "completeModifyTicketActivityAndDetails", OnFailure = "failModifyTicketActivity" }, new { defaultbutton = "giveUpButton", @Class = "editForm" }))
       {
    %>
     <div class="commentContainer">
        <%if (Editor == "markitup")
          { %>
        <%= Html.TextArea("comment", new { @Class = "markItUpEditor" })%>
        <%}
          else if (Editor == "wmd")
          { %>
        <div id="wmd-container" class="wmd-container-small">
            <%= Html.TextArea("comment", new { @Class = "wmd-input", Cols = "92", Rows = "15" })%>
        </div>
        <%} %>
        <%: Html.ValidationMessage("comment")%>
    </div>
    <input id="giveUpButton" type="submit" value="Give Up!" class="activityButton" style="display: inline;" /><span class="neverMindLink">
    <%= Ajax.ActionLink("Nevermind", MVC.TicketEditor.Display(Model.TicketId, string.Empty), new AjaxOptions { UpdateTargetId = "activityArea", OnBegin = "beginChangeActivity", OnSuccess = "completeActivity" })%></span>
    <%} %>
</div>
