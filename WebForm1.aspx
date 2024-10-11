<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="webformCRUD.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ValidationSummary ID="vs" runat="server" ValidationGroup="abc"  ShowMessageBox="true" ShowSummary="false"/>
            <table>
                <tr>
                    <td>Name :</td>
                    <td>
                        <asp:TextBox ID="txtname" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv" runat="server" ControlToValidate="txtname" ValidationGroup="abc"  ErrorMessage="please enter your name" Display="None"></asp:RequiredFieldValidator>
                   <asp:RegularExpressionValidator  ID="rev" runat="server"  ControlToValidate="txtname" ValidationGroup="abc" ErrorMessage="please enter name should be alphabetic" Display="None" ValidationExpression="^[a-zA-Z ]*$" ></asp:RegularExpressionValidator>
                        </td>
                </tr>
                <tr>
                    <td>State  :</td>
                    <td>
                        <asp:DropDownList ID="ddlstate" runat="server"></asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfvs" runat="server" ValidationGroup="abc" ControlToValidate="rblgender" ErrorMessage="please select your state!!" Display="None"></asp:RequiredFieldValidator>

                    </td>
                </tr>

                <tr>
                    <td>City  :</td>
                    <td>
                        <asp:DropDownList ID="ddlcity" runat="server"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td>Gender  :</td>
                    <td>
                        <asp:RadioButtonList ID="rblgender" runat="server" RepeatColumns="3"></asp:RadioButtonList>
                        <asp:RequiredFieldValidator ID="rfvg" runat="server" ValidationGroup="abc" ControlToValidate="rblgender" ErrorMessage="please choose your gender!!" Display="None"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnsubmit" runat="server" Text="Submit" ValidationGroup="abc" OnClick="btnsubmit_Click" /></td>
                    
                </tr >

                <tr >
                    <td></td>
                    <td style="background-color: slateblue; color: white">
                        <asp:GridView ID="gvregister" runat="server" OnRowCommand="gvregister_RowCommand" AutoGenerateColumns="false">
                            <Columns>
                                <asp:TemplateField HeaderText="ID">
                                    <ItemTemplate>
                                        <%#Eval("id") %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Name">
                                    <ItemTemplate>
                                        <%#Eval("name") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="State">
                                    <ItemTemplate>
                                        <%#Eval("sname") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="City">
                                    <ItemTemplate>
                                        <%#Eval("cname") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Gender">
                                    <ItemTemplate>
                                        <%#Eval("gname") %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                 <asp:TemplateField >
     <ItemTemplate >
          <asp:Button ID="btndelete" runat="server" Text="Delete" CommandName="D" CommandArgument=' <%#Eval("id") %>'  /></td>

     </ItemTemplate>
 </asp:TemplateField>
                                                                <asp:TemplateField >
    <ItemTemplate>
         <asp:Button ID="btndedit" runat="server" Text="Edit" CommandName="E" CommandArgument=' <%#Eval("id") %>' /></td>

    </ItemTemplate>
</asp:TemplateField>


                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
