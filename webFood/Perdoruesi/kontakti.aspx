<%@ Page Title="" Language="C#" MasterPageFile="~/Perdoruesi/Perdoruesi.Master" AutoEventWireup="true" CodeBehind="kontakti.aspx.cs" Inherits="webFood.Perdoruesi.kontakti" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        //fshin mesazhet 
        window.onload = function () {
            var seconds = 5;
            setTimeout(function () {
                document.getElementById("<%=lblmsg.ClientID %>").style.display = " none";
            }, seconds * 1000);
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
     <!-- book section -->
  <section class="book_section layout_padding">
    <div class="container">
      <div class="heading_container">
           <div class="align-self-end">
                    <asp:Label ID="lblmsg" runat="server" ></asp:Label>
                </div>
        <h2>
          Na kontaktoni
        </h2>
      </div>
      <div class="row">
        <div class="col-md-6">
          <div class="form_container">
            
              <div>
                
                    <asp:TextBox ID="Txtemri" runat="server"  CssClass="form-control" placeholder="Emri"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvEmri" runat="server" ErrorMessage="Emri duhet të plotësohet" ControlToValidate="Txtemri" ForeColor="Red" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
              </div>
              <div>
                 <asp:TextBox ID="Txtemail" runat="server"  CssClass="form-control" placeholder="Email"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="Emaili duhet të plotësohet" ControlToValidate="Txtemail" 
                        ForeColor="Red" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
              </div>
              <div>
                <asp:TextBox ID="Textqellim" runat="server"  CssClass="form-control" placeholder="Mesazhi"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvqellimi" runat="server" ErrorMessage="Fusha duhet të plotësohet" ControlToValidate="Textqellim" 
                        ForeColor="Red" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
              </div>
             
              
              <div class="btn_box">
                  
                <asp:Button ID="btnsubmit" runat="server" Text="Dërgo"  CssClas="btn btn-warning rounded-pill pl-4 pr-4 text-white" onClick="btnsubmit_Click" style="margin-top: 15px; border: none; text-transform: uppercase; display: inline-block; padding: 10px 55px; background-color: blanchedalmond; color: black; border-radius: 45px; -webkit-transition: all 0.3s; transition: all 0.3s; border: none;" />
               
              </div>
           
          </div>
        </div>
        <div class="col-md-6">
          <div class="map_container ">
            <div id="googleMap"></div>
          </div>
        </div>
      </div>
    </div>
  </section>
</asp:Content>
