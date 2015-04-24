<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<HelpDesk.Web.Client.Models.TicketCenterListViewModel>" %>
<ul id="submenu">

<% 
    foreach (var list in Model.ListsForMenu)
    {
        var className = ((Model.CurrentListSettings.ListName == list.ListName)) ? "selected" : string.Empty;
%>
    <li class="<%= className %>">
     
         <%= Html.ActionLink(list.ListDisplayName, MVC.TicketCenter.List(null, list.ListName))%>
     
    </li>
   
<%
    }
%>
</ul>