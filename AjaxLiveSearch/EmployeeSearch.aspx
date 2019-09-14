<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeSearch.aspx.cs" Inherits="AjaxLiveSearch.EmployeeSearch" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table>
            <tr>
                <td>
                    Name
                </td>
                <td>
                    <input type="text" id="txtname" onkeyup="search();" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="ddlname" runat="server"
                        AutoPostBack="false" 
                        DataSourceID="SqlDataSource1" 
                        DataTextField="Ename" DataValueField="Ename" 
                        onchange = "ser()">
                                              </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AjaxEmpConnectionString %>" SelectCommand="SELECT [Ename] FROM [Employee]"></asp:SqlDataSource>
                </td>
            </tr> 
            
            
            
        </table>
        <br />
        <div id="d1">

        </div>
    </form>
    <script type="text/javascript">
        
        function search() {
            
                var a = new XMLHttpRequest();
            a.open("GET", "insert.aspx?opr=search&nm=" + document.getElementById("txtname").value, false);
           
                a.send(null);

                document.getElementById("d1").innerHTML = a.responseText;
            
        }
        function ser() {

            var a = new XMLHttpRequest();
            a.open("GET", "insert.aspx?opr=search&nm=" + document.getElementById("ddlname").value, false);

            a.send(null);

            document.getElementById("d1").innerHTML = a.responseText;

        }
    </script>
    
</body>
</html>
