<%@ Page Title="" Language="C#" MasterPageFile="~/Perdoruesi/Perdoruesi.Master" AutoEventWireup="true" CodeBehind="Profili.aspx.cs" Inherits="webFood.Perdoruesi.Profili" %>
<%@ Import Namespace="webFood" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%
    string imageUrl = string.Empty;
    if (Session["imazhiUrl"] != null)
    {
        imageUrl = Session["imazhiUrl"].ToString();
    }
    %>




    <section class="book_section layout_padding">
        <div class="container">
            <div class="heading_container">
              
                 <h2>Informacion mbi përdoruesin</h2>
                    
            </div>
            <div class="container">
    <div class="row">
        <div class="col-md-4">
            <!-- Profile Image Section -->
            <div class="card">
                <div class="card-body">
                    <div class="text-center">
                        <img src="<%= Utils.GetimazhiUrl(imageUrl) %>" id="imgProfile" style="width:150px; height:150px;" class="img-thumbnail" />
                    </div>
                    <div class="middle pt-2">
                        <a href="rregjistrimi.aspx?Id=<%Response.Write(Session["perdoruesId"]);%>" class="btn btn-warning"><i class="fa fa-pencil"></i>Edito detajet</a>
                    </div>
                    <div class="userData ml-3">
                        
                       
                        
                        <h6 class="d-block">
                            <a href="javascript:void(0);">
                                <asp:Label ID="lbldatakrijimit1" runat="server" ToolTip="Profili u krijua ne:">Data Krijimit
                                    <%Response.Write(Session["datakrijimit"]);%>
                                </asp:Label>
                            </a>
                        </h6>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-8">
            <!-- Tabbed Content Section -->
            <ul class="nav nav-tabs mb-4" id="myTab" role="tablist">
                <li class="nav-item">
                    <a class="nav-link active text-info" id="basicInfo-tab" data-toggle="tab" href="#basicInfo" role="tab" aria-controls="basicInfo" aria-selected="true"><i class="fa fa-id-badge mr-2"></i>Informacioni baze</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link text-info" id="connectedServices-tab" data-toggle="tab" href="#connectedServices" role="tab" aria-controls="connectedServices" aria-selected="false"><i class="fa fa-clock-o mr-2"></i>Historiku</a>
                </li>
            </ul>
            <div class="tab-content ml-1">
                <!-- Informacion mbi perdoruesin -->
                <div class="tab-pane fade show active" id="basicInfo" role="tabpanel" arialabelledby="basicInfo-tab">
                    <asp:Repeater ID="rUserProfile1" runat="server">
                        <ItemTemplate>
                            <div class="row">
                                <div class="col-sm-3 col-md-2 col-5">
                                    <label style="font-weight:bold;">Emri</label>
                                </div>
                                <div class="col-md-8 col-6">
                                    <%# Eval("emri") %>
                                </div>
                            </div>
                            <hr />
                            <div class="row">
                                <div class="col-sm-3 col-md-2 col-5">
                                    <label style="font-weight:bold;">Emri i përdoruesit</label>
                                </div>
                                <div class="col-md-8 col-6">
                                    <%# Eval("username") %>
                                </div>
                            </div>
                            <hr />
                            <div class="row">
                                <div class="col-sm-3 col-md-2 col-5">
                                    <label style="font-weight:bold;">Numri i telefonit</label>
                                </div>
                                <div class="col-md-8 col-6">
                                    <%# Eval("mobile") %>
                                </div>
                            </div>
                            <hr />
                            <div class="row">
                                <div class="col-sm-3 col-md-2 col-5">
                                    <label style="font-weight:bold;">Email</label>
                                </div>
                                <div class="col-md-8 col-6">
                                    <%# Eval("email") %>
                                </div>
                            </div>
                            <hr />
                            <div class="row">
                                <div class="col-sm-3 col-md-2 col-5">
                                    <label style="font-weight:bold;">Kodi postar</label>
                                </div>
                                <div class="col-md-8 col-6">
                                    <%# Eval("kodiPostar") %>
                                </div>
                            </div>
                            <hr />
                            <div class="row">
                                <div class="col-sm-3 col-md-2 col-5">
                                    <label style="font-weight:bold;">Adresa</label>
                                </div>
                                <div class="col-md-8 col-6">
                                    <%# Eval("adresa") %>
                                </div>
                            </div>
                            <hr />
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <!-- Historiku i porosive -->
                <div class="tab-pane fade" id="connectedServices" role="tabpanel" arialabelledby="connectedServices-tab">
                    <asp:Repeater ID="rHistoriku" runat="server" OnItemDataBound="rHistoriku_ItemDataBound"> 
                        <ItemTemplate>
                            <div class="container">
                                <div class="row pt-1 pb-1" style="background-color:beige">
                                    <div class="col-4">
                                        <span class="badge badge-pill badge-dark text-white">
                                            <%# Eval("numriSerial") %>
                                        </span>
                                        Menyra Pageses: <%# Eval("menyraPageses").ToString() == "cod" ? "Para ne dore" : Eval("menyraPageses").ToString().ToUpper() %>     <!--cod cash on delivery-->
                                    </div>
                                    <div clas="col-6">
                                        <%# string.IsNullOrEmpty( Eval("numerKarte").ToString()) ? "" : "Numri Kartes" + Eval("numerKarte") %>  <!--terneray operator if dhe else-->
                                    </div>
                                    <div class="col-2" style="text-align:end">
                                        <a href="fatura.aspx?Id=<%# Eval("pagesaId") %> " class="btn btn-info btn-sm"><i class="fa fa-download mr-2"></i>Fatura</a> <!--mr margin fa:font awesome per ikonat-->
                                    </div>
                                </div>

                                <!--perdorim hidden hield per te ruajtur detjat e porosise-->
                                <asp:HiddenField ID="hdnPagesaId" runat="server" Value='<%# Eval("pagesaId") %>' />
                                <asp:Repeater ID="rPorosite" runat="server">
                                    <HeaderTemplate>
                                        <table class="table data-table-export table-responsive-sm table-bordered table-hover">
                                            <thead class="bg-dark text-white">
                                                <tr>
                                                    <th>Emri Produktit</th>
                                                    <th>Cmimi për njësi</th>
                                                    <th>Sasia</th>
                                                    <th>Cmimi Total</th>
                                                    <th>Porosi Id</th>
                                                    <th>Statusi</th>

                                                </tr>
                                           </thead>
                                            <tbody>

                                            

                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblEmri" runat="server" Text='<%# Eval("emri") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblcmimi" runat="server" Text='<%#  string.IsNullOrEmpty( Eval("cmimi").ToString()) ? "" : "ALL" + Eval("cmimi") %> '></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblsasi" runat="server" Text='<%# Eval("sasi") %>'></asp:Label>
                                            </td>
                                            <td>
                                               ALL <asp:Label ID="lblCmimiTotal" runat="server" Text='<%# Eval("CmimiTotal") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblporosiNumer" runat="server" Text='<%# Eval("porosiNumer") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Lblstatus" runat="server" Text='<%# Eval("statusi") %>' CssClass='<%# Eval("statusi").ToString() == "Dorezuar" ? "badge badge-success" : "badge badge-warning" %>'></asp:Label>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </tbody>
                                        </table>
                                    </FooterTemplate>
                                </asp:Repeater>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <!-- Mbarimi i historikut te porosise -->
            </div>
        </div>
    </div>
</div>
 </div>
              
    </section>
</asp:Content>
