<%@ Page Title="" Language="C#" MasterPageFile="~/Perdoruesi/Perdoruesi.Master" AutoEventWireup="true" CodeBehind="rregjistrimi.aspx.cs" Inherits="webFood.Perdoruesi.rregjistrimi" %>
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
                        $('#<%=fuUserImage.ClientID%>').prop('src', e.target.result)
                            .width(300)
                            .height(300);
                    };
                    reader.readAsDataURL(input.files[0]);
                }

            }
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="book_section layout_padding">
        <div class="container">
            <div class="heading_container">
                <div class="align-self-end">
                    <asp:Label  ID="lblMsg" runat="server" Visible="false"></asp:Label>
                </div>
                <asp:Label ID="lblHeaderMsg" runat="server" Text="<h2>Regjistrimi i përdoruesve</h2>"></asp:Label>
            </div>
            <div class="row">
                <div class="col-md-6">
                    <div class="form_container">
                        <div>
                            
                            <asp:RequiredFieldValidator ID="rfvName" runat="server" ErrorMessage="Emri duhet të plotësohet" ControlToValidate="TxtName" ForeColor="Red" Display="Dynamic" setFocusOnError="true"></asp:RequiredFieldValidator>
                          <asp:RegularExpressionValidator ID="revName" runat="server" ErrorMessage="Emri duhet të permbajë vetem karaktere" ForeColor="Red" Display="Dynamic" setFocusOnError="true" ValidationExpression="^[a-zA-Z\s]+$" ControlToValidate="TxtName"></asp:RegularExpressionValidator>
                             <asp:TextBox ID="TxtName" runat="server" CssClass="form-control" placeholder="Vendosni emrin tuaj:" ToolTip="Emri"></asp:TextBox>
                        </div>

                        <div>
                            <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ErrorMessage="Emri i përdoruesit  duhet të plotësohet" ControlToValidate="TxtUsername" ForeColor="Red" Display="Dynamic" setFocusOnError="true"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="TxtUsername" runat="server" CssClass="form-control" placeholder="Vendosni emrin e përdoruesit :" ToolTip="Emri i përdoruesit"></asp:TextBox>
                           
                    </div>

                        <div>
                            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="Emaili duhet të plotësohet" ControlToValidate="TxtEmail" ForeColor="Red" Display="Dynamic" setFocusOnError="true"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="TxtEmail" runat="server" CssClass="form-control" placeholder="Vendosni emailin:" ToolTip="Emaili i përdoruesit" TextMode="Email"></asp:TextBox>
                    </div>
                         <div>
                            <asp:RequiredFieldValidator ID="rfvMobile" runat="server" ErrorMessage="Numri i telefonit duhet të plotësohet" ControlToValidate="TxtEmail" ForeColor="Red" Display="Dynamic" setFocusOnError="true"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revMobile" runat="server" ErrorMessage="Numri i telefonit duhet të permbajë 10 shifra" ForeColor="Red" Display="Dynamic" setFocusOnError="true" ValidationExpression="^[0-9]{10}$" ControlToValidate="TxtMobile"></asp:RegularExpressionValidator>
                            <asp:TextBox ID="txtMobile" runat="server" CssClass="form-control" placeholder="Vendosni numrin e telefonit:" ToolTip="Numri i telefonit" TextMode="Number"></asp:TextBox>
                        </div>
                </div>
              </div>

                <div class="col-md-6">
                    <div class="form_container">
                        <div>
                            <asp:RequiredFieldValidator ID="RfvAdresa" runat="server" ErrorMessage="Adresa duhet të plotësohet" ControlToValidate="TxtAdresa" ForeColor="Red" Display="Dynamic" setFocusOnError="true"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="txtAdresa" runat="server" CssClass="form-control" placeholder="Vendosni adresën tuaj:" ToolTip="Adresa" TextMode="MultiLine"></asp:TextBox>
                           

                        <div>
                            <asp:RequiredFieldValidator ID="rfvKodipostar" runat="server" ErrorMessage="Kodi postar duhet të plotësohet" ControlToValidate="txtKodipostar" ForeColor="Red" Display="Dynamic" setFocusOnError="true"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revKodipostar" runat="server" ErrorMessage="Kodi postar duhet të jetë 4 shifra" ForeColor="Red" Display="Dynamic" setFocusOnError="true" ValidationExpression="^[0-9]{4}$" ControlToValidate="TxtKodipostar"></asp:RegularExpressionValidator>
                            <asp:TextBox ID="txtKodipostar" runat="server" CssClass="form-control" placeholder="Vendosni kodin postar :" ToolTip="Kodi postar" TextMode="Number"></asp:TextBox>
                           
                    </div>

                        <div>
                         <asp:FileUpload ID="fuUserImage" runat="server" CssClass="form-control" ToolTip="Imazhi përdoruesit" onchange="ImagePreview(this);"></asp:FileUpload>
                        </div>

                         <div>
                            <asp:RequiredFieldValidator ID="RfvPassword" runat="server" ErrorMessage="Passwordi duhet të plotesohet" ControlToValidate="txtPassword" ForeColor="Red" Display="Dynamic" setFocusOnError="true"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="Vendosni passwordin:" ToolTip="Password" TextMode="Password" ></asp:TextBox>
                         </div>
                    </div>
                </div>
                    
                    <div class="row pl-4">
                        <div class="btn_box">
                            <asp:Button ID="btnRegister" runat="server" Text="Regjistrohu" CssClass="btn btn-success rounded-pill pl-4 pr-4 text-white" OnClick="btnRegister_Click" />
                            <asp:Label ID="lblAlreadyUser" runat="server"  CssClass="pl-3  text-black-100" Text="Jeni i regjistruar ? <a href='Login.aspx' class='badge  badge-info'>Shtypni   këtu</a>"></asp:Label>
                        </div>
                    </div>

                   <div class="row p-5">
                       <div style="align-items:center">
                           <asp:Image ID="imgUser" runat="server" CssClass="img-thumbnail" />
                       </div>
                   </div>




            </div>
        </div>
            
    </section>
</asp:Content>
