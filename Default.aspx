<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 800px;
            border-color: #FFCC00;
            background-color: #FFCC66;
        }
        .auto-style2 {
            height: 43px;
            text-align: center;
            font-size: x-large;
        }
        .auto-style3 {
            height: 46px;
        }
        .auto-style4 {
            height: 41px;
        }
        .auto-style5 {
            height: 40px;
        }
        .auto-style6 {
            height: 38px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table align="center" class="auto-style1" border="2">
            <tr>
                <td class="auto-style2" colspan="3">CrudOperation</td>
            </tr>
            <tr>
                <td class="auto-style3">Name</td>
                <td class="auto-style3">
                    <asp:TextBox ID="txtname" runat="server" Height="29px" Width="239px"></asp:TextBox>
                </td>
                <td class="auto-style3"></td>
            </tr>
            <tr>
                <td class="auto-style4">Email</td>
                <td class="auto-style4">
                    <asp:TextBox ID="txtemail" runat="server" Height="29px" Width="239px"></asp:TextBox>
                </td>
                <td class="auto-style4"></td>
            </tr>
            <tr>
                <td class="auto-style5">Password</td>
                <td class="auto-style5">
                    <asp:TextBox ID="txtpassword" runat="server" Height="29px" Width="239px"></asp:TextBox>
                </td>
                <td class="auto-style5"></td>
            </tr>
            <tr>
                <td class="auto-style5">Gender</td>
                <td class="auto-style5">
                    <asp:RadioButton ID="RadioButton1" runat="server" Text="Male" />
                    <asp:RadioButton ID="RadioButton2" runat="server" Text="Female" />
                </td>
                <td class="auto-style5"></td>
            </tr>
            <tr>
                <td class="auto-style5">City</td>
                <td class="auto-style5">
                    <asp:DropDownList ID="DropDownList1" runat="server">
                    </asp:DropDownList>
                </td>
                <td class="auto-style5"></td>
            </tr>
            <tr>
                <td class="auto-style5">Image</td>
                <td class="auto-style5">
                    <asp:FileUpload ID="FileUpload1" runat="server" />
&nbsp;
                    <asp:Image ID="Image1" runat="server" Width="89px" />
                </td>
                <td class="auto-style5">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5">Mobile</td>
                <td class="auto-style5">
                    <asp:TextBox ID="txtmobile" runat="server" Height="29px" Width="239px"></asp:TextBox>
                </td>
                <td class="auto-style5"></td>
            </tr>
            <tr>
                <td class="auto-style6"></td>
                <td class="auto-style6">
                    <asp:Button ID="btnsubmit" runat="server" Height="37px" Text="Submit" Width="113px" OnClick="btnsubmit_Click" />
                </td>
                <td class="auto-style6"></td>
            </tr>
            <tr>
                <td class="auto-style5"></td>
                <td class="auto-style5"></td>
                <td class="auto-style5"></td>
            </tr>
        </table>
    
        <br />
        <asp:GridView ID="GridView1" AutoGenerateColumns="false" runat="server">
              <Columns>
              <asp:TemplateField HeaderText="Id">
                  <ItemTemplate>
                      
                      <label><%#Eval("Id") %></label>


                  </ItemTemplate>

              </asp:TemplateField>
                <asp:TemplateField HeaderText="Name">
                  <ItemTemplate>
                      <label><%#Eval("Name") %></label>

                  </ItemTemplate>

              </asp:TemplateField>  <asp:TemplateField HeaderText="Email">
                  <ItemTemplate>
                      <asp:Label ID="lbl3" Text='<%#Eval("Email") %>' runat="server"></asp:Label>

                  </ItemTemplate>

              </asp:TemplateField>  <asp:TemplateField HeaderText="Password">
                  <ItemTemplate>
                      <asp:Label ID="lbl4" Text='<%#Eval("Password") %>' runat="server"></asp:Label>

                  </ItemTemplate>

              </asp:TemplateField>  <asp:TemplateField HeaderText="Gender">
                  <ItemTemplate>
                      <asp:Label ID="lbl5" Text='<%#Eval("Gender") %>' runat="server"></asp:Label>

                  </ItemTemplate>

              </asp:TemplateField>  
                  <asp:TemplateField HeaderText="City">
                  <ItemTemplate>
                      <asp:Label ID="lbl6" Text='<%#Eval("City") %>' runat="server"></asp:Label>

                  </ItemTemplate>

              </asp:TemplateField> 
                         <asp:TemplateField HeaderText="Image">
                  <ItemTemplate>
                      <asp:Image ID="Image2" Height="100" Width="100" ImageUrl='<%#Eval("Image") %>' runat="server" />
                  </ItemTemplate>

              </asp:TemplateField> 
                   <asp:TemplateField HeaderText="Mobile">
                  <ItemTemplate>
                      <asp:Label ID="lbl7" Text='<%#Eval("Mobile") %>' runat="server"></asp:Label>

                  </ItemTemplate>

              </asp:TemplateField>  <asp:TemplateField HeaderText="Date">
                  <ItemTemplate>
                      <asp:Label ID="lbl8" Text='<%#Eval("Rdate") %>' runat="server"></asp:Label>

                  </ItemTemplate>

              </asp:TemplateField>  <asp:TemplateField HeaderText="Operation">
                  <ItemTemplate>
                      <a href='Default.aspx?edit=<%#Eval("Id") %>'>Edit</a>
                      <asp:LinkButton ID="LinkButton2" runat="server">Delete</asp:LinkButton>

                  </ItemTemplate>

              </asp:TemplateField>
          </Columns>
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
