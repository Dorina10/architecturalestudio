<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.Master" AutoEventWireup="true" CodeBehind="produktet.aspx.cs" Inherits="webFood.Admin.produktet" %>
<%@ Import Namespace="webFood" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script>
        //fshin mesazhet 
        window.onload = function () {
            var seconds = 5;
            setTimeout(function () {
                document.getElementById("<%=lblMsg.ClientID %>").style.display = "none";
            }, seconds * 1000);
    </script>
    <script>
            function ImagePreview(input) {
                if (input.files && input.files[0]) {
                    var reader = new FileReader();
                    reader.onload = function (e) {
                        $('#<%=imazhprodukt.ClientID%>').prop('src', e.target.result)
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
                                            <h4 class="sub-title">Produktet </h4>
                                            <div>
                                                <div class="form-group">
                                                    <label>Emri Produkteve</label>
                                                    <div>
                                                        <asp:TextBox ID="textName" runat="server" CssClass="form-control" placeholder="Vendosni emrin e produktit" ></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Emri duhet të plotësohet" ForeColor="Red" display="Dynamic" SetFocusOnError="true" ControlToValidate="textName"></asp:RequiredFieldValidator>
                                                        <asp:HiddenField ID="hdnId" runat="server" Value="0" />
                                                    </div>
                                                </div>

                                                 <div class="form-group">
                                                    <label>Përshkrimi i produktit</label>
                                                    <div>
                                                        <asp:TextBox ID="TextPershkrimi" runat="server" CssClass="form-control" placeholder="Vendosni përshkrimin e produktit"  TextMode="MultiLine" ></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Pershkrimi duhet te plotesohet" ForeColor="Red" display="Dynamic" SetFocusOnError="true" ControlToValidate="TextPershkrimi"></asp:RequiredFieldValidator>
                                                       
                                                    </div>
                                                </div>

                                                 <div class="form-group">
                                                    <label>Cmimi i Produktit(ALL)</label>
                                                    <div>
                                                        <asp:TextBox ID="TextCmimi" runat="server" CssClass="form-control" placeholder="Vendosni cmimin e produktit" ></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Cmimi duhet të plotësohet" ForeColor="Red" display="Dynamic" SetFocusOnError="true" ControlToValidate="TextCmimi"></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Cmimi duhet të jete në numër me presje" ForeColor="Red" display="Dynamic" SetFocusOnError="true" ControlToValidate="TextCmimi" ValidationExpression="^\d{0,8}(\.\d{1,4})?$"></asp:RegularExpressionValidator>
                                                    </div>
                                                </div>

                                                
                                                 <div class="form-group">
                                                    <label>Sasia e produktit </label>
                                                    <div>
                                                        <asp:TextBox ID="TextSasia" runat="server" CssClass="form-control" placeholder="Vendosni sasinë e produktit" ></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Sasia duhet të plotësohet" ForeColor="Red" display="Dynamic" SetFocusOnError="true" ControlToValidate="TextSasia"></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Sasia nuk mund të jetë negative" ForeColor="Red" display="Dynamic" SetFocusOnError="true" ControlToValidate="TextSasia" ValidationExpression="^([1-9]\d*|0)$"></asp:RegularExpressionValidator>
                                                    </div>
                                                </div>

            


                                                <div class="form-group">
                                                    <label>Imazhi i produktit</label>
                                                    <div>
                                                        <asp:FileUpload ID="imazhi" runat="server" CssClass="form-control" onchange="ImagePreview(this);" />
                                                    </div>
                                                </div>

                                                 <div class="form-group">
                                                    <label>Kategoria e  produktit</label>
                                                    <div>
                                                        
                                                        <asp:DropDownList ID="kategorilist" runat="server" CssClass="form-control" DataSourceID="SqlDataSource1" DataTextField="emri" DataValueField="kategoriId" AppendDataBoundItems="true" >
                                                         <asp:ListItem Value="0">Selekto kategorine</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Kategoria duhet të plotësohet" ForeColor="Red" display="Dynamic" SetFocusOnError="true" ControlToValidate="kategorilist" InitialValue="0"></asp:RequiredFieldValidator>
                                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ushqimidbConnectionString %>" ProviderName="<%$ ConnectionStrings:ushqimidbConnectionString.ProviderName %>" SelectCommand="SELECT [kategoriId], [emri] FROM [Kategorite]"></asp:SqlDataSource>
                                                       
                                                    </div>
                                                </div>

                                                <div class="form-check pl-4">
                                                    <asp:CheckBox ID="cbisactive" runat="server" Text="&nbsp; aktive" CssClass=" form-check-input" />
                                                </div>
                                                <div class="pb-5">
                                                    <asp:Button ID="btnAddorUpdate" runat="server" Text="Shto" CssClass=" btn btn-primary"  OnClick="btnAddorUpdate_Click"/>
                                                   
                                                        
            
                                                    &nbsp;
                                                    <asp:Button ID="btnclear" runat="server" Text="Fshi" CssClass="btn btn-primary" CausesValidation="false" OnClick="btnclear_Click" />
                                                </div>
                                                <div>
                                                    <asp:Image ID="imazhprodukt" runat="server" CssClass="img-thumbnail" />
                                                </div>
                                            </div>
                                        </div>


                                        <div class="col-sm-6 col-md-8 col-lg-8 mobile-inputs">
                                            <h4 class="sub-title">Lista e kategorive</h4>
                                            <div class="card-block table-border-style">
                                                <div class="table-responsive">
                                                    <asp:Repeater ID="rProduktet" runat="server" OnItemCommand="rProduktet_ItemCommand" OnItemDataBound="rProduktet_ItemDataBound" >
                                                        <HeaderTemplate>
                                                            <table class="table data-table-export table-hover nowrap">
                                                                <thead>
                                                                <tr>
                                                                    <th class="table-plus">Emri</th>
                                                                    <th>Imazhi</th>
                                                                    <th>Cmimi(ALL)</th>
                                                                    <th>Sasia</th>
                                                                    <th>Kategoria</th>
                                                                    <th>Aktiviteti</th>
                                                                    <th>Përshkrimi</th>
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
                                                                <td><%# Eval("cmimi")%></td>
                                                                <td>
                                                                <asp:Label ID="Lblsasi" runat="server" Text='<%# Eval("sasia") %>' ></asp:Label>
                                                                </td>
                                                                <td><%# Eval("kategoriEmri")%></td>
                                                                <td>
                                                                <asp:Label ID="LblIsActive" runat="server" Text='<%# Eval("aktiviteti") %>' ></asp:Label>
                                                                </td>
                                                                <td><%# Eval("pershkrimi")%></td>
                                                                <td><%# Eval("datakrijimit")%></td>
                                                                 <td>
                                                                    <asp:LinkButton ID="LinkEdit" Text="Edito" runat="server" CssClass="badge badge-primary" CommandArgument='<%# Eval("produktId") %>' CommandName="Edito" CausesValidation="false"><i class="ti-pencil"></i></asp:LinkButton>
                                                                    <asp:LinkButton ID="LinkDelete" Text="Fshi" runat="server" CommandName="Fshi" CssClass="badge bg-danger" CommandArgument='<%# Eval("produktId") %>' OnClientClick="return confirm('Doni ta fshini këtë produkt');" CausesValidation="false"><i class="ti-trash"></i></asp:LinkButton>
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