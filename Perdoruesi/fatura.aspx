<%@ Page Title="" Language="C#" MasterPageFile="~/Perdoruesi/Perdoruesi.Master" AutoEventWireup="true" CodeBehind="fatura.aspx.cs" Inherits="webFood.Perdoruesi.fatura" %>
<%@ Import Namespace="webFood" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        //fshin alert mesazhet pas 5 sekondash
        window.onload = function () {
            var seconds = 5;
            setTimeout(function () {
                document.getElementById("<%=lblMesazh.ClientID %>").style.display = " none";
            }, seconds * 1000);
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <section class="book_section layout_padding">
        <div class="container">
            <div class="heading_container">
                <div class="align-self-end">
                    <asp:Label ID="lblMesazh" runat="server" visible="false"></asp:Label>
                </div>
          
            </div>
        </div>
           <div class="container">
               <asp:Repeater ID="rProduktiPorosi" runat="server">
                   <HeaderTemplate>
                       <table class="table table-responsive-sm table-bordered table-hover" id="tableFatura">
                           <thead class="bg-dark text-white">
                               <tr>
                                   <th>Numri Serial</th>
                                   <th>Numër Porosie</th>
                                   <th>Emri Produktit</th>
                                   <th>Cmimi për njësi</th>
                                   <th>Sasia</th>
                                   <th>Totali</th>
                               </tr>

                           </thead>
                           <tbody>
                   </HeaderTemplate>
                   <ItemTemplate>
                       <tr>
                           <td> <%# Eval("NumriSerial") %></td>
                            <td> <%# Eval("porosiNumer") %></td>
                            <td> <%# Eval("emri") %></td>
                            <td> <%# string.IsNullOrEmpty(Eval("cmimi").ToString()) ? "" : "ALL" + Eval("cmimi") %></td> <!--nese cmimi eshte bosh sdo jape gje ,nese nuk eshte eshte shaf cmimim-->
                            <td> <%# Eval("sasi") %></td>
                            <td> <%# Eval("CmimiTotal") %></td>
                        </tr>
                   </ItemTemplate>
                   <FooterTemplate>
                       </tbody>

                       </table>
                   </FooterTemplate>
               </asp:Repeater>
               <div class="text-center">
                   <asp:LinkButton ID="lbShkarkoFature" runat="server" CssClass="btn btn-info" OnClick="lbShkarkoFature_Click">
                       <i class="fa fa-file-pdf-o mr-2"></i>Shkarko Faturën
                   </asp:LinkButton>
               </div>


           </div>

       </section>
</asp:Content>
