<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GoogleAuthenticator.aspx.cs" Inherits="Steven.GoogleAuthenticator.WebForms.Account.GoogleAuthenticator" MasterPageFile="~/Site.Master" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <asp:Image ID="imgAuthenticatorQRCode" runat="server" />
        </div>
        <div class="form-group">
            <div class="col-md-2 control-label">
                Manual Key:                 
            </div>
            <div class="col-md-10">
                <asp:Literal ID="litManualKey" runat="server"></asp:Literal>
            </div>
        </div>
        <div class="col-md-5">
            <div class="input-group">
                <asp:TextBox ID="txtValidationCode" runat="server" CssClass="form-control" placeholder="Enter Validation Key..."></asp:TextBox>
                <span class="input-group-btn">
                    <asp:Button ID="btnValidate" runat="server" OnClick="btnValidate_Click" Text="Validate" CssClass="btn btn-primary" />
                </span>
            </div>
        </div>

    </div>


</asp:Content>
