<%@ Page Title="" Language="C#" MasterPageFile="~/Perdoruesi/Perdoruesi.Master" AutoEventWireup="true" CodeBehind="Karta.aspx.cs" Inherits="webFood.Perdoruesi.Karta" %>
<%@ Import Namespace="webFood" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="book_section layout_padding">
        <div class="container">
            <div class="heading_container">
                <div class="align-self-end">
                    <asp:Label ID="lblMesazh" runat="server" visible="false"></asp:Label>
                </div>
                <h2>
          Shporta e blerjeve 
        </h2>
            </div>

        </div>

        <div class="container">
            <asp:Repeater ID="rCartItem" runat="server" onItemCommand="rCartItem_ItemCommand" OnItemDataBound="rCartItem_ItemDataBound" >
                <HeaderTemplate>
                    <table class="table">
                        <thead>
                            <tr>
                            <th>Emri</th>
                            <th>Imazhi</th>
                            <th>Cmimi për njësi</th>
                            <th>Sasia</th>
                            <th>Cmimi total</th>
                            <th></th>
                            </tr>
                        </thead>
                        <tbody>
                    
                </HeaderTemplate>
                <ItemTemplate>
                 <tr>
                     <td>
                         <asp:Label ID="lblName" runat="server" Text='<%# Eval("emri") %>'></asp:Label>
                     </td>
                     <td>
                         <img width="60" src="<%# Utils.GetimazhiUrl(Eval("imazhiUrl")) %>" alt="" />
                     </td>
                     <td>
                         ALL <asp:Label ID="LblCmim" runat="server" Text='<%# Eval("cmimi") %>'></asp:Label>
                         <asp:HiddenField ID="HiddenProductId" runat="server" Value='<%# Eval("produktId") %>' />
                         <asp:HiddenField ID="HiddenSasia" runat="server"  Value='<%# Eval("sasia") %>'/>
                         <asp:HiddenField ID="HiddenProdQuantity" runat="server" Value='<%# Eval("produktSasia") %>' />
                     </td>
                     <td>
                         <div class="product__details__option">
                             <div class="quantity">
                                 <div class="pro-qty">
                                     <asp:TextBox ID="txtQuantity" runat="server" TextMode="Number" Text='<%# Eval("sasi") %>'></asp:TextBox>
                                     <asp:RegularExpressionValidator ID="revQuantity" runat="server" ErrorMessage="*" ForeColor="Red" Font-size="Small" ValidationExpression="[1-9]*" ControlToValidate="txtQuantity" Display="Dynamic" SetFocusOnError="true" EnableClientScript="true" ></asp:RegularExpressionValidator>
                                 </div>

                             </div>
                         </div>
                     </td>
                     <td><asp:Label ID="lblTotalCmim" runat="server" ></asp:Label></td>
                     <td>
                         <asp:LinkButton ID="lblDelete" runat="server" Text="Fshi" CommandName="Remove"
                             CommandArgument='<%# Eval("produktId") %>' 
                             OnClientClick="return confirm('Doni që ta hiqni këtë produkt nga karta?');"><i class="fa fa-close"></i></asp:LinkButton></td>
                 </tr>

                </ItemTemplate>
                
                <FooterTemplate>
                    <tr>
                        <td colspan="3"></td>
                        <td class="pl-lg-5"> <b>Totali përfundimtar</b></td>
                        <td>ALL<% Response.Write(Session["totali perfundimtar"]);%></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td colspan="3" class="continue__btn">
                            <a href="menu.aspx" class="btn btn-info"> <i class="fa fa-arrow-circle-left mr-2"></i>Vazhdo blerjen</a>
                        </td>
                        <td >
                            <asp:LinkButton ID="lbUpdate" runat="server" CommandName="Perditeso" CssClass=" btn btn-warning"> <i class="fa fa-refresh mr-2"></i>Perditëso shportën</asp:LinkButton>
                        </td>
                        <td >
                            <asp:LinkButton ID="lbKonfirmo" runat="server" OnClick="lbKonfirmo_Click" CommandName="Konfirmo" CssClass=" btn btn-success" AutoPostBack="false" >Konfirmo<i class="fa fa-arrow-circle-right ml-2"></i></asp:LinkButton>

                        </td>
                    </tr>
                    </tbody>
                 </table>
                </FooterTemplate>
            </asp:Repeater>
         </div>
    </section>
</asp:Content>
