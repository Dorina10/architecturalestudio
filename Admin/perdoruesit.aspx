<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.Master" AutoEventWireup="true" CodeBehind="perdoruesit.aspx.cs" Inherits="webFood.Admin.perdoruesit" %>
<%@ Import Namespace="webFood" %>
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
                                            <h4 class="sub-title">Lista e përdoruesve</h4>
                                            <div class="card-block table-border-style">
                                                <div class="table-responsive">
                                                    <asp:Repeater ID="rUsers" runat="server" OnItemCommand="rUsers_ItemCommand">
                                                        <HeaderTemplate>
                                                            <table class="table data-table-export table-hover nowrap">
                                                                <thead>
                                                                <tr>
                                                                    <th class="table-plus">SrNo</th>
                                                                    <th>Emri</th>
                                                                    <th>Emri i përdoruesit</th>
                                                                    <th>Emaili</th>
                                                                    <th>Data regjistrimit</th>
                                                                    <th class="datatable-nosort">Fshi</th>

                                                                </tr>
                                                            
                                                            </thead>
                                                            <tbody>
                                                       </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <tr>
                                                            <td class="table-plus"><%# Eval("SrNo")%></td>
                                                                <td>
                                                                    <%# Eval("emri")%>
                                                                </td>
                                                                <td>
                                                                    <%# Eval("username")%>
                                                                </td>
                                                                 <td>
                                                                    <%# Eval("email")%>
                                                                </td>
                                                                
                                                                <td><%# Eval("datakrijimit")%></td>
                                                                 <td>
                                                                  
                                                                 <asp:LinkButton ID="LinkDelete" Text="Fshi" runat="server" CommandName="Fshi" CssClass="badge bg-danger" CommandArgument='<%# Eval("perdoruesId") %>' OnClientClick="return confirm('Doni ta fshini këtë përdorues');"><i class="ti-trash"></i></asp:LinkButton>
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
