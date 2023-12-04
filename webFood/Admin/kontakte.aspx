<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.Master" AutoEventWireup="true" CodeBehind="kontakte.aspx.cs" Inherits="webFood.Admin.kontakti" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        //fshin mesazhet 
        window.onload = function () {
            var seconds = 5;
            setTimeout(function () {
                document.getElementById("<%=lblMsg.ClientID %>").style.display = " none";
            }, seconds * 1000);
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="pcoded-inner-content pt-0">
        <div class="align-align-self-end">
            <asp:Label ID="lblMsg" runat="server" Visible="false"></asp:Label>
        </div>
        <div class="main-body">
            <div class="page-wrapper">
                <div class="page-body">
                    <div class="row">
                        <!-- Statestics Start -->
                        <div class="col-sm-12 ">
                            <div class="card">
                                <div class="card-header">
                                </div>
                                <div class="card-block">
                                    <div class="row">
                                      
                                        <div class="col-12 mobile-inputs">
                                            <h4 class="sub-title">Lista e kontakteve</h4>
                                            <div class="card-block table-border-style">
                                                <div class="table-responsive">
                                                    <asp:Repeater ID="rKontakti" runat="server" OnItemCommand="rKontakti_ItemCommand">
                                                        <HeaderTemplate>
                                                            <table class="table data-table-export table-hover nowrap">
                                                                <thead>
                                                                <tr>
                                                                    <th class="table-plus">Numri</th>
                                                                    
                                                                    <th>Emri i përdoruesit</th>
                                                                    <th>Emaili</th>
                                                                     <th>Mesazhi</th>
                                                                    <th>Data kontaktit</th>
                                                                    <th class="datatable-nosort">Fshi</th>

                                                                </tr>
                                                            
                                                            </thead>
                                                            <tbody>
                                                       </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <tr>
                                                            <td class="table-plus"><%# Eval("NumriSerial")%></td>
                                                               
                                                                <td>
                                                                    <%# Eval("emri")%>
                                                                </td>
                                                                 <td>
                                                                    <%# Eval("email")%>
                                                                </td>
                                                                <td>
                                                                    <%# Eval("qellimi")%>
                                                                </td>
                                                                
                                                                <td><%# Eval("datakrijimit")%></td>
                                                                 <td>
                                                                  
                                                                 <asp:LinkButton ID="LinkDelete" Text="Fshi" runat="server" CommandName="Fshi" CssClass="badge bg-danger" CommandArgument='<%# Eval("kontaktId") %>' OnClientClick="return confirm('Doni ta fshini këtë fushë');"><i class="ti-trash"></i></asp:LinkButton>
                                                                </td>



                                                            </tr>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            </tbody>
                                                            </table>
                                                        </FooterTemplate>
                                                    </asp:Repeater>


                                                 </div>
                                            

                                        </div>
                                </div>
                              </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
     </div>
</div>
</asp:Content>
