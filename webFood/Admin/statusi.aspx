<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.Master" AutoEventWireup="true" CodeBehind="statusi.aspx.cs" Inherits="webFood.Admin.statusi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        //fshin mesazhet 
        window.onload = function () {
            var seconds = 5;
            setTimeout(function () {
                document.getElementById("<%=lblMsg.ClientID %>").style.display = " none ";
            }, seconds * 1000);
        };
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
                                        <div class="col-sm-6 col-md-8 col-lg-8">
                                            <h4 class="sub-title">Lista e porosive</h4>
                                            <div class="card-block table-border-style">
                                                <div class="table-responsive">
                                                    <asp:Repeater ID="rstatusiPorosise" runat="server" OnItemCommand="rstatusiPorosise_ItemCommand">
                                                        <headertemplate>
                                                            <table class="table data-table-export table-hover nowrap">
                                                                <thead>
                                                                    <tr>
                                                                        <th class="table-plus">Numri Porosisë</th>
                                                                        <th>Data porosisë</th>
                                                                        <th>Statusi</th>
                                                                        <th>Emri produktit</th>
                                                                        <th>Cmimi Total</th>
                                                                        <th>Mënyra pagesës</th>
                                                                        <th class="datatable-nosort">Edito</th>

                                                                    </tr>

                                                                </thead>
                                                                <tbody>
                                                        </headertemplate>
                                                        <itemtemplate>
                                                            <tr>
                                                                <td class="table-plus"><%# Eval("porosiNumer")%></td>
                                                                <td><%# Eval("porosiDate")%></td>
                                                                <td>
                                                               <asp:Label ID="Lblstatus" runat="server" Text='<%# Eval("statusi") %>' CssClass='<%# GetStatusLabelClass(Eval("statusi").ToString()) %>'></asp:Label>


                                                                  
                                                                </td>
                                                                <td><%# Eval("emri")%></td>
                                                                <td><%# Eval("CmimiTotal")%></td>
                                                                <td><%# Eval("menyraPageses")%></td>
                                                                <td>
                                                                    <asp:LinkButton ID="LinkEdit" Text="Edito" runat="server" CssClass="badge badge-primary" CommandArgument='<%# Eval("porosiId") %>' CommandName="Edito"><i class="ti-pencil"></i></asp:LinkButton>
                                                                    </td>
                                                            </tr>
                                                        </itemtemplate>
                                                        <footertemplate>
                                                            </tbody>
                                                            </table>
                                                        </footertemplate>
                                                    </asp:Repeater>


                                                </div>


                                            </div>

                                        </div>


                                        <div class="col-sm-6 col-md-4 col-lg-4 mobile-inputs">
                                            <asp:Panel ID="pPerditesoStatusin" runat="server">
                                                <h4 class="sub-title">Përditëso statusin</h4>
                                                <div>
                                                    <div class="form-group">
                                                        <label>Statusi i porosisë</label>
                                                        <div>
                                                            <asp:DropDownList ID="ddlDtatus" runat="server" CssClass="form-control">
                                                                <asp:ListItem Value="0">Selekto statusin</asp:ListItem>
                                                                <asp:ListItem>Pending</asp:ListItem>
                                                                <asp:ListItem>Ne pritje për tu dorëzuar</asp:ListItem>
                                                                <asp:ListItem>Dorezuar</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="rfvstatusidorezimit" runat="server" ForeColor="Red" ControlToValidate="ddlDtatus" ErrorMessage="statusi i porosisë duhet të plotësohet" SetFocusOnError="true" Display="Dynamic" InitialValue="0"></asp:RequiredFieldValidator>
                                                            <asp:HiddenField ID="HiddenField1" runat="server" Value="0" />
                                                        </div>
                                                    </div>

                                                    <div class="pb-5">
                                                        <asp:Button ID="btnPerditeso" runat="server" Text="Perditeso" CssClass=" btn btn-primary" OnClick="btnPerditeso_Click" />
                                                        &nbsp;
                                                    <asp:Button ID="btnAnullo" runat="server" Text="Anullo" CssClass="btn btn-primary" CausesValidation="false" OnClick="btnAnullo_Click" />
                                                    </div>

                                                </div>
                                            </asp:Panel>

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
