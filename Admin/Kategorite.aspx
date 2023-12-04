<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.Master" AutoEventWireup="true" CodeBehind="Kategorite.aspx.cs" Inherits="webFood.Admin.Kategorite" %>
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
    <script>
            function ImagePreview(input) {
                if (input.files && input.files[0]) {
                    var reader = new FileReader();
                    reader.onload = function (e) {
                        $('#<%=imazhkategori.ClientID%>').prop('src', e.target.result)
                            .width(300)
                            .height(300);
                    };
                    reader.readAsDataURL(input.files[0]);
                }
            }

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
                                        <div class="col-sm-6 col-md-4 col-lg-4">
                                            <h4 class="sub-title">Kategoritë</h4>
                                            <div>
                                                <div class="form-group">
                                                    <label>Emri Kategorisë</label>
                                                    <div>
                                                        <asp:TextBox ID="textName" runat="server" CssClass="form-control" placeholder="Vendosni emrin e kategorisë" required></asp:TextBox>
                                                        <asp:HiddenField ID="hdnId" runat="server" Value="0" />
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label>Imazhi kategorisë</label>
                                                    <div>
                                                        <asp:FileUpload ID="imazhikategori" runat="server" CssClass="form-control" onchange="ImagePreview(this);" />
                                                    </div>
                                                </div>
                                                <div class="form-check pl-4">
                                                    <asp:CheckBox ID="cbisactive" runat="server" Text="&nbsp; aktive" CssClass=" form-check-input" />
                                                </div>
                                                <div class="pb-5">
                                                    <asp:Button ID="btnAddorUpdate" runat="server" Text="Shto" CssClass=" btn btn-primary" OnClick="BtnAddorUpdate_Click" />
                                                    &nbsp;
                                                    <asp:Button ID="btnclear" runat="server" Text="Fshi" CssClass="btn btn-primary" CausesValidation="false" OnClick="Btnclear_Click" />
                                                </div>
                                                <div>
                                                    <asp:Image ID="imazhkategori" runat="server" CssClass="img-thumbnail" />
                                                </div>
                                            </div>
                                        </div>


                                        <div class="col-sm-6 col-md-8 col-lg-8 mobile-inputs">
                                            <h4 class="sub-title">Lista e kategorive</h4>
                                            <div class="card-block table-border-style">
                                                <div class="table-responsive">
                                                    <asp:Repeater ID="rCategory" runat="server" OnItemCommand="rCategory_ItemCommand" OnItemDataBound="rCategory_ItemDataBound1">
                                                        <HeaderTemplate>
                                                            <table class="table data-table-export table-hover nowrap">
                                                                <thead>
                                                                <tr>
                                                                    <th class="table-plus">Emri</th>
                                                                    <th>Imazhi</th>
                                                                    <th>Aktiviteti</th>
                                                                    <th>DataKrijimit</th>
                                                                    <th class="datatable-nosort">Veprimi</th>

                                                                </tr>
                                                            
                                                            </thead>
                                                            <tbody>
                                                       </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <tr>
                                                            <td class="table-plus"><%# Eval("emri")%></td>
                                                                <td>
                                                                    <img alt=""  width="40 "src="<%# Utils.GetimazhiUrl(Eval("imazhiUrl")) %>" />
                                                                </td>
                                                                <td>
                                                                <asp:Label ID="LblIsActive" runat="server" Text='<%# Eval("aktiviteti") %>' ></asp:Label>
                                                                </td>
                                                                <td><%# Eval("datakrijimit")%></td>
                                                                 <td>
                                                                    <asp:LinkButton ID="LinkEdit" Text="Edito" runat="server" CssClass="badge badge-primary" CommandArgument='<%# Eval("kategoriId") %>' CommandName="Edito"><i class="ti-pencil"></i></asp:LinkButton>
                                                                    <asp:LinkButton ID="LinkDelete" Text="Fshi" runat="server" CommandName="Fshi" CssClass="badge bg-danger" CommandArgument='<%# Eval("kategoriId") %>' OnClientClick="return confirm('Doni ta fshini kete kategori');"><i class="ti-trash"></i></asp:LinkButton>
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
